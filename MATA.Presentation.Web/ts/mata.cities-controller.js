var MATA;
(function (MATA) {
    var Cities;
    (function (Cities) {
        var _createFormSelector = '#mt-form-cities-create';
        var _editFormSelector = '#mt-form-cities-edit';
        var _deleteFormSelector = '#mt-form-cities-delete';
        function openCreateModal() {
            MATA.Utils.openModal({
                ajax: {
                    url: MATA.Utils.getAppPath('Cities/_Create'),
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
                                MATA.Utils.showSuccess('Şehir başarılı bir şekilde oluşturuldu');
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
                    $("#CountryID").focus();
                }
            });
        }
        Cities.openCreateModal = openCreateModal;
        function openEditModal(id) {
            MATA.Utils.openModal({
                ajax: {
                    url: MATA.Utils.getAppPath('Cities/_Edit/' + id),
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
                                MATA.Utils.showSuccess('Şehir başarılı bir şekilde silindi');
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
                                MATA.Utils.showSuccess('Şehir başarılı bir şekilde güncellendi');
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
                    $("#CountryID").focus().select();
                }
            });
        }
        Cities.openEditModal = openEditModal;
    })(Cities = MATA.Cities || (MATA.Cities = {}));
})(MATA || (MATA = {}));
//# sourceMappingURL=mata.cities-controller.js.map