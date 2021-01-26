CREATE PROCEDURE [dbo].[Sp_InsertNewBeerProduct]
	@BrandId int,
	@ContainerId int,
	@Price money
AS
	INSERT INTO dbo.BeerProducts(BrandId, ContainerId, Price)
	VALUES(@BrandId, @ContainerId, @Price)
