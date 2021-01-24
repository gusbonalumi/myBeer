CREATE PROCEDURE [dbo].[Sp_SelectAllBeers]
AS
	SELECT BR.BrandName, C.ContainerName, C.ContainerType, B.Price
	FROM dbo.BeerProducts AS B WITH(NOLOCK)
	INNER JOIN dbo.Brands AS BR WITH(NOLOCK)
	ON B.BrandId = BR.Id
	INNER JOIN dbo.Containers AS C WITH(NOLOCK)
	ON B.ContainerId = C.Id
RETURN 0
