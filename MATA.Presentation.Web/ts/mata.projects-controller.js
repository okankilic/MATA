var MATA;
(function (MATA) {
    var Projects;
    (function (Projects) {
        var _createFormSelector = '#mt-form-projects-create';
        var _editFormSelector = '#mt-form-projects-edit';
        var _deleteFormSelector = '#mt-form-projects-delete';
        var _focusElementSelector = '#CountryID';
        function openCreateModal() {
            MATA.Utils.openModal({
                ajax: {
                    url: MATA.Utils.getAppPath('Projects/_Create'),
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
                                MATA.Utils.showSuccess('Proje başarılı bir şekilde oluşturuldu');
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
        Projects.openCreateModal = openCreateModal;
        function openEditModal(id) {
            MATA.Utils.openModal({
                ajax: {
                    url: MATA.Utils.getAppPath('Projects/_Edit/' + id),
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
                                MATA.Utils.showSuccess('Proje başarılı bir şekilde silindi');
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
                                MATA.Utils.showSuccess('Proje başarılı bir şekilde güncellendi');
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
                    $(_focusElementSelector).focus().select();
                }
            });
        }
        Projects.openEditModal = openEditModal;
    })(Projects = MATA.Projects || (MATA.Projects = {}));
})(MATA || (MATA = {}));
//# sourceMappingURL=mata.projects-controller.js.map