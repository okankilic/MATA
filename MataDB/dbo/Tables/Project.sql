CREATE TABLE [dbo].[Project] (
    [ID]                 INT            IDENTITY (1, 1) NOT NULL,
    [ProjectName]        NVARCHAR (200) NOT NULL,
    [Remarks]            NVARCHAR (500) NULL,
	[CreatedByAccountID] INT			NOT NULL,
	[CreateTime]		 DATETIME		NOT NULL,
	[UpdatedByAccountID] INT			NOT NULL,
	[UpdateTime]		 DATETIME		NOT NULL
    CONSTRAINT [PK_Project] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_Project_CreatedByAccount] FOREIGN KEY ([CreatedByAccountID]) REFERENCES [dbo].[Account] ([ID]),
	CONSTRAINT [FK_Project_UpdatedByAccount] FOREIGN KEY ([UpdatedByAccountID]) REFERENCES [dbo].[Account] ([ID])
);





