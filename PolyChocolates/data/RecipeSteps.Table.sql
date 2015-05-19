CREATE TABLE [dbo].[RecipeSteps]
(
	[RecipeStepId] INT NOT NULL PRIMARY KEY Identity, 
    [RecipeId] INT NULL, 
    [StepNumber] INT NULL, 
    [StepInstructions] VARCHAR(MAX) NULL, 
    CONSTRAINT [FK_RecipeSteps_Recipe] FOREIGN KEY ([RecipeId]) REFERENCES [Recipe]([RecipeId])
)
