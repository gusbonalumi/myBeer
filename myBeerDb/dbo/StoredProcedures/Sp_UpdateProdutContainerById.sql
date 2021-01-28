CREATE PROCEDURE [dbo].[Sp_UpdateProdutContainerById]
	@Id int,
	@ContainerName varchar(100),
	@ContainerType varchar(100),
	@CapacityInOZ float
AS
	UPDATE dbo.Containers
	SET
		ContainerName = @ContainerName,
		ContainerType = @ContainerType,
		CapacityInOZ = @CapacityInOZ
	WHERE Id = @Id
