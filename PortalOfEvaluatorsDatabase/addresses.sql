CREATE TABLE [dbo].[addresses]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [number] NVARCHAR(20) NULL, 
    [street] NVARCHAR(50) NULL, 
    [city] NVARCHAR(50) NULL, 
    [postcode] NVARCHAR(5) NULL, 
    [country] NVARCHAR(50) NULL, 
    [address_code] NVARCHAR(10) NULL, 
    [created_at] DATETIME NULL
)