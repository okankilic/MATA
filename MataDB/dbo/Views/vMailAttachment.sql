create view dbo.vMailAttachment as
select a.ID,
a.MailID,
a.AttachmentType,
a.[FileName],
a.FilePath
from dbo.Attachment a 
where a.MailID is not null