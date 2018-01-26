CREATE TABLE [dbo].[Brand] (
    [ID]        INT            IDENTITY (1, 1) NOT NULL,
    [BrandName] NVARCHAR (200) NOT NULL,
    CONSTRAINT [PK_Brand] PRIMARY KEY CLUSTERED ([ID] ASC)
);

