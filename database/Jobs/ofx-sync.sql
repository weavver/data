
--USE [msdb]
--GO

--BEGIN TRANSACTION
--DECLARE @ReturnCode INT
--SELECT @ReturnCode = 0

--          IF OBJECT_ID('temp_ARCHIVE_RECORD_COUNTS') IS NOT NULL  
--          DROP TABLE temp_ARCHIVE_RECORD_COUNTS  
--     msdb.dbo.sp_add_category @class=N'JOB', @type=N'LOCAL', @name=N'Weavver Jobs'

--     DECLARE @jobId BINARY(16)
--     msdb.dbo.sp_add_job @job_name=N'weavver --ofx-sync', 
--          @enabled=1, 
--          @notify_level_eventlog=0, 
--          @notify_level_email=0, 
--          @notify_level_netsend=0, 
--          @notify_level_page=0, 
--          @delete_level=0, 
--          @description=N'Caching/Syncing OFX data.', 
--          @category_name=N'[Uncategorized (Local)]', 
--          @owner_login_name=N'sa', @job_id = @jobId OUTPUT

--     msdb.dbo.sp_add_jobstep @job_id=@jobId, @step_name=N'weavver --ofx-sync', 
--          @step_id=1, 
--          @cmdexec_success_code=0, 
--          @on_success_action=1, 
--          @on_success_step_id=0, 
--          @on_fail_action=2, 
--          @on_fail_step_id=0, 
--          @retry_attempts=0, 
--          @retry_interval=0, 
--          @os_run_priority=0, @subsystem=N'CmdExec', 
--          @command=N'C:\Weavver\Main\Projects\Console\bin\Debug\WeavverConsole.exe --ofx-sync', 
--          @flags=32

--     msdb.dbo.sp_update_job @job_id = @jobId, @start_step_id = 1
--     msdb.dbo.sp_add_jobschedule @job_id=@jobId, @name=N'Every 30', 
--          @enabled=1, 
--          @freq_type=4, 
--          @freq_interval=1, 
--          @freq_subday_type=4, 
--          @freq_subday_interval=30, 
--          @freq_relative_interval=0, 
--          @freq_recurrence_factor=0, 
--          @active_start_date=20120212, 
--          @active_end_date=99991231, 
--          @active_start_time=0, 
--          @active_end_time=235959

--     msdb.dbo.sp_add_jobserver @job_id = @jobId, @server_name = N'(local)'
--COMMIT TRANSACTION
