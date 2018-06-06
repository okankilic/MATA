module MATA.Projects {

    const _createFormSelector = '#mt-form-projects-create';
    const _editFormSelector = '#mt-form-projects-edit';
    const _deleteFormSelector = '#mt-form-projects-delete';

    const _focusElementSelector = '#CountryID';

    export function openCreateModal() {

        Utils.openModal({
            ajax: {
                url: Utils.getAppPath('Projects/_Create'),
                data: null
            },
            onShown: function () {

                Utils.validateForm(_createFormSelector);

                $(_createFormSelector).submit(function (e) {
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
                            Utils.showSuccess('Proje başarılı bir şekilde oluşturuldu');
                            Utils.closeModal(true);
                        } else {
                            Utils.setModalContentHTML(response);
                        }

                    }).fail(function (jqXHR: JQueryXHR) {
                        Utils.setModalContentHTML(jqXHR.responseText);
                    });

                    return false;
                });

                $(_focusElementSelector).focus();

            }
        });

    }

    export function openEditModal(id: number) {

        Utils.openModal({
            ajax: {
                url: Utils.getAppPath('Projects/_Edit/' + id),
                data: null
            },
            onShown: function () {

                Utils.validateForm(_editFormSelector);

                $(_deleteFormSelector).submit(function (e) {
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
                            Utils.showSuccess('Proje başarılı bir şekilde silindi');
                            Utils.closeModal(true);
                        } else {
                            Utils.setModalContentHTML(response);
                        }

                    }).fail(function (jqXHR: JQueryXHR) {
                        Utils.setModalContentHTML(jqXHR.responseText);
                    });

                    return false;
                });

                $(_editFormSelector).submit(function (e) {
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
                            Utils.showSuccess('Proje başarılı bir şekilde güncellendi');
                            Utils.closeModal(true);
                        } else {
                            Utils.setModalContentHTML(response);
                        }

                    }).fail(function (jqXHR: JQueryXHR) {
                        Utils.setModalContentHTML(jqXHR.responseText);
                    });

                    return false;
                });

                $(_focusElementSelector).focus().select();

            }
        });

    }

}