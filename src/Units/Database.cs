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
          private static string RepoPath
          {
               get
               {
                    string callingAssemblyFolderPath = Path.GetDirectoryName(System.Reflection.Assembly.GetCallingAssembly().Location);
                    return Directory.GetParent(callingAssemblyFolderPath).Parent.Parent.FullName;
               }
          }
//-------------------------------------------------------------------------------------------
          [ManualTest]
          public void BackupProductionDatabase()
          {
               string remoteBackupFile = Helper.GetAppSetting("remoteBackupFile");
               if (File.Exists(remoteBackupFile))
                    File.Delete(remoteBackupFile);

               string productionBackupScript = Path.Combine(RepoPath,  @"src\Units\Backup.sql");
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
               string localBackupFile = Helper.GetAppSetting("localBackupFile");
               string localrestore_mdfpath = Helper.GetAppSetting("localrestore_mdfpath");
               string localrestore_logpath = Helper.GetAppSetting("localrestore_logpath");

               if (File.Exists(localBackupFile))
                    File.Delete(localBackupFile);

               File.Copy(Helper.GetAppSetting("remoteBackupFile"), localBackupFile);

               Assert.IsTrue(File.Exists(localBackupFile), "Please make sure you have a local back up of the database to restore. setting: localBackupFile");

               string stagingRestoreScript = Path.Combine(RepoPath, @"src\Units\Restore.sql");
               string sql = File.ReadAllText(stagingRestoreScript);
               sql = sql.Replace("%localBackupFile%", localBackupFile);
               sql = sql.Replace("%localrestore_mdfpath%", localrestore_mdfpath);
               sql = sql.Replace("%localrestore_logpath%", localrestore_logpath);
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
