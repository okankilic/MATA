using MATA.Data.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MATA.Presentation.Web.Models.Attachments
{
    public class AttachmentsCreateVM
    {
        public AttachmentDTO Attachment { get; set; }

        public HttpPostedFileBase AttachmentFile { get; set; }
    }
}