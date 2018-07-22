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
    var Stores;
    (function (Stores) {
        var StoresController = /** @class */ (function (_super) {
            __extends(StoresController, _super);
            function StoresController() {
                var _this = _super !== null && _super.apply(this, arguments) || this;
                _this.focusElementSelector = '#StoreName';
                return _this;
            }
            StoresController.prototype.onCreateModalShown = function () {
                var that = this;
                MATA.Utils.validateForm(that.createFormSelector);
                //$('#StoreID').change(function (e) {
                //    e.preventDefault();
                //    var $el = $(this),
                //        storeID = parseInt($el.val()),
                //        afterStoreSelectContainer = '#after-store-select';
                //    if (storeID) {
                //        Utils.showElement(afterStoreSelectContainer);
                //    } else {
                //        Utils.hideElement(afterStoreSelectContainer);
                //    }
                //});
                //$('#CityID').change(function (e) {
                //    e.preventDefault();
                //    var $el = $(this),
                //        city = parseInt($el.val()),
                //        afterCitySelectContainer = '#after-city-select';
                //    if (city) {
                //        Utils.showElement(afterCitySelectContainer);
                //    } else {
                //        Utils.hideElement(afterCitySelectContainer);
                //    }
                //});
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
                            MATA.Utils.showSuccess('Şantiye başarılı bir şekilde oluşturuldu');
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
                $(that.focusElementSelector).focus();
            };
            StoresController.prototype.onEditModalShown = function () {
                var that = this;
                MATA.Utils.validateForm(that.editFormSelector);
                $(that.deleteFormSelector).submit(function (e) {
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
                $(that.focusElementSelector).focus().select();
            };
            return StoresController;
        }(MATA.EntityBaseController));
        Stores.StoresController = StoresController;
    })(Stores = MATA.Stores || (MATA.Stores = {}));
})(MATA || (MATA = {}));
var storesController;
$(function () {
    storesController = new MATA.Stores.StoresController({
        controllerName: 'Stores',
        entityName: 'stores'
    });
    storesController.initGridEvents();
});
//# sourceMappingURL=mata.stores-controller.js.map