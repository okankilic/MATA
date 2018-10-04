CREATE VIEW [dbo].[vSeqNo]
	AS SELECT 
	sn.ID,
	sn.Prefix,
	sn.SeqNo
	FROM [dbo].[SeqNo] sn
