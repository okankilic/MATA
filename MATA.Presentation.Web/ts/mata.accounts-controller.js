var MATA;
(function (MATA) {
    var Accounts;
    (function (Accounts) {
        var _createFormSelector = '#mt-form-accounts-create';
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
    })(Accounts = MATA.Accounts || (MATA.Accounts = {}));
})(MATA || (MATA = {}));
//# sourceMappingURL=mata.accounts-controller.js.map