CREATE VIEW [dbo].[vIssue]
	AS SELECT i.ID,
	i.SeqNo,
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
	s.CityID,
	s.CityName,
	s.CountryID,
	s.CountryName,
	i.CreatedByAccountID,
	ca.FullName as CreatedBy,
	i.CreateTime,
	i.UpdatedByAccountID,
	ua.FullName as UpdatedBy,
	i.UpdateTime
	FROM [dbo].[Issue] i 
	INNER JOIN [dbo].[vStore] s on i.StoreID = s.ID
	LEFT JOIN [dbo].[Account] ca on i.CreatedByAccountID = ca.ID
	LEFT JOIN [dbo].[Account] ua on i.UpdatedByAccountID = ua.ID
