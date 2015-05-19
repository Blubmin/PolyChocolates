CREATE TABLE [dbo].[RecipeIngredient] (
    [RecipeIngredientId] INT          IDENTITY (1, 1) NOT NULL,
    [RecipeId]           INT          NULL,
    [Ingredient]       VARCHAR(MAX)          NULL,
    [Amount]             FLOAT (53)   NULL,
    [Unit]               VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([RecipeIngredientId] ASC),
    CONSTRAINT [FK_RecipeIngredient_Recipe] FOREIGN KEY ([RecipeId]) REFERENCES [dbo].[Recipe] ([RecipeId])
);

