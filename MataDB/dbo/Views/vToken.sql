CREATE VIEW [dbo].[vToken]
	AS SELECT t.ID,
	t.AccountID,
	a.FullName,
	t.TokenString,
	t.StartTime,
	t.EndTime
	FROM [dbo].[Token] t
	inner join [dbo].[Account] a on t.AccountID = a.ID
