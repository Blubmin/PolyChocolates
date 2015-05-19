CREATE TABLE [dbo].[Inventory] (
    [InventoryId]  INT           IDENTITY (1, 1) NOT NULL,
    [Unit]         VARCHAR (50)  NULL,
    [PricePerUnit] MONEY         NULL,
    [Stock]        FLOAT (53)    NULL,
    [MaxStock]     FLOAT (53)    NULL,
    [ReOrderLevel] VARCHAR (50)  NULL,
    [Supplier]     VARCHAR (50)  NULL,
    [Certificate]  VARCHAR (MAX) NULL,
    [Name]         VARCHAR (MAX) NULL,
    [SnapshotDate] DATETIME NULL DEFAULT GETDATE(), 
    [Enabled] VARCHAR NULL, 
    [Type] VARCHAR(MAX) NULL, 
    PRIMARY KEY CLUSTERED ([InventoryId] ASC)
);

