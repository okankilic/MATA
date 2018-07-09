CREATE TABLE [dbo].[Account] (
    [ID]       INT              IDENTITY (1, 1) NOT NULL,
    [UID]      UNIQUEIDENTIFIER CONSTRAINT [DF_Account_UID] DEFAULT (newid()) NOT NULL,
    [FullName] VARCHAR (50)     NOT NULL,
    [Email]    VARCHAR (100)    NOT NULL,
    [Password] NVARCHAR (50)    NOT NULL,
    [RoleName] VARCHAR (20)     NOT NULL,
    [IsActive] BIT NOT NULL, 
    CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [IX_Email] UNIQUE NONCLUSTERED ([Email] ASC)
);



