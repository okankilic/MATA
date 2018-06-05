CREATE VIEW [dbo].[vStore]
	AS SELECT s.ID,
	s.StoreName,
	s.ProjectID,
	p.ProjectName,
	s.[Address],
	s.CityID,
	s.CreatedByAccountID,
	ca.FullName as CreatedBy,
	s.CreateTime,
	s.UpdatedByAccountID,
	ua.FullName as UpdatedBy,
	s.UpdateTime
	FROM [dbo].[Store] s
	inner join [dbo].[Project] p on s.ProjectID = p.ID
	left join [dbo].[vAccount] ca on s.CreatedByAccountID = ca.ID
	left join [dbo].[vAccount] ua on s.UpdatedByAccountID = ua.ID
