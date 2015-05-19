CREATE TABLE [dbo].[Traceability]
(
	[TraceabilityId] INT NOT NULL PRIMARY KEY Identity, 
    [ProductEntryId] INT NULL, 
    [InventoryId] INT NULL, 
    [AmoundUsed] FLOAT NULL, 
    CONSTRAINT [FK_Traceability_ProductEntry] FOREIGN KEY ([ProductEntryId]) REFERENCES [ProductEntry]([ProductEntryId]), 
    CONSTRAINT [FK_Traceability_Inventory] FOREIGN KEY ([InventoryId]) REFERENCES [Inventory]([InventoryId]),

)
