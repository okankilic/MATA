var MATA;
(function (MATA) {
    var Stores;
    (function (Stores) {
        var _createFormSelector = '#mt-form-stores-create';
        var _focusElementSelector = '#ProjectID';
        function openCreateModal() {
            MATA.Utils.openModal({
                ajax: {
                    url: MATA.Utils.getAppPath('Stores/_Create'),
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
                                MATA.Utils.showSuccess('Şantiye başarılı bir şekilde oluşturuldu');
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
                    $(_focusElementSelector).focus();
                }
            });
        }
        Stores.openCreateModal = openCreateModal;
    })(Stores = MATA.Stores || (MATA.Stores = {}));
})(MATA || (MATA = {}));
//# sourceMappingURL=mata.stores-controller.js.map