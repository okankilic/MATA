create view dbo.vMailAttachment as
select a.ID,
a.EntityID as MailID,
a.AttachmentType,
a.[FileName],
a.FilePath
from dbo.Attachment a 
where a.EntityName = 'Mail'