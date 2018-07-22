CREATE VIEW [dbo].[vAttachment]
	AS SELECT a.ID,
	a.AttachmentType,
	a.EntityName,
	a.EntityID,
	a.[FileName],
	a.FilePath,
	a.CreatedByAccountID,
	ca.FullName as CreatedBy,
	a.CreateTime,
	a.UpdatedByAccountID,
	ua.FullName as UpdatedBy,
	a.UpdateTime
	FROM [dbo].[Attachment] a
	INNER JOIN [dbo].[Account] ca on a.CreatedByAccountID = ca.ID
	INNER JOIN [dbo].[Account] ua on a.UpdatedByAccountID = ua.ID
