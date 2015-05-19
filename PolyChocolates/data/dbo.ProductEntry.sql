CREATE TABLE [dbo].[ProductEntry] (
    [ProductEntryId]    INT           IDENTITY (1, 1) NOT NULL,
    [RecipeEntryId]     INT           NULL,
    [AmountPackaged]    INT           NULL,
    [AmountProduced]    INT           NULL,
    [QualityEntryId]    INT           NULL,
    [TraceEntryId]      INT           NULL,
    [EfficiencyEntryId] INT           NULL,
    [ProductionNotes]   VARCHAR (MAX) NULL,
    [StudentManager]    VARCHAR (50)  NULL,
    [PlantManager]      VARCHAR (50)  NULL,
    [QualityPerformer]  VARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([ProductEntryId] ASC),
    UNIQUE NONCLUSTERED ([CodeDate] ASC),
    CONSTRAINT [FK_ProductEntry_Recipe] FOREIGN KEY ([RecipeEntryId]) REFERENCES [dbo].[Recipe] ([RecipeId])
);

