CREATE TABLE [dbo].[BeerProducts]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [BrandId] INT NOT NULL, 
    [ContainerId] INT NOT NULL, 
    [Price] MONEY NOT NULL, 
    [imagePath] NVARCHAR(150) NULL, 
    CONSTRAINT [FK_BeerProducts_Brands] FOREIGN KEY ([BrandId]) REFERENCES [dbo].[Brands]([Id]),
    CONSTRAINT [FK_BeerProducts_Containers] FOREIGN KEY ([ContainerId]) REFERENCES [dbo].[Containers]([Id])
)
