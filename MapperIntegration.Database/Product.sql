CREATE TABLE [dbo].[Product]
(
    [ProductNo] NVARCHAR(200) NOT NULL, 
    [ProductName] NVARCHAR(200) NOT NULL, 
    [Brand] NVARCHAR(200) NULL, 
    [Category] NVARCHAR(200) NULL, 
    [Description] NVARCHAR(500) NULL,
    [CreatedDate] DATETIMEOFFSET NOT NULL DEFAULT GETDATE(),
    [CreatedBy] NVARCHAR(450) NOT NULL DEFAULT '',
    [ModifiedDate] DATETIMEOFFSET NOT NULL DEFAULT GETDATE(),
    [ModifiedBy] NVARCHAR(450) NOT NULL DEFAULT '', 

    CONSTRAINT [PK_Product] PRIMARY KEY ([ProductNo])
)
