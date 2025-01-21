CREATE TABLE [dbo].[collaterals]
(
	[id] INT NOT NULL PRIMARY KEY, 
    [application_number] NVARCHAR(15) NOT NULL, 
    [collateral_type] NVARCHAR(15) NOT NULL, 
    [evaluator_id] INT NULL, 
    [evaluation_report_id] INT NULL, 
    [payment_id] INT NULL, 
    [address_id] INT NULL, 
    [status] NVARCHAR(20) NOT NULL, 
    [created_at] DATETIME NOT NULL, 
    [latest_record] BIT NOT NULL, 
    [date_of_update] DATETIME NULL
)