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
	left join [dbo].[vAccount] ca on p.CreatedByAccountID = ca.ID
	left join [dbo].[vAccount] ua on p.UpdatedByAccountID = ua.ID
