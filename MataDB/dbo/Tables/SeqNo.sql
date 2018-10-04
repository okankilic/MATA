CREATE TABLE [dbo].[SeqNo] (
    [ID]         INT          IDENTITY (1, 1) NOT NULL,
    [Prefix]     VARCHAR (9)  NOT NULL,
    [SeqNo]      INT          NOT NULL,
    CONSTRAINT [PK_SeqNo] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [IX_SeqNo_Prefix_SeqNo] UNIQUE NONCLUSTERED ([Prefix] ASC, [SeqNo] ASC)
);



