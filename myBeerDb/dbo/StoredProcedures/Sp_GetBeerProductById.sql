CREATE PROCEDURE [dbo].[Sp_GetBeerProductById]
	@Id int
AS
	SELECT Id, BrandId, ContainerId, Price
	FROM dbo.BeerProducts WITH(NOLOCK)
	WHERE Id = @Id
