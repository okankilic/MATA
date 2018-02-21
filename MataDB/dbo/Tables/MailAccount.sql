CREATE TABLE [dbo].[MailAccount] (
    [ID]        INT         IDENTITY (1, 1) NOT NULL,
    [MailID]    INT         NOT NULL,
    [ToCcBcc]   VARCHAR (3) NOT NULL,
    [AccountID] INT         NOT NULL,
    CONSTRAINT [PK_MailAccount] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_MailAccount_Account] FOREIGN KEY ([AccountID]) REFERENCES [dbo].[Account] ([ID]),
    CONSTRAINT [FK_MailAccount_Mail] FOREIGN KEY ([MailID]) REFERENCES [dbo].[Mail] ([ID])
);

