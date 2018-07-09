module MATA {

    export abstract class EntityBaseController {

        readonly createFormSelector: string;
        readonly editFormSelector: string;
        readonly deleteFormSelector: string;

        readonly createModalLinkSelector: string;
        readonly editModalLinkSelector: string;

        readonly createActionUrl: string;
        readonly editActionUrl: string;

        constructor(options: IEntityBaseControllerOptions) {

            this.createFormSelector = '#mt-form-' + options.entityName + '-create';
            this.editFormSelector = '#mt-form-' + options.entityName + '-edit';
            this.deleteFormSelector = '#mt-form-' + options.entityName + '-delete';

            this.createModalLinkSelector = '#mt-link-' + options.entityName + '-create';
            this.editModalLinkSelector = '.mt-link-' + options.entityName + '-edit';

            this.createActionUrl = options.controllerName + '/_Create';
            this.editActionUrl = options.controllerName + '/_Edit';
        }

        openCreateModal() {

            var that = this;

            Utils.openModal({
                ajax: {
                    url: Utils.getAppPath(that.createActionUrl),
                    data: null
                },
                onShown: function () {

                    if (that.onOpenModalShown) {
                        that.onOpenModalShown();
                    }

                    Utils.initSelects();
                }
            });

        }

        openEditModal(id: number) {

            var that = this;

            Utils.openModal({
                ajax: {
                    url: Utils.getAppPath(that.editActionUrl + '/' + id),
                    data: null
                },
                onShown: function () {

                    if (that.onEditModalShown) {
                        that.onEditModalShown();
                    }

                    Utils.initSelects();
                }
            });

        }

        initGridEvents() {

            var that = this;

            $(this.createModalLinkSelector).on('click', function (e) {
                e.preventDefault();
                that.openCreateModal();
                return false;
            });

            $(this.editModalLinkSelector).on('click', function (e) {
                e.preventDefault();
                var entityID = parseInt($(this).attr('data-entity-id'));
                that.openEditModal(entityID);
                return false;
            });

        }

        abstract onOpenModalShown(): void;
        abstract onEditModalShown(): void;
    }

    export interface IEntityBaseControllerOptions {
        entityName: string;
        controllerName: string;
    }
}