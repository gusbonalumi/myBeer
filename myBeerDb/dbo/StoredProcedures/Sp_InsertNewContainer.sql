CREATE PROCEDURE [dbo].[Sp_InsertNewContainer]
	@ContainerName varchar(50),
	@ContainerType varchar(50),
	@CapacityInOZ float
AS
	INSERT INTO dbo.Containers(ContainerName, ContainerType, CapacityInOZ)
	VALUES (@ContainerName, @ContainerType, @CapacityInOZ)
