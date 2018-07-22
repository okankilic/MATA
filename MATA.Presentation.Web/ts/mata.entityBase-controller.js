var MATA;
(function (MATA) {
    var EntityBaseController = /** @class */ (function () {
        function EntityBaseController(options) {
            this.createFormSelector = '#mt-form-' + options.entityName + '-create';
            this.editFormSelector = '#mt-form-' + options.entityName + '-edit';
            this.deleteFormSelector = '#mt-form-' + options.entityName + '-delete';
            this.createModalLinkSelector = '#mt-link-' + options.entityName + '-create';
            this.editModalLinkSelector = '.mt-link-' + options.entityName + '-edit';
            this.createActionUrl = options.controllerName + '/_Create';
            this.editActionUrl = options.controllerName + '/_Edit';
        }
        EntityBaseController.prototype.openCreateModal = function (url) {
            if (url === void 0) { url = null; }
            if (!url) {
                url = MATA.Utils.getAppPath(that.createActionUrl);
            }
            var that = this;
            MATA.Utils.openModal({
                ajax: {
                    url: url,
                    data: null
                },
                onShown: function () {
                    if (that.onCreateModalShown) {
                        that.onCreateModalShown();
                    }
                    MATA.Utils.initSelects();
                }
            });
        };
        EntityBaseController.prototype.openEditModal = function (id) {
            var that = this;
            MATA.Utils.openModal({
                ajax: {
                    url: MATA.Utils.getAppPath(that.editActionUrl + '/' + id),
                    data: null
                },
                onShown: function () {
                    if (that.onEditModalShown) {
                        that.onEditModalShown();
                    }
                    MATA.Utils.initSelects();
                }
            });
        };
        EntityBaseController.prototype.initGridEvents = function () {
            var that = this;
            $(this.createModalLinkSelector).on('click', function (e) {
                e.preventDefault();
                that.openCreateModal(this.href);
                return false;
            });
            $(this.editModalLinkSelector).on('click', function (e) {
                e.preventDefault();
                var entityID = parseInt($(this).attr('data-entity-id'));
                that.openEditModal(entityID);
                return false;
            });
        };
        return EntityBaseController;
    }());
    MATA.EntityBaseController = EntityBaseController;
})(MATA || (MATA = {}));
//# sourceMappingURL=mata.entityBase-controller.js.map