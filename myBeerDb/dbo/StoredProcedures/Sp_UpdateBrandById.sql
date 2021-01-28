CREATE PROCEDURE [dbo].[Sp_UpdateBrandById]
	@Id int,
	@BrandName varchar(100),
	@Nationality varchar(100)
AS
	UPDATE dbo.Brands
	SET
		BrandName = @BrandName,
		Nationality = @Nationality
	WHERE Id = @Id