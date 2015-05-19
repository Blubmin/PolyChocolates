CREATE TABLE [dbo].[Ingredient] (
    [IngredientId] INT          IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR(50) NULL, 
    PRIMARY KEY CLUSTERED ([IngredientId] ASC)
);

