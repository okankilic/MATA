namespace MATA.Issues {
    export class IssuesController extends EntityBaseController {
        readonly focusElementSelector = '#Description';
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
                        Utils.showSuccess('İş başarılı bir şekilde oluşturuldu');
                        Utils.closeModal(true);
                    } else {
                        Utils.setModalContentHTML(response);
                    }

                }).fail(function (jqXHR: JQueryXHR) {
                    Utils.setModalContentHTML(jqXHR.responseText);
                });

                return false;
            });

            $(that.focusElementSelector).focus();
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
                    method: 'POST',
                    url: $form.attr('action'),
                    data: $form.serialize()
                }).done(function (response) {

                    if (response === "OK") {
                        Utils.showSuccess('İş başarılı bir şekilde silindi');
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
                        Utils.showSuccess('İş başarılı bir şekilde güncellendi');
                        Utils.closeModal(true);
                    } else {
                        Utils.setModalContentHTML(response);
                    }

                }).fail(function (jqXHR: JQueryXHR) {
                    Utils.setModalContentHTML(jqXHR.responseText);
                });

                return false;
            });

            $(that.focusElementSelector).focus().select();
        }
    }
}

var issuesController: MATA.Issues.IssuesController;

$(function () {
    issuesController = new MATA.Issues.IssuesController({
        controllerName: 'Issues',
        entityName: 'issues'
    });
    issuesController.initGridEvents();
})