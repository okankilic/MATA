CREATE VIEW [dbo].[vAccount]
	AS SELECT a.ID,
	a.[UID],
	a.FullName,
	a.Email,
	a.[Password],
	a.RoleName,
	a.IsActive
	FROM [dbo].[Account] a
