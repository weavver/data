GO
sp_configure 'show advanced options', 1;
GO
RECONFIGURE;
GO
sp_configure 'clr enabled', 1;
GO
RECONFIGURE;
GO

----IF OBJECT_ID('GetName') IS NOT NULL
--     DROP FUNCTION GetName
--GO

--IF OBJECT_ID('LocalizeDT') IS NOT NULL
--     DROP FUNCTION LocalizeDT
--GO

--IF OBJECT_ID('YearMonth') IS NOT NULL
--     DROP FUNCTION YearMonth
--GO

--IF OBJECT_ID('OFXSync') IS NOT NULL
--     DROP FUNCTION OFXSync
--GO

--IF OBJECT_ID('Weavver') IS NOT NULL
--     DROP FUNCTION Weavver
--GO


--Select * from sys.Assemblies


--IF OBJECT_ID('GetName') IS NOT NULL
----select dbo.OFXSync()
--DROP FUNCTION YearMonth
--GO

--select dbo.OFXSync()

--drop function GetName
--drop function LocalizeDT
--drop function YearMonth
--drop function OFXSync
--drop assembly WeavverDAL

--GRANT EXTERNAL ACCESS ASSEMBLY TO wvvrDal

--ALTER DATABASE weavverstaging SET TRUSTWORTHY ON;

--ALTER AUTHORIZATION on DATABASE::[weavverstaging] to [wvvrDal]

--EXEC dbo.sp_changedbowner @loginame = N'sa', @map = false


--CREATE ASSEMBLY SystemWeb from 'C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.Web.dll' with permission_set = unsafe
--CREATE ASSEMBLY InEBank FROM 'C:\Program Files (x86)\nsoftware\E-Banking Integrator V3 .NET Edition\lib\nsoftware.InEBankWeb.dll'
--CREATE ASSEMBLY WeavverLib FROM 'C:\Weavver\Main\Projects\WeavverLib\bin\Debug\WeavverLib.dll' with permission_set=unsafe


-- "C:\Weavver\Main\Projects\Console\bin\Debug\WeavverConsole.exe" --ofx-sync


