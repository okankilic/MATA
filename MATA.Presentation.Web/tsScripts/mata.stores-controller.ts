module MATA.Stores {

    const _createFormSelector = '#mt-form-stores-create';

    const _focusElementSelector = '#ProjectID';

    export function openCreateModal() {

        Utils.openModal({
            ajax: {
                url: Utils.getAppPath('Stores/_Create'),
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
                            Utils.showSuccess('Şantiye başarılı bir şekilde oluşturuldu');
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

}