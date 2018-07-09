module MATA.Utils {

    export var APP_BASE_URL: string = '';

    const _genericModalSelector = "#mata-generic-modal";

    export function generateGuid() {

        function s4() {
            return Math.floor((1 + Math.random()) * 0x10000).toString(16).substring(1);
        }

        return (s4() + s4() + '-' + s4() + '-4' + s4().substring(0, 3) + '-' + s4() + '-' + s4() + s4() + s4()).toLowerCase();
    }

    export function openModal(options: ModalOptions) {

        if (options.html) {
            setModalContentHTML(options.html);
        }

        $(_genericModalSelector).on('show.bs.modal', function () {

            $(_genericModalSelector).off('show.bs.modal');

            if (options.ajax) {

                $.ajax({
                    method: 'GET',
                    url: options.ajax.url,
                    data: options.ajax.data
                }).then(function (data, textStatus, jqXHR) {

                    if (jqXHR.status == 200) {
                        setModalContentHTML(data);
                    }

                }, function (jqXHR, textStatus, errorThrown) {

                    debugger;

                });

            } else {

            }

        }).on('shown.bs.modal', function () {

            $(_genericModalSelector).off('shown.bs.modal');

            if (options.onShown) {
                options.onShown();
            }

        }).on('hide.bs.modal', function () {

            $(_genericModalSelector).off('hide.bs.modal');

        }).on('hidden.bs.modal', function () {

            $(_genericModalSelector).off('hidden.bs.modal');

            if (options.onHidden) {
                options.onHidden();
            }

        }).modal({
            backdrop: 'static',
            keyboard: false,
            show: true
        });

    }

    export function setModalContentHTML(html: string) {

        $(_genericModalSelector + ' .modal-content').html(html);

    }

    export function closeModal(reload = false) {
        
        $(_genericModalSelector).on('hidden.bs.modal', function () {

            $(_genericModalSelector).off('hidden.bs.modal');

            if (reload) {
                setTimeout(function () {
                    location.reload();
                }, 3000);
            }

        }).modal('hide');

    }

    export function getAppPath(path: string): string {
        return APP_BASE_URL + '/' + path;
    }

    export function validateForm(formSelector: string) {
        $.validator.unobtrusive.parse(formSelector);
    }

    export function showAlert(message: string) {
        _showNoty('alert', message);
    }

    export function showSuccess(message: string) {
        _showNoty('success', message);
    }

    export function showWarning(message: string) {
        _showNoty('warning', message);
    }

    export function showError(message: string) {
        _showNoty('error', message);
    }

    export function showInfo(message: string) {
        _showNoty('info', message);
    }

    function _showNoty(type: string, message: string, timeout = 3000) {

        noty({
            animation: {
                open: 'animated bounceInRight',
                close: 'animated bounceOutRight'
            },
            type: type,
            layout: 'topRight',
            text: message,
            theme: 'relax',
            timeout: timeout
        });

    }

    export function hideElement(selector: string) {
        $(selector).addClass('hidden');
    }

    export function showElement(selector: string) {
        $(selector).removeClass('hidden');
    }

    export function initSelects() {

        $('[data-select]').each(function (_i, _el) {

            var s = new Select.AjaxSelect({
                el: <HTMLInputElement>_el
            });

        });

    }

    export interface ModalOptions {
        html?: string,
        ajax: {
            url: string,
            data: any
        },
        onShown?: () => void,
        onHidden?: () => void
    }
}