CREATE VIEW [dbo].[vStoreAccount]
	AS SELECT sa.ID,
	sa.StoreID,
	s.StoreName,
	s.ProjectID,
	s.ProjectName,
	s.CountryID,
	s.CountryName,
	s.CityID,
	s.CityName,
	sa.AccountID,
	a.FullName,
	a.Email,
	a.PhoneNumber
	FROM [dbo].[StoreAccount] sa
	INNER JOIN [dbo].[vStore] s on sa.StoreID = s.ID
	INNER JOIN [dbo].[vAccount] a on sa.AccountID = a.ID