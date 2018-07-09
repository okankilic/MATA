CREATE TABLE [dbo].[Store] (
    [ID]                 INT            IDENTITY (1, 1) NOT NULL,
    [StoreName]          NVARCHAR (200) NOT NULL,
    [ProjectID]          INT            NOT NULL,
    [CityID]             INT            NOT NULL,
    [Address]            NVARCHAR (200) NOT NULL,
	[CreatedByAccountID] INT			NOT NULL,
	[CreateTime]		 DATETIME		NOT NULL,
	[UpdatedByAccountID] INT			NOT NULL,
	[UpdateTime]		 DATETIME		NOT NULL
    CONSTRAINT [PK_Store] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Store_City] FOREIGN KEY ([CityID]) REFERENCES [LK].[City] ([ID]),
    CONSTRAINT [FK_Store_Project] FOREIGN KEY ([ProjectID]) REFERENCES [dbo].[Project] ([ID]),
	CONSTRAINT [FK_Store_CreatedByAccount] FOREIGN KEY ([CreatedByAccountID]) REFERENCES [dbo].[Account] ([ID]),
	CONSTRAINT [FK_Store_UpdatedByAccount] FOREIGN KEY ([UpdatedByAccountID]) REFERENCES [dbo].[Account] ([ID])
);

