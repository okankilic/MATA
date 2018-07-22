var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var MATA;
(function (MATA) {
    var Countries;
    (function (Countries) {
        var CountriesController = /** @class */ (function (_super) {
            __extends(CountriesController, _super);
            function CountriesController() {
                return _super !== null && _super.apply(this, arguments) || this;
            }
            CountriesController.prototype.onCreateModalShown = function () {
                var that = this;
                MATA.Utils.validateForm(that.createFormSelector);
                $(that.createFormSelector).submit(function (e) {
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
            };
            CountriesController.prototype.onEditModalShown = function () {
                var that = this;
                MATA.Utils.validateForm(that.editFormSelector);
                $(that.deleteFormSelector).submit(function (e) {
                    e.preventDefault();
                    var $form = $(this), isFormValid = $form.valid();
                    if (!isFormValid) {
                        return false;
                    }
                    $.ajax({
                        method: $form.attr('method'),
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
                $(that.editFormSelector).submit(function (e) {
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
            };
            return CountriesController;
        }(MATA.EntityBaseController));
        Countries.CountriesController = CountriesController;
    })(Countries = MATA.Countries || (MATA.Countries = {}));
})(MATA || (MATA = {}));
var countriesController;
$(function () {
    countriesController = new MATA.Countries.CountriesController({
        controllerName: 'Countries',
        entityName: 'countries'
    });
    countriesController.initGridEvents();
});
//# sourceMappingURL=mata.countries-controller.js.map