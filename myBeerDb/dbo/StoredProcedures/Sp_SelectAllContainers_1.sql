CREATE PROCEDURE [dbo].[Sp_SelectAllContainers]
AS
	SELECT Id, ContainerName, ContainerType, CapacityInOZ
	FROM [dbo].[Containers]