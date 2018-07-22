CREATE TABLE [dbo].[Attachment] (
    [ID]             INT            IDENTITY (1, 1) NOT NULL,
    [AttachmentType] VARCHAR (20)   NOT NULL,
    [EntityName]	 VARCHAR (20)	NOT NULL,
	[EntityID]		 INT			NOT NULL,
    [FilePath]       VARCHAR (200)  NOT NULL,
    [FileName]       NVARCHAR (200) NOT NULL,
	[CreatedByAccountID] INT			NOT NULL,
	[CreateTime]		 DATETIME		NOT NULL,
	[UpdatedByAccountID] INT			NOT NULL,
	[UpdateTime]		 DATETIME		NOT NULL
    CONSTRAINT [PK_Attachment] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_Attachment_CreatedByAccount] FOREIGN KEY ([CreatedByAccountID]) REFERENCES [dbo].[Account] ([ID]),
	CONSTRAINT [FK_Attachment_UpdatedByAccount] FOREIGN KEY ([UpdatedByAccountID]) REFERENCES [dbo].[Account] ([ID])
);




GO

CREATE INDEX [IX_Attachment_CreateTime] ON [dbo].[Attachment] ([CreateTime] DESC)
