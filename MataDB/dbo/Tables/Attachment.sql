CREATE TABLE [dbo].[Attachment] (
    [ID]             INT            IDENTITY (1, 1) NOT NULL,
    [AttachmentType] VARCHAR (20)   NOT NULL,
    [MailID]         INT            NULL,
    [IssueID]        INT            NULL,
    [FilePath]       VARCHAR (200)  NOT NULL,
    [FileName]       NVARCHAR (200) NOT NULL,
    CONSTRAINT [PK_Attachment] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Attachment_Issue] FOREIGN KEY ([IssueID]) REFERENCES [dbo].[Issue] ([ID]),
    CONSTRAINT [FK_Attachment_Mail] FOREIGN KEY ([MailID]) REFERENCES [dbo].[Mail] ([ID])
);



