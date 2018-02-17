module MATA.Accounts {

    const _createFormSelector = '#mt-form-accounts-create';

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

}