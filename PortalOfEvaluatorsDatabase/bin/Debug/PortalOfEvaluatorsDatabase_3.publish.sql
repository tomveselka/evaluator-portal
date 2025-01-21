﻿/*
Deployment script for PortalOfEvaluators

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "PortalOfEvaluators"
:setvar DefaultFilePrefix "PortalOfEvaluators"
:setvar DefaultDataPath "F:\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\"
:setvar DefaultLogPath "F:\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [master];


GO

IF (DB_ID(N'$(DatabaseName)') IS NOT NULL) 
BEGIN
    ALTER DATABASE [$(DatabaseName)]
    SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [$(DatabaseName)];
END

GO
PRINT N'Creating database $(DatabaseName)...'
GO
CREATE DATABASE [$(DatabaseName)]
    ON 
    PRIMARY(NAME = [$(DatabaseName)], FILENAME = N'$(DefaultDataPath)$(DefaultFilePrefix)_Primary.mdf')
    LOG ON (NAME = [$(DatabaseName)_log], FILENAME = N'$(DefaultLogPath)$(DefaultFilePrefix)_Primary.ldf') COLLATE Latin1_General_CI_AS
GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CLOSE OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'Creating Table [dbo].[addresses]...';


GO
CREATE TABLE [dbo].[addresses] (
    [Id]           INT           NOT NULL,
    [number]       NVARCHAR (20) NULL,
    [street]       NVARCHAR (50) NULL,
    [city]         NVARCHAR (50) NULL,
    [postcode]     NVARCHAR (5)  NULL,
    [country]      NVARCHAR (50) NULL,
    [address_code] NVARCHAR (10) NULL,
    [created_at]   DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating Table [dbo].[collaterals]...';


GO
CREATE TABLE [dbo].[collaterals] (
    [id]                   INT           NOT NULL,
    [application_number]   NVARCHAR (15) NOT NULL,
    [collateral_type]      NVARCHAR (15) NOT NULL,
    [evaluator_id]         INT           NULL,
    [evaluation_report_id] INT           NULL,
    [payment_id]           INT           NULL,
    [address_id]           INT           NULL,
    [status]               NVARCHAR (20) NOT NULL,
    [created_at]           TIMESTAMP     NOT NULL,
    [latest_record]        BIT           NOT NULL,
    [date_of_update]       TIMESTAMP     NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
-- Refactoring step to update target server with deployed transaction logs

IF OBJECT_ID(N'dbo.__RefactorLog') IS NULL
BEGIN
    CREATE TABLE [dbo].[__RefactorLog] (OperationKey UNIQUEIDENTIFIER NOT NULL PRIMARY KEY)
    EXEC sp_addextendedproperty N'microsoft_database_tools_support', N'refactoring log', N'schema', N'dbo', N'table', N'__RefactorLog'
END
GO
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '2fa9d7cd-0c31-4ca6-8cf8-c9e1a2222b8c')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('2fa9d7cd-0c31-4ca6-8cf8-c9e1a2222b8c')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '80d7db0d-6362-469e-9e02-09ac3545e2ca')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('80d7db0d-6362-469e-9e02-09ac3545e2ca')

GO

GO
PRINT N'Update complete.';


GO
