create view dbo.vMailAccount as 
select ma.ID,
ma.MailID,
ma.ToCcBcc,
ma.AccountID,
a.FullName,
a.Email 
from dbo.MailAccount ma
join dbo.Account a on ma.AccountID = a.ID