---------------------------------------------------------------
-- USED TO DEPLOY THE STAGING DATABASE

if exists(select * from master.dbo.sysdatabases where name = 'weavverstaging')
BEGIN

    ALTER DATABASE [weavverstaging] set single_user with rollback immediate  

     EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'weavverstaging'
     -- NOTE: WHEN MANUALLY RUNNING IF YOU NEED TO REVERT THIS LINE USE:
     -- ALTER DATABASE [weavverstaging] set multi_user with rollback immediate  

     DROP DATABASE [weavverstaging]

END

-- C:\Weavver\Data\Backups\Weavver-ProductionDB.bak
-- C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\weavverstaging.mdf
-- C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\weavverstaging_log.ldf

RESTORE DATABASE [weavverstaging]
FROM DISK = N'%localBackupFile%'
WITH FILE = 1,
MOVE N'weavverdb' TO N'%localrestore_mdfpath%',
MOVE N'weavverdb_log' TO N'%localrestore_logpath%',
NOUNLOAD
