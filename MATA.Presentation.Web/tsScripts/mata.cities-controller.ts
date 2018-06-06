module MATA.Cities {

    const _createFormSelector = '#mt-form-cities-create';
    const _editFormSelector = '#mt-form-cities-edit';
    const _deleteFormSelector = '#mt-form-cities-delete';

    export function openCreateModal() {

        Utils.openModal({
            ajax: {
                url: Utils.getAppPath('Cities/_Create'),
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
                            Utils.showSuccess('Şehir başarılı bir şekilde oluşturuldu');
                            Utils.closeModal(true);
                        } else {
                            Utils.setModalContentHTML(response);
                        }

                    }).fail(function (jqXHR: JQueryXHR) {
                        Utils.setModalContentHTML(jqXHR.responseText);
                    });

                    return false;
                });

                $("#CountryID").focus();

            }
        });

    }

    export function openEditModal(id: number) {

        Utils.openModal({
            ajax: {
                url: Utils.getAppPath('Cities/_Edit/' + id),
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
                            Utils.showSuccess('Şehir başarılı bir şekilde silindi');
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
                            Utils.showSuccess('Şehir başarılı bir şekilde güncellendi');
                            Utils.closeModal(true);
                        } else {
                            Utils.setModalContentHTML(response);
                        }

                    }).fail(function (jqXHR: JQueryXHR) {
                        Utils.setModalContentHTML(jqXHR.responseText);
                    });

                    return false;
                });

                $("#CountryID").focus().select();

            }
        });

    }

}