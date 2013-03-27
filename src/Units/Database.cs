using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using OpenPop.Pop3;
using OpenPop.Mime;
using System.Diagnostics;
using System.Data.SqlClient;
using System.IO;

namespace Weavver.Testing.Staging
{
     public partial class Database
     {
//-------------------------------------------------------------------------------------------
          [ManualTest]
          public void BackupProductionDatabase()
          {
               string remoteBackupFile = Helper.GetAppSetting("remoteBackupFile");
               if (File.Exists(remoteBackupFile))
                    File.Delete(remoteBackupFile);

               string productionBackupScript = @"C:\Weavver\Main\Projects\Database Components\Staging\Backup.sql";
               string sql = File.ReadAllText(productionBackupScript);
               using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["production"].ConnectionString))
               {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.ExecuteNonQuery();
               }
          }
//-------------------------------------------------------------------------------------------
          [ManualTest]
          public void DeployBackupDatabaseToDevMachine()
          {
               string localBackupFile = @"C:\Data\Backups\Weavver-ProductionDB.bak";

               if (File.Exists(localBackupFile))
                    File.Delete(localBackupFile);

               File.Copy(Helper.GetAppSetting("remoteBackupFile"), localBackupFile);

               string stagingRestoreScript = @"C:\Weavver\Main\Projects\Database Components\Staging\Restore.sql";
               string sql = File.ReadAllText(stagingRestoreScript);
               using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["dev_no_catalog"].ConnectionString))
               {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.ExecuteNonQuery();
               }
          }
//-------------------------------------------------------------------------------------------
          [ManualTest]
          public void DeployBackupDatabaseToStagingServer()
          {
               string stagingRestoreScript = @"C:\Weavver\Main\Projects\Database Components\Staging\Restore.sql";
               string sql = File.ReadAllText(stagingRestoreScript);
               using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["staging_no_catalog"].ConnectionString))
               {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.ExecuteNonQuery();
               }
          }
//-------------------------------------------------------------------------------------------
          [ManualTest]
          public void ApplySchemaUpdateScripts()
          {
               string updateScriptFolder = @"C:\Projects\Weavver\Main\Projects\Database Components\SchemaUpdates\";
               string sql = File.ReadAllText(updateScriptFolder + "Update1.sql");
               using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["staging_no_catalog"].ConnectionString))
               {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.ExecuteNonQuery();
               }
          }
//-------------------------------------------------------------------------------------------
     }
}
