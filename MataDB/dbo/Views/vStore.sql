CREATE VIEW [dbo].[vStore]
	AS SELECT s.ID,
	s.StoreName,
	s.CityID,
	c.CityName,
	c.CountryID,
	c.CountryName,
	s.ProjectID,
	p.ProjectName,
	s.[Address],
	s.CreatedByAccountID,
	ca.FullName as CreatedBy,
	s.CreateTime,
	s.UpdatedByAccountID,
	ua.FullName as UpdatedBy,
	s.UpdateTime
	FROM [dbo].[Store] s
	INNER JOIN [dbo].[Project] p on s.ProjectID = p.ID
	INNER JOIN [dbo].[vCity] c on s.CityID = c.ID
	LEFT JOIN [dbo].[Account] ca on s.CreatedByAccountID = ca.ID
	LEFT JOIN [dbo].[Account] ua on s.UpdatedByAccountID = ua.ID
