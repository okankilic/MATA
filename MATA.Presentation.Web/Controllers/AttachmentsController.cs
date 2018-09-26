using MATA.BL.Interfaces;
using MATA.Data.Common.Enums;
using MATA.Data.DTO.Interfaces;
using MATA.Data.DTO.Models;
using MATA.Data.Repositories.Interfaces;
using MATA.Infrastructure.Utils.Helpers;
using MATA.Presentation.Web.Base;
using MATA.Presentation.Web.Models.Attachments;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MATA.Presentation.Web.Controllers
{
    public class AttachmentsController : CustomControllerBase
    {
        readonly IAttachmentBL attachmentBL;
        readonly IDTOFactory<AttachmentDTO> dtoFactory;

        public AttachmentsController(IUnitOfWorkFactory uowFactory, 
            ILogger logger,
            IBLFactory blFactory,
            IDTOFactory<AttachmentDTO> dtoFactory) : base(uowFactory, logger)
        {
            attachmentBL = blFactory.CreateProxy<IAttachmentBL>();
            this.dtoFactory = dtoFactory;
        }
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _Create(string entityName, int entityID)
        {
            var vm = new AttachmentsCreateVM
            {
                Attachment = new AttachmentDTO
                {
                    EntityName = entityName,
                    EntityID = entityID
                }
            };

            return PartialView(vm);
        }

        [HttpPost]
        public ActionResult Create(AttachmentsCreateVM vm)
        {
            if (vm.AttachmentFile == null)
            {
                throw new Exception("Lütfen bir dosya seçiniz");
            }

            try
            {
                using (var uow = uowFactory.CreateNew())
                {
                    var fileName = Guid.NewGuid() + Path.GetExtension(vm.AttachmentFile.FileName);

                    vm.Attachment.FileName = vm.AttachmentFile.FileName;
                    vm.Attachment.FilePath = PathHelper.GetAttachmentFilePath(fileName);

                    attachmentBL.Create(vm.Attachment, TokenString, uow);

                    vm.AttachmentFile.SaveAs(vm.Attachment.FilePath);

                    uow.Commit();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return new ContentResult
            {
                Content = "OK"
            };
        }

        public ActionResult Download(int id)
        {
            string filePath;

            using (var uow = uowFactory.CreateNew())
            {
                var dto = attachmentBL.Get(id, uow);

                filePath = PathHelper.GetAttachmentFilePath(dto.FilePath);
            }

            var contentDisposition = new System.Net.Mime.ContentDisposition
            {
                FileName = Path.GetFileName(filePath),
                Inline = true,
            };

            Response.AppendHeader("Content-Disposition", contentDisposition.ToString());

            return File(System.IO.File.ReadAllBytes(filePath), MimeMapping.GetMimeMapping(filePath));
        }

        public async Task<ActionResult> _ProjectAttachments(int projectID, int page = 1)
        {
            AttachmentsIndexVM vm;

            ViewBag.ProjectID = projectID;

            using (var uow = uowFactory.CreateNew())
            {
                vm = new AttachmentsIndexVM
                {
                    PageSize = DefaultPageSize10,
                    TotalCount = attachmentBL.GetProjectAttachmentsCount(projectID, uow),
                    Attachments = await attachmentBL.GetProjectAttachments(projectID, (page - 1) * DefaultPageSize10, DefaultPageSize10, uow)
                };
            }

            return PartialView(vm);
        }

        public async Task<ActionResult> _StoreAttachments(int storeID, int page = 1)
        {
            AttachmentsIndexVM vm;

            ViewBag.StoreID = storeID;

            using (var uow = uowFactory.CreateNew())
            {
                vm = new AttachmentsIndexVM
                {
                    PageSize = DefaultPageSize10,
                    TotalCount = attachmentBL.GetStoreAttachmentsCount(storeID, uow),
                    Attachments = await attachmentBL.GetStoreAttachments(storeID, (page - 1) * DefaultPageSize10, DefaultPageSize10, uow)
                };
            }

            return PartialView(vm);
        }

        public async Task<ActionResult> _IssueAttachments(int issueID, int page = 1)
        {
            AttachmentsIndexVM vm;

            ViewBag.IssueID = issueID;

            using (var uow = uowFactory.CreateNew())
            {
                vm = new AttachmentsIndexVM
                {
                    PageSize = DefaultPageSize10,
                    TotalCount = attachmentBL.GetIssueAttachmentsCount(issueID, uow),
                    Attachments = await attachmentBL.GetIssueAttachments(issueID, (page - 1) * DefaultPageSize10, DefaultPageSize10, uow)
                };
            }

            return PartialView(vm);
        }
    }
}