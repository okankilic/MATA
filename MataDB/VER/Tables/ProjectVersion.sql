CREATE TABLE [VER].[ProjectVersion] (
    [ActionID]    INT            NOT NULL,
    [ProjectID]   INT            NOT NULL,
    [CountryID]   INT            NOT NULL,
    [ProjectName] NVARCHAR (200) NOT NULL,
    [Remarks]     NVARCHAR (500) NULL,
    CONSTRAINT [FK_ProjectVersion_Country] FOREIGN KEY ([CountryID]) REFERENCES [LK].[Country] ([ID]),
    CONSTRAINT [FK_ProjectVersion_Project] FOREIGN KEY ([ProjectID]) REFERENCES [dbo].[Project] ([ID])
);




GO


