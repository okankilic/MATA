CREATE VIEW [dbo].[vAccount]
	AS SELECT a.ID,
	a.FullName,
	a.Email,
	a.RoleName
	FROM [dbo].[Account] a
