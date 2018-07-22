namespace MATA.Accounts {

    export class AccountsController extends EntityBaseController {

        readonly forgotPasswordFormSelector: string;
        readonly forgotPasswordLinkSelector: string;
        readonly forgotPasswordActionUrl: string;

        constructor(options: IEntityBaseControllerOptions) {
            super(options);

            this.forgotPasswordFormSelector = '#mt-form-' + options.entityName + '-forgot-password';
            this.forgotPasswordLinkSelector = '#mt-link-' + options.entityName + '-forgot-password';
            this.forgotPasswordActionUrl = options.controllerName + '/_ForgotPassword';
        }

        onCreateModalShown() {

            var that = this;

            Utils.validateForm(that.createFormSelector);

            $('#Password').on('change', function (e) {
                $('#ExPassword').val(this.value);
            });

            $(that.createFormSelector).submit(function (e) {
                e.preventDefault();

                var $form = $(this),
                    isFormValid = $form.valid();

                if (!isFormValid) {
                    return false;
                }

                $.ajax({
                    method: 'POST',
                    url: $form.attr('action'),
                    data: $form.serialize()
                }).done(function (response) {

                    if (response === "OK") {
                        Utils.showSuccess('Hesap başarılı bir şekilde oluşturuldu');
                        Utils.closeModal(true);
                    } else {
                        Utils.setModalContentHTML(response);
                    }

                }).fail(function (jqXHR: JQueryXHR) {
                    Utils.setModalContentHTML(jqXHR.responseText);
                });

                return false;
            });

            $("#FullName").focus();
        }

        onEditModalShown() {

            var that = this;

            Utils.validateForm(that.editFormSelector);

            $(that.deleteFormSelector).submit(function (e) {
                e.preventDefault();

                var $form = $(this),
                    isFormValid = $form.valid();

                if (!isFormValid) {
                    return false;
                }

                $.ajax({
                    method: $form.attr('method'),
                    url: $form.attr('action'),
                    data: $form.serialize()
                }).done(function (response) {

                    if (response === "OK") {
                        Utils.showSuccess('Hesap başarılı bir şekilde silindi');
                        Utils.closeModal(true);
                    } else {
                        Utils.setModalContentHTML(response);
                    }

                }).fail(function (jqXHR: JQueryXHR) {
                    Utils.setModalContentHTML(jqXHR.responseText);
                });

                return false;
            });

            $(that.editFormSelector).submit(function (e) {
                e.preventDefault();

                var $form = $(this),
                    isFormValid = $form.valid();

                if (!isFormValid) {
                    return false;
                }

                $.ajax({
                    method: 'POST',
                    url: $form.attr('action'),
                    data: $form.serialize()
                }).done(function (response) {

                    if (response === "OK") {
                        Utils.showSuccess('Hesap başarılı bir şekilde güncellendi');
                        Utils.closeModal(true);
                    } else {
                        Utils.setModalContentHTML(response);
                    }

                }).fail(function (jqXHR: JQueryXHR) {
                    Utils.setModalContentHTML(jqXHR.responseText);
                });

                return false;
            });

            $("#FullName").focus().select();
        }

        openForgotPasswordModal() {

            var that = this;

            Utils.openModal({
                ajax: {
                    url: Utils.getAppPath(that.forgotPasswordActionUrl),
                    data: null
                },
                onShown: function () {

                    Utils.validateForm(that.forgotPasswordFormSelector);

                    $(that.forgotPasswordFormSelector).on('submit', function (e) {
                        e.preventDefault();

                        var $form = $(this),
                            isFormValid = $form.valid();

                        if (!isFormValid) {
                            return false;
                        }

                        $.ajax({
                            method: $form.attr('method'),
                            url: $form.attr('action'),
                            data: $form.serialize()
                        }).done(function (response) {

                            if (response === "OK") {
                                Utils.showSuccess('Şifreniz e-mail adresinize gönderilmiştir');
                                Utils.closeModal(true);
                            } else {
                                Utils.setModalContentHTML(response);
                            }

                        }).fail(function (jqXHR: JQueryXHR) {
                            Utils.setModalContentHTML(jqXHR.responseText);
                        });

                        return false;
                    });

                    $(that.forgotPasswordFormSelector).find('#Email').focus();
                }
            })
        }
    }
}

var accountsController: MATA.Accounts.AccountsController;

$(function () {

    accountsController = new MATA.Accounts.AccountsController({
        entityName: 'accounts',
        controllerName: 'Accounts'
    });

    accountsController.initGridEvents();

})