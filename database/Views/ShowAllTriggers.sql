﻿--more info: http://stackoverflow.com/questions/4305691/need-to-list-all-triggers-in-sql-server-database-with-table-name-and-tables-sch



IF EXISTS(select * from sys.columns
          where Object_ID = Object_ID(N'ShowAllTriggers'))
BEGIN
        DROP VIEW ShowAllTriggers
END

GO

CREATE VIEW ShowAllTriggers
AS
SELECT 
     sysobjects.name AS trigger_name 
    ,USER_NAME(sysobjects.uid) AS trigger_owner 
    ,s.name AS table_schema 
    ,OBJECT_NAME(parent_obj) AS table_name 
    ,OBJECTPROPERTY( id, 'ExecIsUpdateTrigger') AS isupdate 
    ,OBJECTPROPERTY( id, 'ExecIsDeleteTrigger') AS isdelete 
    ,OBJECTPROPERTY( id, 'ExecIsInsertTrigger') AS isinsert 
    ,OBJECTPROPERTY( id, 'ExecIsAfterTrigger') AS isafter 
    ,OBJECTPROPERTY( id, 'ExecIsInsteadOfTrigger') AS isinsteadof 
    ,OBJECTPROPERTY(id, 'ExecIsTriggerDisabled') AS [disabled] 
FROM sysobjects 


INNER JOIN sysusers 
    ON sysobjects.uid = sysusers.uid 

INNER JOIN sys.tables t 
    ON sysobjects.parent_obj = t.object_id 

INNER JOIN sys.schemas s 
    ON t.schema_id = s.schema_id 

WHERE sysobjects.type = 'TR'