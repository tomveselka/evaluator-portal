CREATE TABLE [dbo].[properties]
(
	[id] INT NOT NULL PRIMARY KEY, 
    [application_number] NVARCHAR(15) NOT NULL, 
    [property_type] NVARCHAR(15) NOT NULL, 
    [evaluator_id] INT NULL, 
    [evaluation_report_id] INT NULL, 
    [payment_id] INT NULL, 
    [address_id] INT NULL, 
    [status] NVARCHAR(20) NOT NULL, 
    [created_at] TIMESTAMP NOT NULL, 
    [latest_record] BIT NOT NULL, 
    [date_of_update] TIMESTAMP NULL

)
