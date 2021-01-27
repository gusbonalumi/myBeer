CREATE PROCEDURE [dbo].[Sp_InsertNewBrand]
	@BrandName varchar(50),
	@Nationality varchar(150)
AS
	INSERT INTO dbo.Brands(BrandName, Nationality)
	VALUES (@BrandName, @Nationality)
