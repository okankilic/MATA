﻿CREATE TABLE [dbo].[Account] (
    [ID]          INT            IDENTITY (1, 1) NOT NULL,
	[FullName]	  VARCHAR(50)	 NOT NULL,
    [Email]		  VARCHAR(100)	 NOT NULL,
    [Password]    NVARCHAR (50)  NOT NULL,
    [RoleName]    VARCHAR (20)   NOT NULL,
    CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED ([ID] ASC)
);

