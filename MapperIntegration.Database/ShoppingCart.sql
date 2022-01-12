CREATE TABLE [dbo].[ShoppingCart]
(
	[Id] INT NOT NULL IDENTITY,
	[ProductSpecId] INT NOT NULL,
	[Qty] INT NOT NULL,
	[Owner] NVARCHAR(450) NOT NULL,

    CONSTRAINT [PK_ShoppingCart] PRIMARY KEY ([Id]), 
	CONSTRAINT [FK_ShoppingCart_ProductSpec] FOREIGN KEY ([ProductSpecId]) REFERENCES [ProductSpec]([Id]) ON DELETE CASCADE, 
)
