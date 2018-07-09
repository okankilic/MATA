CREATE VIEW [dbo].[vProject]
	AS SELECT p.ID,
	p.ProjectName,
	p.Remarks,
	p.CreatedByAccountID,
	ca.FullName as CreatedBy,
	p.CreateTime,
	p.UpdatedByAccountID,
	ua.FullName as UpdatedBy,
	p.UpdateTime
	FROM [dbo].[Project] p
	LEFT JOIN [dbo].[Account] ca on p.CreatedByAccountID = ca.ID
	LEFT JOIN [dbo].[Account] ua on p.UpdatedByAccountID = ua.ID
