var MATA;
(function (MATA) {
    var Select;
    (function (Select) {
        var AjaxSelect = /** @class */ (function () {
            function AjaxSelect(options) {
                this._loadTimeoutHandle = 0;
                this._loadTimeout = 500;
                this._isOpen = false;
                this._el = options.el;
                this._url = this._el.getAttribute("data-url");
                var inputValue = this._el.getAttribute("data-text");
                this._render(inputValue);
            }
            AjaxSelect.prototype._clear = function () {
                if (this._isOpen) {
                    this._isOpen = false;
                }
                var container = this._input.el.nextElementSibling;
                if (!container) {
                    return;
                }
                var body = container.lastChild;
                while (body.firstChild) {
                    body.removeChild(body.firstChild);
                }
                container.remove();
            };
            AjaxSelect.prototype._load = function () {
                var that = this;
                this._clear();
                $.ajax({
                    method: 'POST',
                    url: that._url,
                    data: {
                        q: that._input.el.value,
                        page: 1
                    }
                }).done(function (data) {
                    if (data.length) {
                        that._renderContainer(data);
                        that._isOpen = true;
                    }
                }).fail(function (err) {
                });
            };
            AjaxSelect.prototype._render = function (value) {
                var that = this;
                this._input = new AjaxSelectInput({
                    value: value,
                    onfocusin: function () {
                        if (that._isOpen) {
                            return;
                        }
                        that._load();
                    },
                    onkeydown: function (keyCode) {
                        if (keyCode == 9) {
                            return;
                        }
                    },
                    onkeyup: function (keyCode) {
                        if (keyCode == 9) {
                            return;
                        }
                        else if (keyCode == 37
                            || keyCode == 38
                            || keyCode == 39
                        //|| keyCode == 40
                        ) {
                            return;
                        }
                        else if (keyCode == 40) {
                            if (that._container && that._container.ajaxSelectBody.listGroup.Items.length) {
                                that._container.ajaxSelectBody.listGroup.Items[0].el.focus();
                            }
                            return;
                        }
                        if (that._loadTimeoutHandle) {
                            clearTimeout(that._loadTimeoutHandle);
                        }
                        that._loadTimeoutHandle = setTimeout(function () {
                            that._load();
                        }, that._loadTimeout);
                    }
                });
                this._el.parentElement.appendChild(this._input.el);
            };
            AjaxSelect.prototype._renderContainer = function (data) {
                var _this = this;
                this._container = new AjaxSelectContainer({
                    data: data,
                    textFieldName: this._el.getAttribute("data-text-field"),
                    valueFieldName: this._el.getAttribute("data-value-field")
                });
                this._container.onSelectChanged = function () {
                    _this._input.el.value = _this._container.ajaxSelectBody.listGroup.SelectedItem.text;
                    _this._el.value = _this._container.ajaxSelectBody.listGroup.SelectedItem.value;
                    _this._clear();
                };
                this._el.parentElement.appendChild(this._container.el);
            };
            return AjaxSelect;
        }());
        Select.AjaxSelect = AjaxSelect;
        var AjaxSelectContainer = /** @class */ (function () {
            function AjaxSelectContainer(options) {
                this.CLASS_NAME = "mt-select-container";
                this._options = options;
                this.el = this._render();
            }
            Object.defineProperty(AjaxSelectContainer.prototype, "ajaxSelectBody", {
                get: function () {
                    return this._ajaxSelectBody;
                },
                enumerable: true,
                configurable: true
            });
            AjaxSelectContainer.prototype._render = function () {
                var _this = this;
                var el = document.createElement('div');
                el.classList.add(this.CLASS_NAME);
                this._ajaxSelectBody = new AjaxSelectBody(this._options);
                this._ajaxSelectBody.onSelectChanged = function () {
                    if (_this.onSelectChanged) {
                        _this.onSelectChanged();
                    }
                };
                el.appendChild(this._ajaxSelectBody.el);
                return el;
            };
            return AjaxSelectContainer;
        }());
        var AjaxSelectInput = /** @class */ (function () {
            function AjaxSelectInput(options) {
                this._options = options;
                this.el = this._render();
            }
            AjaxSelectInput.prototype._render = function () {
                var _this = this;
                var el = document.createElement('input');
                el.id = MATA.Utils.generateGuid();
                el.classList.add('form-control');
                el.setAttribute('type', 'text');
                el.value = this._options.value;
                if (el.value) {
                    el.readOnly = true;
                }
                if (!el.readOnly) {
                    el.addEventListener("focusin", function (e) {
                        e.preventDefault();
                        if (_this._options.onfocusin) {
                            _this._options.onfocusin();
                        }
                    });
                    el.addEventListener("keydown", function (e) {
                        e.preventDefault();
                        if (_this._options.onkeydown) {
                            _this._options.onkeydown(e.keyCode);
                        }
                    });
                    el.addEventListener("keyup", function (e) {
                        e.preventDefault();
                        if (_this._options.onkeyup) {
                            _this._options.onkeyup(e.keyCode);
                        }
                    });
                }
                return el;
            };
            return AjaxSelectInput;
        }());
        var AjaxSelectBody = /** @class */ (function () {
            function AjaxSelectBody(options) {
                this.CLASS_NAME = "mt-select-body";
                this._options = options;
                this.el = this._render();
            }
            Object.defineProperty(AjaxSelectBody.prototype, "listGroup", {
                get: function () {
                    return this._listGroup;
                },
                enumerable: true,
                configurable: true
            });
            AjaxSelectBody.prototype._render = function () {
                var _this = this;
                var el = document.createElement('div');
                el.classList.add(this.CLASS_NAME);
                this._listGroup = new AjaxSelectListGroup(this._options);
                this._listGroup.onSelectChanged = function () {
                    if (_this.onSelectChanged) {
                        _this.onSelectChanged();
                    }
                };
                el.appendChild(this.listGroup.el);
                return el;
            };
            return AjaxSelectBody;
        }());
        var AjaxSelectListGroup = /** @class */ (function () {
            function AjaxSelectListGroup(options) {
                this.el = null;
                this._items = [];
                this._selectedItem = null;
                this._options = options;
                this.el = this._render();
            }
            Object.defineProperty(AjaxSelectListGroup.prototype, "Items", {
                get: function () {
                    return this._items;
                },
                enumerable: true,
                configurable: true
            });
            Object.defineProperty(AjaxSelectListGroup.prototype, "SelectedItem", {
                get: function () {
                    return this._selectedItem;
                },
                enumerable: true,
                configurable: true
            });
            AjaxSelectListGroup.prototype._render = function () {
                var that = this;
                var el = document.createElement('div');
                el.classList.add('list-group');
                that._options.data.forEach(function (_item) {
                    var item = new AjaxSelectListGroupItem({
                        text: _item[that._options.textFieldName],
                        value: _item[that._options.valueFieldName]
                    });
                    item.onSelected = function () {
                        that._setSelectedItem(item);
                    };
                    el.appendChild(item.el);
                    that._items.push(item);
                });
                return el;
            };
            AjaxSelectListGroup.prototype._setSelectedItem = function (item) {
                if (!this.SelectedItem || this.SelectedItem.value != item.value) {
                    this._selectedItem = item;
                    this._onSelectedItemChanged();
                }
            };
            AjaxSelectListGroup.prototype._onSelectedItemChanged = function () {
                if (this.onSelectChanged) {
                    this.onSelectChanged();
                }
            };
            return AjaxSelectListGroup;
        }());
        var AjaxSelectListGroupItem = /** @class */ (function () {
            function AjaxSelectListGroupItem(options) {
                this.text = options.text;
                this.value = options.value;
                this.el = this._render();
            }
            AjaxSelectListGroupItem.prototype._render = function () {
                var _this = this;
                var el = document.createElement('a');
                el.href = "#";
                el.innerText = this.text;
                el.classList.add('list-group-item');
                el.addEventListener("click", function (e) {
                    e.preventDefault();
                    _this._onSelected();
                    //el.focus();
                });
                el.addEventListener('keyup', function (e) {
                    e.preventDefault();
                    if (e.keyCode == 37 || e.keyCode == 38) { // left or up
                        var prevEl = _this.el.previousElementSibling;
                        if (prevEl) {
                            prevEl.focus();
                        }
                    }
                    else if (e.keyCode == 39 || e.keyCode == 40) { // right or down
                        var nextEl = _this.el.nextElementSibling;
                        if (nextEl) {
                            nextEl.focus();
                        }
                    }
                    else if (e.keyCode == 13) { // enter
                        _this._onSelected();
                    }
                });
                el.addEventListener('keydown', function (e) {
                    e.preventDefault();
                    if (e.keyCode == 9) {
                        return;
                    }
                });
                return el;
            };
            AjaxSelectListGroupItem.prototype._onSelected = function () {
                if (this.onSelected) {
                    this.onSelected();
                }
            };
            return AjaxSelectListGroupItem;
        }());
    })(Select = MATA.Select || (MATA.Select = {}));
})(MATA || (MATA = {}));
//# sourceMappingURL=mata.select.js.map