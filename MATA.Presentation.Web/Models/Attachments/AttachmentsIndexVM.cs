using MATA.Data.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MATA.Presentation.Web.Models.Attachments
{
    public class AttachmentsIndexVM: BaseIndexViewModel
    {
        public IEnumerable<AttachmentDTO> Attachments { get; set; }
    }
}