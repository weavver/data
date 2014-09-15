
-- first thing, run the pre-pre-deploy script


--apply foreign keys

--DEPLOY THE SALES_LICENSEKEYACTIVATIONS TABLE
-- DELETE SALES_LICENSEKEYS_CURRENTUSERS COLUMN


--apply Foreign keys for Sales_ShoppingCartItems.sql

-- merge logistics_services and logistics_products

--ALTER TABLE Logistics_Products DROP INDEX PK_Logistics_Products

--############### WARNING, MAKE SURE TO MERGE FIRST ####
--drop table Logistics_Products

-- exec sp_RENAME 'Logistics_Services', 'Logistics_Products'


-- deploy Accounting_AccountBalances view



-- DATA MERGE FROM LOCAL STAGING
 
-- Communication_MessageTemplates

-- deploy the database project to the database

-- apply PHP configuration to the web.config and startup node and phpnet from the config section

-- to the assemblies node

-- add weavvertest user to the Roles table
-- DEPLOY COMPANY A and COMPANY B for ARB test


-- TODO: MERGE DATA LINKS["Logistics_Addresses"] of ["Sales_Orders"] to PrimaryContactAddress
-- TODO: create a table called sales_planfeatures as a crossreference with logistics_productfeatures



ALTER TABLE [weavverstaging].[dbo].[System_Users] ALTER COLUMN [OrganizationId] uniqueidentifier NOT NULL
ALTER TABLE [weavverstaging].[dbo].[Marketing_PressReleases] ALTER COLUMN [OrganizationId] uniqueidentifier NOT NULL


IF EXISTS(select * from Sys.Columns where Object_ID = Object_ID(N'Logistics_Organizations') and Name = N'PayableBalance') BEGIN ALTER TABLE Logistics_Organizations DROP COLUMN PayableBalance END
IF EXISTS(select * from Sys.Columns where Object_ID = Object_ID(N'Logistics_Organizations') and Name = N'ReceivableBalance') BEGIN ALTER TABLE Logistics_Organizations DROP COLUMN ReceivableBalance END
ALTER TABLE [weavverstaging].[dbo].[Logistics_Organizations] ALTER COLUMN [OrganizationId] uniqueidentifier NOT NULL

  
IF EXISTS(select * from Sys.Columns where Object_ID = Object_ID(N'Logistics_Organizations') and Name = N'PayableBalance') BEGIN ALTER TABLE Logistics_Organizations DROP COLUMN PayableBalance END
IF EXISTS(select * from Sys.Columns where Object_ID = Object_ID(N'Logistics_Organizations') and Name = N'ReceivableBalance') BEGIN ALTER TABLE Logistics_Organizations DROP COLUMN ReceivableBalance END

ALTER TABLE [weavverstaging].[dbo].[System_Users] ALTER COLUMN [OrganizationId] uniqueidentifier NOT NULL
ALTER TABLE [weavverstaging].[dbo].[Marketing_PressReleases] ALTER COLUMN [OrganizationId] uniqueidentifier NOT NULL

ALTER TABLE [weavverstaging].[dbo].[Logistics_Organizations] ALTER COLUMN [OrganizationId] uniqueidentifier NOT NULL


ALTER TABLE Logistics_Organizations ADD PayableBalance AS (dbo.Total_ForLedger(OrganizationId,Id,'Payable',1,1,1,null,null))
ALTER TABLE Logistics_Organizations ADD ReceivableBalance AS (dbo.Total_ForLedger(OrganizationId,Id,'Receivable',1,1,1,null,null))


ALTER TABLE [weavverstaging].[dbo].HR_TimeLogs ALTER COLUMN UpdatedAt datetime NOT NULL
ALTER TABLE [weavverstaging].[dbo].HR_TimeLogs ALTER COLUMN UpdatedBy uniqueidentifier NOT NULL
ALTER TABLE [weavverstaging].[dbo].HR_TimeLogs ALTER COLUMN CreatedAt datetime NOT NULL
ALTER TABLE [weavverstaging].[dbo].HR_TimeLogs ALTER COLUMN CreatedBy uniqueidentifier NOT NULL



ALTER TABLE [weavverstaging].[dbo].Accounting_Reconciliations ALTER COLUMN UpdatedAt datetime NOT NULL
ALTER TABLE [weavverstaging].[dbo].Accounting_Reconciliations ALTER COLUMN UpdatedBy uniqueidentifier NOT NULL
ALTER TABLE [weavverstaging].[dbo].Accounting_Reconciliations ALTER COLUMN CreatedAt datetime NOT NULL
ALTER TABLE [weavverstaging].[dbo].Accounting_Reconciliations ALTER COLUMN CreatedBy uniqueidentifier NOT NULL

ALTER TABLE [weavverstaging].[dbo].Accounting_LedgerItems ALTER COLUMN OrganizationId uniqueidentifier NOT NULL
ALTER TABLE [weavverstaging].[dbo].Accounting_LedgerItems ALTER COLUMN UpdatedAt datetime NOT NULL
ALTER TABLE [weavverstaging].[dbo].Accounting_LedgerItems ALTER COLUMN UpdatedBy uniqueidentifier NOT NULL
ALTER TABLE [weavverstaging].[dbo].Accounting_LedgerItems ALTER COLUMN CreatedAt datetime NOT NULL
ALTER TABLE [weavverstaging].[dbo].Accounting_LedgerItems ALTER COLUMN CreatedBy uniqueidentifier NOT NULL


ALTER TABLE [weavverstaging].[dbo].System_Users ALTER COLUMN Activated bit NOT NULL
ALTER TABLE [weavverstaging].[dbo].System_Users ALTER COLUMN Locked bit NOT NULL

USE [weavverstaging]
GO


select * from Logistics_Organizations where vanityurl = 'weavver'
update Logistics_Organizations set vanityurl='weavverinc' where vanityurl = 'weavver'





  ALTER TABLE Accounting_Checks DROP Column PayeeName 
  ALTER TABLE Accounting_Checks ADD PayeeName AS (dbo.GetName(Payee)) 
  
  
  --ALTER TABLE Accounting_Checks ADD PayeeName AS (dbo.GetName(AccountId))

  
--declare @ret nvarchar(300) = null;
--exec @ret = GetName @id='262979FD-7771-4014-9EF8-578B3C5D2942'
--select @ret

--select name, definition, type_desc FROM sys.sql_modules m 
--INNER JOIN sys.objects o ON m.object_id=o.object_id
--where type_desc like '%function%'