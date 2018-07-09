var MATA;
(function (MATA) {
    var Utils;
    (function (Utils) {
        Utils.APP_BASE_URL = '';
        var _genericModalSelector = "#mata-generic-modal";
        function generateGuid() {
            function s4() {
                return Math.floor((1 + Math.random()) * 0x10000).toString(16).substring(1);
            }
            return (s4() + s4() + '-' + s4() + '-4' + s4().substring(0, 3) + '-' + s4() + '-' + s4() + s4() + s4()).toLowerCase();
        }
        Utils.generateGuid = generateGuid;
        function openModal(options) {
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
                }
                else {
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
        Utils.openModal = openModal;
        function setModalContentHTML(html) {
            $(_genericModalSelector + ' .modal-content').html(html);
        }
        Utils.setModalContentHTML = setModalContentHTML;
        function closeModal(reload) {
            if (reload === void 0) { reload = false; }
            $(_genericModalSelector).on('hidden.bs.modal', function () {
                $(_genericModalSelector).off('hidden.bs.modal');
                if (reload) {
                    setTimeout(function () {
                        location.reload();
                    }, 3000);
                }
            }).modal('hide');
        }
        Utils.closeModal = closeModal;
        function getAppPath(path) {
            return Utils.APP_BASE_URL + '/' + path;
        }
        Utils.getAppPath = getAppPath;
        function validateForm(formSelector) {
            $.validator.unobtrusive.parse(formSelector);
        }
        Utils.validateForm = validateForm;
        function showAlert(message) {
            _showNoty('alert', message);
        }
        Utils.showAlert = showAlert;
        function showSuccess(message) {
            _showNoty('success', message);
        }
        Utils.showSuccess = showSuccess;
        function showWarning(message) {
            _showNoty('warning', message);
        }
        Utils.showWarning = showWarning;
        function showError(message) {
            _showNoty('error', message);
        }
        Utils.showError = showError;
        function showInfo(message) {
            _showNoty('info', message);
        }
        Utils.showInfo = showInfo;
        function _showNoty(type, message, timeout) {
            if (timeout === void 0) { timeout = 3000; }
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
        function hideElement(selector) {
            $(selector).addClass('hidden');
        }
        Utils.hideElement = hideElement;
        function showElement(selector) {
            $(selector).removeClass('hidden');
        }
        Utils.showElement = showElement;
        function initSelects() {
            $('[data-select]').each(function (_i, _el) {
                var s = new MATA.Select.AjaxSelect({
                    el: _el
                });
            });
        }
        Utils.initSelects = initSelects;
    })(Utils = MATA.Utils || (MATA.Utils = {}));
})(MATA || (MATA = {}));
//# sourceMappingURL=mata.utils.js.map