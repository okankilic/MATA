CREATE TABLE [dbo].[Issue] (
    [ID]                  INT            IDENTITY (1, 1) NOT NULL,
    [StoreID]             INT            NOT NULL,
    [Description]         NVARCHAR (MAX) NOT NULL,
    [SourceType]          VARCHAR (20)   NOT NULL,
    [RequestedByFullName] NVARCHAR (50)  NOT NULL,
    [RequestDate]         DATE           NOT NULL,
    [IssueState]          VARCHAR (20)   NOT NULL,
    [Remarks]             NVARCHAR (MAX) NULL,
    [CreatedByAccountID]  INT            NOT NULL,
    [CreateTime]          DATETIME       NOT NULL,
    [UpdatedByAccountID]  INT            NOT NULL,
    [UpdateTime]          DATETIME       NOT NULL,
    CONSTRAINT [PK_Issue] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Issue_CreatedByAccount] FOREIGN KEY ([CreatedByAccountID]) REFERENCES [dbo].[Account] ([ID]),
    CONSTRAINT [FK_Issue_Store] FOREIGN KEY ([StoreID]) REFERENCES [dbo].[Store] ([ID]),
    CONSTRAINT [FK_Issue_UpdatedByAccount] FOREIGN KEY ([UpdatedByAccountID]) REFERENCES [dbo].[Account] ([ID])
);

