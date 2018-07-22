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
    var Projects;
    (function (Projects) {
        var ProjectsController = /** @class */ (function (_super) {
            __extends(ProjectsController, _super);
            function ProjectsController() {
                var _this = _super !== null && _super.apply(this, arguments) || this;
                _this.focusElementSelector = '#ProjectName';
                return _this;
            }
            ProjectsController.prototype.onCreateModalShown = function () {
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
                            MATA.Utils.showSuccess('Proje başarılı bir şekilde oluşturuldu');
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
            ProjectsController.prototype.onEditModalShown = function () {
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
            return ProjectsController;
        }(MATA.EntityBaseController));
        Projects.ProjectsController = ProjectsController;
    })(Projects = MATA.Projects || (MATA.Projects = {}));
})(MATA || (MATA = {}));
var projectsController;
$(function () {
    projectsController = new MATA.Projects.ProjectsController({
        controllerName: 'Projects',
        entityName: 'projects'
    });
    projectsController.initGridEvents();
});
//# sourceMappingURL=mata.projects-controller.js.map