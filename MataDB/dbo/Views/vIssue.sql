CREATE VIEW [dbo].[vIssue]
	AS SELECT i.ID,
	i.[Description],
	i.IssueState,
	i.Remarks,
	i.RequestDate,
	i.RequestedByFullName,
	i.SourceType,
	i.StoreID,
	s.StoreName,
	s.ProjectID,
	s.ProjectName,
	i.CreatedByAccountID,
	ca.FullName as CreatedBy,
	i.CreateTime,
	i.UpdatedByAccountID,
	ua.FullName as UpdatedBy,
	i.UpdateTime
	FROM [dbo].[Issue] i 
	left join [dbo].[vStore] s on i.StoreID = s.ID
	left join [dbo].[vAccount] ca on i.CreatedByAccountID = ca.ID
	left join [dbo].[vAccount] ua on i.UpdatedByAccountID = ua.ID
