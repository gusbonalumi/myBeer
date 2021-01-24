CREATE PROCEDURE [dbo].[Sp_SelectAllContainers]
AS
	SELECT *
	FROM [dbo].[Containers] WITH(NOLOCK)