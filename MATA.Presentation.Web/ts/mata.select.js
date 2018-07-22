var MATA;
(function (MATA) {
    var Select;
    (function (Select) {
        var AjaxSelect = /** @class */ (function () {
            function AjaxSelect(options) {
                this.CONTAINER_CLASS_NAME = "mt-select-container";
                this.HEADING_CLASS_NAME = "mt=select-heading";
                this.BODY_CLASS_NAME = "mt-select-body";
                this._loadTimeoutHandle = 0;
                this._loadTimeout = 500;
                //private _isLoaded = false;
                this._reload = false;
                this._hiddenEl = options.el;
                this._url = this._hiddenEl.getAttribute("data-url");
                this._textFieldName = this._hiddenEl.getAttribute("data-text-field");
                this._valueFieldName = this._hiddenEl.getAttribute("data-value-field");
                this.createInputElement();
                this.initEvents();
            }
            AjaxSelect.prototype.initEvents = function () {
                var that = this;
                this._el.addEventListener("focusin", function (e) {
                    e.preventDefault();
                    that.load();
                });
                this._el.addEventListener("focusout", function (e) {
                    e.preventDefault();
                    setTimeout(function () {
                        that.clear();
                    }, 200);
                });
                this._el.addEventListener("keyup", function (e) {
                    e.preventDefault();
                    if (that._loadTimeoutHandle) {
                        clearTimeout(that._loadTimeoutHandle);
                    }
                    that._loadTimeoutHandle = setTimeout(function () {
                        that.load();
                    }, that._loadTimeout);
                });
            };
            AjaxSelect.prototype.clear = function () {
                var container = this._el.nextElementSibling;
                if (!container) {
                    return;
                }
                var body = container.lastChild;
                while (body.firstChild) {
                    var el = (body.firstChild);
                    if (el.hasAttribute("selected")) {
                        this._el.value = el.innerText;
                        this._hiddenEl.value = el.getAttribute('data-val');
                    }
                    body.removeChild(body.firstChild);
                }
                container.remove();
                //this._isLoaded = false;
            };
            AjaxSelect.prototype.load = function () {
                //if (this._isLoaded) {
                //    this._isLoaded = false;
                //    return;
                //}
                var that = this;
                this.clear();
                $.ajax({
                    method: 'POST',
                    url: that._url,
                    data: {
                        q: that._el.value,
                        page: 1
                    }
                }).done(function (data) {
                    if (data.length) {
                        var div = that.createSelectList(data);
                        that._el.parentElement.appendChild(div);
                    }
                }).fail(function (err) {
                });
            };
            AjaxSelect.prototype.createInputElement = function () {
                this._el = document.createElement('input');
                this._el.id = MATA.Utils.generateGuid();
                this._el.classList.add('form-control');
                this._el.setAttribute('type', 'text');
                this._el.value = this._hiddenEl.value;
                this._hiddenEl.parentElement.appendChild(this._el);
            };
            AjaxSelect.prototype.createSelectList = function (data) {
                var that = this;
                var container = document.createElement('div');
                container.classList.add(this.CONTAINER_CLASS_NAME);
                //var heading = document.createElement('div');
                //heading.classList.add('mt-select-heading');
                //var textBox = document.createElement('input');
                //textBox.type = 'text';
                //textBox.classList.add('form-control');
                //heading.appendChild(textBox);
                //container.appendChild(heading);
                var body = document.createElement('div');
                body.classList.add('list-group');
                body.classList.add(this.BODY_CLASS_NAME);
                container.appendChild(body);
                //div.style.width = that._el.style.width;
                //div.style.top = that._el.style.top + that._el.style.height;
                //div.style.left = that._el.style.left;
                data.forEach(function (_item) {
                    var li = that.createSelectListItem(_item);
                    body.appendChild(li);
                });
                return container;
            };
            AjaxSelect.prototype.createSelectListItem = function (item) {
                var selectListItem = document.createElement('a');
                selectListItem.href = "#";
                selectListItem.innerText = item[this._textFieldName];
                selectListItem.setAttribute("data-val", item[this._valueFieldName]);
                selectListItem.classList.add('list-group-item');
                selectListItem.addEventListener("click", function (e) {
                    e.preventDefault();
                    this.setAttribute("selected", null);
                });
                return selectListItem;
            };
            return AjaxSelect;
        }());
        Select.AjaxSelect = AjaxSelect;
        //class okan {
        //    constructor() {
        //    }
        //    func1() {
        //    }
        //}
        //class okan2 extends okan {
        //    constructor() {
        //        super();
        //    }
        //    func2() {
        //    }
        //}
    })(Select = MATA.Select || (MATA.Select = {}));
})(MATA || (MATA = {}));
//# sourceMappingURL=mata.select.js.map