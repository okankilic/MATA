module MATA.Select {

    export class AjaxSelect {

        private _el: HTMLInputElement;

        private _input: AjaxSelectInput;

        private _container: AjaxSelectContainer;

        private _url: string;

        private _loadTimeoutHandle = 0;
        private _loadTimeout = 500;

        private _isOpen = false;

        constructor(options: IAjaxSelectOptions) {

            this._el = options.el;

            this._url = this._el.getAttribute("data-url");

            var inputValue = this._el.getAttribute("data-value");

            this._render(inputValue);
        }

        private _clear() {

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
        }

        private _load() {

            var that = this;

            this._clear();

            $.ajax({
                method: 'POST',
                url: that._url,
                data: {
                    q: that._input.el.value,
                    page: 1
                }
            }).done(function (data: any[]) {

                if (data.length) {
                    that._renderContainer(data);
                    that._isOpen = true;
                }

            }).fail(function (err) {

            });

        }

        private _render(value: any) {

            var that = this;

            this._input = new AjaxSelectInput({
                value: value,
                onfocusin: function () {

                    if (that._isOpen) {
                        return;
                    }

                    that._load();
                },
                onkeydown: function (keyCode: number) {

                    if (keyCode == 9) {
                        return;
                    }

                },
                onkeyup: function (keyCode: number) {

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
        }

        private _renderContainer(data: any[]) {

            this._container = new AjaxSelectContainer({
                data: data,
                textFieldName: this._el.getAttribute("data-text-field"),
                valueFieldName: this._el.getAttribute("data-value-field")
            });

            this._container.onSelectChanged = () => {
                this._input.el.value = this._container.ajaxSelectBody.listGroup.SelectedItem.text;
                this._el.value = this._container.ajaxSelectBody.listGroup.SelectedItem.value;
                this._clear();
            };

            this._el.parentElement.appendChild(this._container.el);
        }
    }

    export interface IAjaxSelectOptions {
        el: HTMLInputElement
    }

    interface IAjaxSelectContainerOptions {
        data: any[],
        textFieldName: string,
        valueFieldName: string
    }

    class AjaxSelectContainer {

        readonly CLASS_NAME = "mt-select-container";

        readonly el: HTMLDivElement;

        private _ajaxSelectBody: AjaxSelectBody;

        private _options: IAjaxSelectContainerOptions;

        onSelectChanged: () => void;

        get ajaxSelectBody() {
            return this._ajaxSelectBody;
        }

        constructor(options: IAjaxSelectContainerOptions) {

            this._options = options;

            this.el = this._render();
        }

        private _render(): HTMLDivElement {

            let el = document.createElement('div');

            el.classList.add(this.CLASS_NAME);

            this._ajaxSelectBody = new AjaxSelectBody(this._options);
            this._ajaxSelectBody.onSelectChanged = () => {

                if (this.onSelectChanged) {
                    this.onSelectChanged();
                }
            };

            el.appendChild(this._ajaxSelectBody.el);

            return el;
        }
    }

    interface IAjaxSelectInputOptions {
        value: any,
        onfocusin: () => void,
        onkeyup: (keyCode: number) => void,
        onkeydown: (keyCode: number) => void
    }

    class AjaxSelectInput {

        readonly el: HTMLInputElement;

        private readonly _options: IAjaxSelectInputOptions;

        constructor(options: IAjaxSelectInputOptions) {

            this._options = options;

            this.el = this._render();
        }

        private _render(): HTMLInputElement {

            let el = document.createElement('input');

            el.id = Utils.generateGuid();

            el.classList.add('form-control');

            el.setAttribute('type', 'text');

            el.value = this._options.value;

            if (el.value) {
                el.readOnly = true;
            }

            if (!el.readOnly) {

                el.addEventListener("focusin", (e) => {
                    e.preventDefault();
                    if (this._options.onfocusin) {
                        this._options.onfocusin();
                    }
                });

                el.addEventListener("keydown", (e) => {

                    e.preventDefault();

                    if (this._options.onkeydown) {
                        this._options.onkeydown(e.keyCode);
                    }

                });

                el.addEventListener("keyup", (e) => {

                    e.preventDefault();

                    if (this._options.onkeyup) {
                        this._options.onkeyup(e.keyCode);
                    }

                });

            }

            return el;
        }
    }

    interface IAjaxSelectBodyOptions {
        data: any[],
        textFieldName: string,
        valueFieldName: string
    }

    class AjaxSelectBody {

        readonly CLASS_NAME = "mt-select-body";

        readonly el: HTMLDivElement;

        private _options: IAjaxSelectBodyOptions;

        private _listGroup: AjaxSelectListGroup;

        onSelectChanged: () => void;

        get listGroup() {
            return this._listGroup;
        }

        constructor(options: IAjaxSelectBodyOptions) {

            this._options = options;

            this.el = this._render();

        }

        private _render(): HTMLDivElement {

            let el = document.createElement('div');

            el.classList.add(this.CLASS_NAME);

            this._listGroup = new AjaxSelectListGroup(this._options);

            this._listGroup.onSelectChanged = () => {

                if (this.onSelectChanged) {
                    this.onSelectChanged();
                }

            };

            el.appendChild(this.listGroup.el);

            return el;
        }
    }

    interface IAjaxSelectListGroupOptions {
        data: any[],
        textFieldName: string,
        valueFieldName: string
    }

    class AjaxSelectListGroup {

        readonly _options: IAjaxSelectListGroupOptions;

        readonly el: HTMLDivElement = null;

        private _items: AjaxSelectListGroupItem[] = [];

        get Items() {
            return this._items;
        }

        private _selectedItem: AjaxSelectListGroupItem = null;

        get SelectedItem() {
            return this._selectedItem;
        }

        onSelectChanged: () => void;

        constructor(options: IAjaxSelectListGroupOptions) {
            this._options = options;
            this.el = this._render();
        }

        private _render(): HTMLDivElement {

            var that = this;

            var el = document.createElement('div');

            el.classList.add('list-group');

            that._options.data.forEach(function (_item) {

                let item = new AjaxSelectListGroupItem({
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
        }

        private _setSelectedItem(item: AjaxSelectListGroupItem) {

            if (!this.SelectedItem || this.SelectedItem.value != item.value) {
                
                this._selectedItem = item;
                this._onSelectedItemChanged();

            }

        }

        private _onSelectedItemChanged() {

            if (this.onSelectChanged) {
                this.onSelectChanged();
            }

        }
    }

    interface IAjaxSelectListGroupItemOptions {
        text: string,
        value: any
    }

    class AjaxSelectListGroupItem {

        readonly el: HTMLAnchorElement;

        readonly text: string;
        readonly value: any;

        onSelected: () => void;

        constructor(options: IAjaxSelectListGroupItemOptions) {

            this.text = options.text;
            this.value = options.value;

            this.el = this._render();
        }

        private _render() {

            let el = document.createElement('a');

            el.href = "#";
            el.innerText = this.text;

            el.classList.add('list-group-item');

            el.addEventListener("click", (e) => {
                e.preventDefault();
                this._onSelected();
                //el.focus();
            });

            el.addEventListener('keyup', (e) => {
                e.preventDefault();

                if (e.keyCode == 37 || e.keyCode == 38) { // left or up
                    let prevEl = <HTMLAnchorElement>this.el.previousElementSibling;
                    if (prevEl) {
                        prevEl.focus();
                    }
                }
                else if (e.keyCode == 39 || e.keyCode == 40) { // right or down
                    let nextEl = <HTMLAnchorElement>this.el.nextElementSibling;
                    if (nextEl) {
                        nextEl.focus();
                    }
                }
                else if (e.keyCode == 13) { // enter
                    this._onSelected();
                }

            });

            el.addEventListener('keydown', (e) => {
                e.preventDefault();

                if (e.keyCode == 9) {
                    return;
                }

            });

            return el;
        }

        private _onSelected() {

            if (this.onSelected) {
                this.onSelected();
            }

        }
    }

}