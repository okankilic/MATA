CREATE TABLE [dbo].[Account] (
    [ID]          INT            IDENTITY (1, 1) NOT NULL,
    [UserName]    NVARCHAR (50)  NOT NULL,
    [Password]    NVARCHAR (50)  NOT NULL,
    [RoleName]    VARCHAR (20)   NOT NULL,
    [AccountName] NVARCHAR (200) NOT NULL,
    [BrandID]     INT            NULL,
    CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Account_Brand] FOREIGN KEY ([BrandID]) REFERENCES [dbo].[Brand] ([ID])
);

