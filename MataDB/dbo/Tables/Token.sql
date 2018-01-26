CREATE TABLE [dbo].[Token] (
    [ID]          INT              IDENTITY (1, 1) NOT NULL,
    [AccountID]   INT              NOT NULL,
    [TokenString] UNIQUEIDENTIFIER NOT NULL,
    [StartTime]   DATETIME         NOT NULL,
    [EndTime]     DATETIME         NOT NULL,
    CONSTRAINT [PK_Token] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Token_Account] FOREIGN KEY ([AccountID]) REFERENCES [dbo].[Account] ([ID])
);

