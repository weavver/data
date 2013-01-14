
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