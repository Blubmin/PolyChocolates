CREATE TABLE [dbo].[Recipe] (
    [RecipeId]             INT          IDENTITY (1, 1) NOT NULL,
    [Name]                 VARCHAR (50) NULL,
    [TraceabilityRequired] VARCHAR (1)  NULL DEFAULT 'Y',
    [EfficiencyRequired]   VARCHAR (1)  NULL DEFAULT 'Y',
    [QualityControlId] INT NULL DEFAULT 1, 
    PRIMARY KEY CLUSTERED ([RecipeId] ASC), 
    CONSTRAINT [FK_Recipe_QualityControl] FOREIGN KEY ([QualityControlId]) REFERENCES [QualityControl]([QualityControlId])
);

