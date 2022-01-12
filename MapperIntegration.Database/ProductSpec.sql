CREATE TABLE [dbo].[ProductSpec]
(	
    [Id] INT NOT NULL IDENTITY,
    [ProductNo] NVARCHAR(200) NOT NULL, 
    [Size] NVARCHAR(50) NOT NULL,   
    [Qty] INT NOT NULL, 
    [Price] DECIMAL NOT NULL,     
    [Description] NVARCHAR(500) NULL, 
    [DeliveryFee] DECIMAL NOT NULL DEFAULT 0, 
    [IsDiscounted] BIT NOT NULL DEFAULT 0, 
    [IsNew] BIT NOT NULL DEFAULT 0, 
    [CreatedDate] DATETIMEOFFSET NOT NULL DEFAULT GETDATE(),
    [CreatedBy] NVARCHAR(450) NOT NULL DEFAULT '',
    [ModifiedDate] DATETIMEOFFSET NOT NULL DEFAULT GETDATE(),
    [ModifiedBy] NVARCHAR(450) NOT NULL DEFAULT '', 

    CONSTRAINT [PK_ProductSpec] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_ProductSpec_Product] FOREIGN KEY ([ProductNo]) REFERENCES [Product]([ProductNo]) ON DELETE CASCADE, 
)
