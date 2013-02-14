using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Weavver.Testing.Staging
{

 //-- REDEPLOY TRIGGERS/clean up old triggers!!

 //-- select s1.table_name,
 //--     'Count' = (select count(*) from ShowAllTriggers s2 where s2.table_name = s1.table_name)
 //-- from ShowAllTriggers s1
     public partial class Database
     {
//-------------------------------------------------------------------------------------------
          [ManualTest]
          public void DeployTriggers()
          {
               //if (System.Configuration.ConfigurationManager.AppSettings["install_mode"] == "true")
               {
                    string sqlDropTrigger = @"
                              IF EXISTS (SELECT name FROM sysobjects WHERE name = '{0}_Insert' AND type = 'TR')
                              BEGIN
	                              DROP TRIGGER {0}_Insert
                              END

                              IF EXISTS (SELECT name FROM sysobjects WHERE name = '{0}_Delete' AND type = 'TR')
                              BEGIN
	                              DROP TRIGGER {0}_Delete
                              END
                         ";

                    string sqlInsertTriggers =
                         @"CREATE TRIGGER {0}_Insert
                         ON {0}
                         AFTER INSERT
                         AS
                         BEGIN
                              SET NOCOUNT ON;
                              insert into Data_RowLookups (RowId, TableName)
                              select id, '{0}'
                              from inserted
                         END";

                    string sqlDeleteTriggers = @"
                         CREATE TRIGGER {0}_Delete
                              ON {0}
                              AFTER DELETE
                         AS 
                         BEGIN
                                   SET NOCOUNT ON;
                                   delete Data_RowLookups 
                                   where RowId in (
                                   select id
                                   from deleted)
                         END";

                    string sqlTables = @"select *
                                             from sys.objects
                                             where type = 'U'
                                             and name not in ('Data_RowLookups',
                                             'sysdiagrams',
                                             'aspnet_Applications',
                                             'aspnet_Membership',
                                             'aspnet_Paths',
                                             'aspnet_PersonalizationAllUsers',
                                             'aspnet_PersonalizationPerUser',
                                             'aspnet_Profile',
                                             'aspnet_Roles',
                                             'aspnet_SchemaVersions',
                                             'aspnet_Users',
                                             'aspnet_UsersInRoles',
                                             'aspnet_WebEvent_Events')";

                    string connString = Helper.GetAppSetting("staging_remote_db");
                    using (SqlConnection connection = new SqlConnection(connString))
                    {
                         connection.Open();
                         SqlCommand command = new SqlCommand(sqlTables, connection);
                         SqlDataAdapter adapter = new SqlDataAdapter(command);
                         DataTable dt = new DataTable();
                         adapter.Fill(dt);
                         foreach (DataRow row in dt.Rows)
                         {
                              string tableName = row[0].ToString();
                              command.CommandText = String.Format(sqlDropTrigger, tableName);
                              command.ExecuteNonQuery();
                              command.CommandText = String.Format(sqlInsertTriggers, tableName);
                              command.ExecuteNonQuery();
                              command.CommandText = String.Format(sqlDeleteTriggers, tableName);
                              command.ExecuteNonQuery();
                         }
                    }
               }
               //else
               //{
               //     throw new Exception("To deploy the schema please set 'install_mode' to true in your app.config or web.config file.");
               //}
          }
//-------------------------------------------------------------------------------------------
     }
}
