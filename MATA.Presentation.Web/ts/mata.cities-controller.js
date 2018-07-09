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
    var Cities;
    (function (Cities) {
        var CitiesController = /** @class */ (function (_super) {
            __extends(CitiesController, _super);
            function CitiesController() {
                var _this = _super !== null && _super.apply(this, arguments) || this;
                _this.focusElementSelector = '#CountryName';
                return _this;
            }
            CitiesController.prototype.onOpenModalShown = function () {
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
                setTimeout(function () {
                    $(that.createFormSelector).find('input[type="text"]').first().focus();
                }, 1000);
            };
            CitiesController.prototype.onEditModalShown = function () {
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
                $(that.focusElementSelector).focus().select();
            };
            return CitiesController;
        }(MATA.EntityBaseController));
        Cities.CitiesController = CitiesController;
    })(Cities = MATA.Cities || (MATA.Cities = {}));
})(MATA || (MATA = {}));
var citiesController;
$(function () {
    citiesController = new MATA.Cities.CitiesController({
        controllerName: 'Cities',
        entityName: 'cities'
    });
    citiesController.initGridEvents();
});
//# sourceMappingURL=mata.cities-controller.js.map