module MATA.Select {

    export class AjaxSelect {

        private readonly CONTAINER_CLASS_NAME = "mt-select-container";
        private readonly HEADING_CLASS_NAME = "mt=select-heading";
        private readonly BODY_CLASS_NAME = "mt-select-body";

        private _el: HTMLInputElement;

        private _hiddenEl: HTMLInputElement;

        private _url: string;
        private _textFieldName: string;
        private _valueFieldName: string;

        private _loadTimeoutHandle = 0;

        private _loadTimeout = 500;

        //private _isLoaded = false;

        private _reload = false;

        constructor(options: IAjaxSelectOptions) {

            this._hiddenEl = options.el;

            this._url = this._hiddenEl.getAttribute("data-url");
            this._textFieldName = this._hiddenEl.getAttribute("data-text-field");
            this._valueFieldName = this._hiddenEl.getAttribute("data-value-field");

            this.createInputElement();

            this.initEvents();
        }

        initEvents() {

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

        }

        clear() {

            var container = this._el.nextElementSibling;

            if (!container) {
                return;
            }

            var body = container.lastChild;

            while (body.firstChild) {

                var el = (<HTMLElement>(body.firstChild));

                if (el.hasAttribute("selected")) {
                    this._el.value = el.innerText;
                    this._hiddenEl.value = el.getAttribute('data-val');
                }

                body.removeChild(body.firstChild);
            }

            container.remove();

            //this._isLoaded = false;
        }

        load() {

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
            }).done(function (data: any[]) {

                if (data.length) {
                    var div = that.createSelectList(data);
                    that._el.parentElement.appendChild(div);
                }

            }).fail(function (err) {

            });

        }

        private createInputElement() {

            this._el = document.createElement('input');
            this._el.id = Utils.generateGuid();
            this._el.classList.add('form-control');
            this._el.setAttribute('type', 'text');

            this._hiddenEl.parentElement.appendChild(this._el);

        }

        private createSelectList(data: any[]) {

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

        }

        private createSelectListItem(item) {

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
        }

        //onSelect(el: HTMLLIElement) {

        //    this._el.innerText = el.innerText;

        //}
    }

    export interface IAjaxSelectOptions {
        el: HTMLInputElement
    }

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

}