CREATE VIEW [dbo].[vCountry]
	AS SELECT c.ID,
	c.CountryName
	FROM [LK].[Country] c
