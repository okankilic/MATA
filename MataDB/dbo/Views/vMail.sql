CREATE VIEW [dbo].[vMail]
	AS SELECT m.ID,
	m.IsBodyHtml,
	m.MailBody,
	m.[State],
	m.[Subject],
	m.TryCount,
	m.LastTryTime
	FROM [dbo].[Mail] m
