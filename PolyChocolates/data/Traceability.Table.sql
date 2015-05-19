CREATE TABLE [dbo].[ProductEntryTraceability]
(
	[ProductEntryTraceabilityId] INT NOT NULL PRIMARY KEY Identity, 
    [ProductEntryId] INT NULL, 
    [InventoryId] INT NULL, 
    [AmoundUsed] FLOAT NULL,

)
