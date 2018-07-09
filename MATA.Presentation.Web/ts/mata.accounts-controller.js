var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var MATA;
(function (MATA) {
    var Accounts;
    (function (Accounts) {
        var AccountsController = /** @class */ (function (_super) {
            __extends(AccountsController, _super);
            function AccountsController(options) {
                var _this = _super.call(this, options) || this;
                _this.forgotPasswordLinkSelector = '#mt-link-' + options.entityName + '-forgot-password';
                _this.forgotPasswordActionUrl = options.controllerName + '/_ForgotPassword';
                return _this;
            }
            AccountsController.prototype.onOpenModalShown = function () {
                var that = this;
                MATA.Utils.validateForm(that.createFormSelector);
                $('#Password').on('change', function (e) {
                    $('#ExPassword').val(this.value);
                });
                $(that.createFormSelector).submit(function (e) {
                    e.preventDefault();
                    var $form = $(this), isFormValid = $form.valid();
                    if (!isFormValid) {
                        return false;
                    }
                    $.ajax({
                        method: 'POST',
                        url: $form.attr('action'),
                        data: $form.serialize()
                    }).done(function (response) {
                        if (response === "OK") {
                            MATA.Utils.showSuccess('Hesap başarılı bir şekilde oluşturuldu');
                            MATA.Utils.closeModal(true);
                        }
                        else {
                            MATA.Utils.setModalContentHTML(response);
                        }
                    }).fail(function (jqXHR) {
                        MATA.Utils.setModalContentHTML(jqXHR.responseText);
                    });
                    return false;
                });
                $("#FullName").focus();
            };
            AccountsController.prototype.onEditModalShown = function () {
                var that = this;
                MATA.Utils.validateForm(that.editFormSelector);
                $(that.deleteFormSelector).submit(function (e) {
                    e.preventDefault();
                    var $form = $(this), isFormValid = $form.valid();
                    if (!isFormValid) {
                        return false;
                    }
                    $.ajax({
                        method: $form.attr('method'),
                        url: $form.attr('action'),
                        data: $form.serialize()
                    }).done(function (response) {
                        if (response === "OK") {
                            MATA.Utils.showSuccess('Hesap başarılı bir şekilde silindi');
                            MATA.Utils.closeModal(true);
                        }
                        else {
                            MATA.Utils.setModalContentHTML(response);
                        }
                    }).fail(function (jqXHR) {
                        MATA.Utils.setModalContentHTML(jqXHR.responseText);
                    });
                    return false;
                });
                $(that.editFormSelector).submit(function (e) {
                    e.preventDefault();
                    var $form = $(this), isFormValid = $form.valid();
                    if (!isFormValid) {
                        return false;
                    }
                    $.ajax({
                        method: 'POST',
                        url: $form.attr('action'),
                        data: $form.serialize()
                    }).done(function (response) {
                        if (response === "OK") {
                            MATA.Utils.showSuccess('Hesap başarılı bir şekilde güncellendi');
                            MATA.Utils.closeModal(true);
                        }
                        else {
                            MATA.Utils.setModalContentHTML(response);
                        }
                    }).fail(function (jqXHR) {
                        MATA.Utils.setModalContentHTML(jqXHR.responseText);
                    });
                    return false;
                });
                $("#FullName").focus().select();
            };
            AccountsController.prototype.openForgotPasswordModal = function () {
                var that = this;
                MATA.Utils.openModal({
                    ajax: {
                        url: MATA.Utils.getAppPath(that.forgotPasswordActionUrl),
                        data: null
                    },
                    onShown: function () {
                    }
                });
            };
            return AccountsController;
        }(MATA.EntityBaseController));
        Accounts.AccountsController = AccountsController;
    })(Accounts = MATA.Accounts || (MATA.Accounts = {}));
})(MATA || (MATA = {}));
var accountsController;
$(function () {
    accountsController = new MATA.Accounts.AccountsController({
        entityName: 'accounts',
        controllerName: 'Accounts'
    });
    accountsController.initGridEvents();
});
//# sourceMappingURL=mata.accounts-controller.js.map