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
    var Attachments;
    (function (Attachments) {
        var AttachmentsController = /** @class */ (function (_super) {
            __extends(AttachmentsController, _super);
            function AttachmentsController() {
                return _super !== null && _super.apply(this, arguments) || this;
            }
            AttachmentsController.prototype.onCreateModalShown = function () {
                var that = this;
                MATA.Utils.validateForm(that.createFormSelector);
                $(that.createFormSelector).submit(function (e) {
                    e.preventDefault();
                    var $form = $(this), isFormValid = $form.valid();
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
                            MATA.Utils.showSuccess('Dosya başarılı bir şekilde yüklendi');
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
                $("#Attachment_AttachmentType").focus();
            };
            AttachmentsController.prototype.onEditModalShown = function () {
                throw new Error("Method not implemented.");
            };
            return AttachmentsController;
        }(MATA.EntityBaseController));
        Attachments.AttachmentsController = AttachmentsController;
    })(Attachments = MATA.Attachments || (MATA.Attachments = {}));
})(MATA || (MATA = {}));
var attachmentsController;
$(function () {
    attachmentsController = new MATA.Attachments.AttachmentsController({
        controllerName: 'Attachments',
        entityName: 'attachments'
    });
    attachmentsController.initGridEvents();
});
//# sourceMappingURL=mata.attachments-controller.js.map