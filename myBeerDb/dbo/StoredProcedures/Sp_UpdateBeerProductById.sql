CREATE PROCEDURE [dbo].[Sp_UpdateBeerProductById]
	@Id int,
	@BrandId int,
	@ContainerId int,
	@Price money
AS
	UPDATE dbo.BeerProducts
	SET
		BrandId = @BrandId,
		ContainerId = @ContainerId,
		Price = @Price
	WHERE Id = @Id