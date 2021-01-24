CREATE PROCEDURE [dbo].[Sp_SelectAllBrands]
AS
	SELECT *
	FROM [myBeerDb].[dbo].[Brands] WITH(NOLOCK)