CREATE TABLE [dbo].[Containers]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CapacityInOZ] FLOAT NOT NULL, 
    [ContainerType] NVARCHAR(100) NULL, 
    [ContainerName] NVARCHAR(100) NOT NULL
)
