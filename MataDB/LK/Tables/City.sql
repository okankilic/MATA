CREATE TABLE [LK].[City] (
    [ID]        INT            IDENTITY (1, 1) NOT NULL,
    [CountryID] INT            NOT NULL,
    [CityName]  NVARCHAR (200) NOT NULL,
    CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_City_Country] FOREIGN KEY ([CountryID]) REFERENCES [LK].[Country] ([ID]),
    CONSTRAINT [IX_City] UNIQUE NONCLUSTERED ([CountryID] ASC, [CityName] ASC)
);

