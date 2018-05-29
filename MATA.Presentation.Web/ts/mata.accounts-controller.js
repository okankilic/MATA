var MATA;
(function (MATA) {
    var Accounts;
    (function (Accounts) {
        var _createFormSelector = '#mt-form-accounts-create';
        var _editFormSelector = '#mt-form-accounts-edit';
        var _deleteFormSelector = '#mt-form-accounts-delete';
        var _forgotPasswordFormSelector = "#mt-form-accounts-forgot-password";
        function openCreateModal() {
            MATA.Utils.openModal({
                ajax: {
                    url: MATA.Utils.getAppPath('Accounts/_Create'),
                    data: null
                },
                onShown: function () {
                    MATA.Utils.validateForm(_createFormSelector);
                    $(_createFormSelector).submit(function (e) {
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
                }
            });
        }
        Accounts.openCreateModal = openCreateModal;
        function openEditModal(id) {
            MATA.Utils.openModal({
                ajax: {
                    url: MATA.Utils.getAppPath('Accounts/_Edit/' + id),
                    data: null
                },
                onShown: function () {
                    MATA.Utils.validateForm(_editFormSelector);
                    $(_deleteFormSelector).submit(function (e) {
                        e.preventDefault();
                        var $form = $(this), isFormValid = $form.valid();
                        if (!isFormValid) {
                            return false;
                        }
                        $.ajax({
                            method: 'GET',
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
                    $(_editFormSelector).submit(function (e) {
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
                }
            });
        }
        Accounts.openEditModal = openEditModal;
        function openForgotPasswordModal() {
            MATA.Utils.openModal({
                ajax: {
                    url: MATA.Utils.getAppPath('Accounts/_ForgotPassword'),
                    data: null
                },
                onShown: function () {
                    MATA.Utils.validateForm(_forgotPasswordFormSelector);
                    $(_forgotPasswordFormSelector).submit(function (e) {
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
                                MATA.Utils.showSuccess('Şifreniz email adresinize gönderilmiştir');
                                MATA.Utils.closeModal(false);
                            }
                            else {
                                MATA.Utils.setModalContentHTML(response);
                            }
                        }).fail(function (jqXHR) {
                            MATA.Utils.setModalContentHTML(jqXHR.responseText);
                        });
                        return false;
                    });
                    $(_forgotPasswordFormSelector + " #Email").focus();
                }
            });
        }
        Accounts.openForgotPasswordModal = openForgotPasswordModal;
    })(Accounts = MATA.Accounts || (MATA.Accounts = {}));
})(MATA || (MATA = {}));
//# sourceMappingURL=mata.accounts-controller.js.map