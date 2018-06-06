var MATA;
(function (MATA) {
    var Countries;
    (function (Countries) {
        var _createFormSelector = '#mt-form-countries-create';
        var _editFormSelector = '#mt-form-countries-edit';
        var _deleteFormSelector = '#mt-form-countries-delete';
        function openCreateModal() {
            MATA.Utils.openModal({
                ajax: {
                    url: MATA.Utils.getAppPath('Countries/_Create'),
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
                                MATA.Utils.showSuccess('Ülke başarılı bir şekilde oluşturuldu');
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
                    $("#CountryName").focus();
                }
            });
        }
        Countries.openCreateModal = openCreateModal;
        function openEditModal(id) {
            MATA.Utils.openModal({
                ajax: {
                    url: MATA.Utils.getAppPath('Countries/_Edit/' + id),
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
                            method: 'POST',
                            url: $form.attr('action'),
                            data: $form.serialize()
                        }).done(function (response) {
                            if (response === "OK") {
                                MATA.Utils.showSuccess('Ülke başarılı bir şekilde silindi');
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
                                MATA.Utils.showSuccess('Ülke başarılı bir şekilde güncellendi');
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
                    $("#CountryName").focus().select();
                }
            });
        }
        Countries.openEditModal = openEditModal;
    })(Countries = MATA.Countries || (MATA.Countries = {}));
})(MATA || (MATA = {}));
//# sourceMappingURL=mata.countries-controller.js.map