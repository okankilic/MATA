module MATA.Accounts {

    const _createFormSelector = '#mt-form-accounts-create';
    const _editFormSelector = '#mt-form-accounts-edit';
    const _deleteFormSelector = '#mt-form-accounts-delete';

    export function openCreateModal() {

        Utils.openModal({
            ajax: {
                url: Utils.getAppPath('Accounts/_Create'),
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
        });

    }

    export function openEditModal(id: number) {

        Utils.openModal({
            ajax: {
                url: Utils.getAppPath('Accounts/_Edit/' + id),
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
                        method: 'GET',
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
        });

    }

}