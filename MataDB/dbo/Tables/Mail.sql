CREATE TABLE [dbo].[Mail] (
    [ID]          INT            IDENTITY (1, 1) NOT NULL,
    [Subject]     NVARCHAR (250) NOT NULL,
    [MailBody]    NVARCHAR (MAX) NOT NULL,
    [IsBodyHtml]  BIT            NOT NULL,
    [State]       VARCHAR (20)   NOT NULL,
    [TryCount]    INT            CONSTRAINT [DF_Mail_TryCount] DEFAULT ((0)) NOT NULL,
    [LastTryTime] DATETIME       CONSTRAINT [DF_Mail_LastTryTime] DEFAULT (sysdatetime()) NOT NULL,
    CONSTRAINT [PK_Mail] PRIMARY KEY CLUSTERED ([ID] ASC)
);




GO
CREATE NONCLUSTERED INDEX [IX_Mail]
    ON [dbo].[Mail]([State] ASC, [TryCount] ASC);

