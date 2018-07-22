CREATE TABLE [dbo].[StoreAccount]
(
	[ID] INT IDENTITY(1,1) NOT NULL,
	[StoreID] INT NOT NULL,
	[AccountID] INT NOT NULL,
	CONSTRAINT [PK_StoreAccount] PRIMARY KEY CLUSTERED ([ID] ASC),
	CONSTRAINT [FK_StoreAccount_Store] FOREIGN KEY ([StoreID]) REFERENCES [dbo].[Store] (ID),
	CONSTRAINT [FK_StoreAccount_Account] FOREIGN KEY ([AccountID]) REFERENCES [dbo].[Account] (ID),
	CONSTRAINT [IX_StoreAccount_Store_Account] UNIQUE NONCLUSTERED ([StoreID] ASC, [AccountID] ASC)
)
