CREATE TABLE [LK].[Country] (
    [ID]          INT            IDENTITY (1, 1) NOT NULL,
    [CountryName] NVARCHAR (200) NOT NULL,
    CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [IX_Country] UNIQUE NONCLUSTERED ([CountryName] ASC)
);

