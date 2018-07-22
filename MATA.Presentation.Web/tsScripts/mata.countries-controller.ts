namespace MATA.Countries {

    export class CountriesController extends EntityBaseController {

        onCreateModalShown(): void {
            var that = this;

            Utils.validateForm(that.createFormSelector);

            $(that.createFormSelector).submit(function (e) {
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
                        Utils.showSuccess('Ülke başarılı bir şekilde oluşturuldu');
                        Utils.closeModal(true);
                    } else {
                        Utils.setModalContentHTML(response);
                    }

                }).fail(function (jqXHR: JQueryXHR) {
                    Utils.setModalContentHTML(jqXHR.responseText);
                });

                return false;
            });

            $("#CountryName").focus();
        }

        onEditModalShown(): void {
            var that = this;

            Utils.validateForm(that.editFormSelector);

            $(that.deleteFormSelector).submit(function (e) {
                e.preventDefault();

                var $form = $(this),
                    isFormValid = $form.valid();

                if (!isFormValid) {
                    return false;
                }

                $.ajax({
                    method: $form.attr('method'),
                    url: $form.attr('action'),
                    data: $form.serialize()
                }).done(function (response) {

                    if (response === "OK") {
                        Utils.showSuccess('Ülke başarılı bir şekilde silindi');
                        Utils.closeModal(true);
                    } else {
                        Utils.setModalContentHTML(response);
                    }

                }).fail(function (jqXHR: JQueryXHR) {
                    Utils.setModalContentHTML(jqXHR.responseText);
                });

                return false;
            });

            $(that.editFormSelector).submit(function (e) {
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
                        Utils.showSuccess('Ülke başarılı bir şekilde güncellendi');
                        Utils.closeModal(true);
                    } else {
                        Utils.setModalContentHTML(response);
                    }

                }).fail(function (jqXHR: JQueryXHR) {
                    Utils.setModalContentHTML(jqXHR.responseText);
                });

                return false;
            });

            $("#CountryName").focus().select();
        }
    }

}

var countriesController: MATA.Countries.CountriesController;

$(function () {

    countriesController = new MATA.Countries.CountriesController({
        controllerName: 'Countries',
        entityName: 'countries'
    });

    countriesController.initGridEvents();

});