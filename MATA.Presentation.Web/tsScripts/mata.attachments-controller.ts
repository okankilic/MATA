namespace MATA.Attachments {

    export class AttachmentsController extends EntityBaseController {

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

                var formData = new FormData(this);

                $.ajax({
                    method: 'POST',
                    url: $form.attr('action'),
                    data: formData,
                    processData: false,
                    contentType: false
                }).done(function (response) {

                    if (response === "OK") {
                        Utils.showSuccess('Dosya başarılı bir şekilde yüklendi');
                        Utils.closeModal(true);
                    } else {
                        Utils.setModalContentHTML(response);
                    }

                }).fail(function (jqXHR: JQueryXHR) {
                    Utils.setModalContentHTML(jqXHR.responseText);
                });

                return false;
            });

            $("#Attachment_AttachmentType").focus();

        }

        onEditModalShown(): void {
            throw new Error("Method not implemented.");
        }

    }
}

var attachmentsController: MATA.Attachments.AttachmentsController;

$(function () {

    attachmentsController = new MATA.Attachments.AttachmentsController({
        controllerName: 'Attachments',
        entityName: 'attachments'
    });

    attachmentsController.initGridEvents();

});
