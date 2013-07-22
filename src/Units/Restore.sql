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

RESTORE DATABASE [weavverstaging] FROM
DISK = N'C:\Data\Backups\Weavver-ProductionDB.bak'
WITH  FILE = 1,
MOVE N'weavverdb' TO N'C:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\Data\weavverstaging.mdf',
MOVE N'weavverdb_log' TO N'C:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\Data\weavverstaging_log.ldf',
NOUNLOAD
