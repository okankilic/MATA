CREATE VIEW [dbo].[vCity]
	AS SELECT city.ID,
	city.CityName,
	city.CountryID,
	country.CountryName
	FROM [LK].[City] city
	inner join [LK].[Country] country on city.CountryID = country.ID
