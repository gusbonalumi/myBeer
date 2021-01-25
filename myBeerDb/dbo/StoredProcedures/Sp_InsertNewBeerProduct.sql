CREATE PROCEDURE [dbo].[Sp_InsertNewBeerProduct]
	@BrandId int,
	@ContainerId int
AS
	INSERT INTO dbo.BeerProducts(BrandId, ContainerId)
	VALUES(@BrandId, @ContainerId)
