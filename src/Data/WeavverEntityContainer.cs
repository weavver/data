namespace Weavver.Data
{
     using System;
     using System.Data.Entity;
     using System.ComponentModel.DataAnnotations.Schema;
     using System.Linq;

     public partial class WeavverEntityContainer : DbContext
     {
          public WeavverEntityContainer()
               : base("name=WeavverEntityContainer")
          {
               Database.SetInitializer<WeavverEntityContainer>(null);
               this.Configuration.ProxyCreationEnabled = false; 
          }

          public virtual DbSet<Accounting_Accounts> Accounting_Accounts { get; set; }
          public virtual DbSet<Accounting_Checks> Accounting_Checks { get; set; }
          public virtual DbSet<Accounting_CreditCards> Accounting_CreditCards { get; set; }
          public virtual DbSet<Accounting_LedgerItems> Accounting_LedgerItems { get; set; }
          public virtual DbSet<Accounting_OFXSettings> Accounting_OFXSettings { get; set; }
          public virtual DbSet<Accounting_Reconciliations> Accounting_Reconciliations { get; set; }
          public virtual DbSet<Accounting_RecurringBillables> Accounting_RecurringBillables { get; set; }
          public virtual DbSet<aspnet_Applications> aspnet_Applications { get; set; }
          public virtual DbSet<aspnet_Membership> aspnet_Membership { get; set; }
          public virtual DbSet<aspnet_Paths> aspnet_Paths { get; set; }
          public virtual DbSet<aspnet_PersonalizationAllUsers> aspnet_PersonalizationAllUsers { get; set; }
          public virtual DbSet<aspnet_PersonalizationPerUser> aspnet_PersonalizationPerUser { get; set; }
          public virtual DbSet<aspnet_Profile> aspnet_Profile { get; set; }
          public virtual DbSet<aspnet_Roles> aspnet_Roles { get; set; }
          public virtual DbSet<aspnet_SchemaVersions> aspnet_SchemaVersions { get; set; }
          public virtual DbSet<aspnet_Users> aspnet_Users { get; set; }
          public virtual DbSet<aspnet_WebEvent_Events> aspnet_WebEvent_Events { get; set; }
          public virtual DbSet<CMS_Pages> CMS_Pages { get; set; }
          public virtual DbSet<CommEngines_Asterisk> CommEngines_Asterisk { get; set; }
          public virtual DbSet<Communication_EmailAccounts> Communication_EmailAccounts { get; set; }
          public virtual DbSet<Communication_Emails> Communication_Emails { get; set; }
          public virtual DbSet<Communication_Messages> Communication_Messages { get; set; }
          public virtual DbSet<Communication_MessageTemplates> Communication_MessageTemplates { get; set; }
          public virtual DbSet<CustomerService_Tickets> CustomerService_Tickets { get; set; }
          public virtual DbSet<Data_AuditTrails> Data_AuditTrails { get; set; }
          public virtual DbSet<Data_Links> Data_Links { get; set; }
          public virtual DbSet<Data_RowLookups> Data_RowLookups { get; set; }
          public virtual DbSet<HR_Applications> HR_Applications { get; set; }
          public virtual DbSet<HR_Jobs> HR_Jobs { get; set; }
          public virtual DbSet<HR_Staff> HR_Staff { get; set; }
          public virtual DbSet<HR_Tasks> HR_Tasks { get; set; }
          public virtual DbSet<HR_TimeLogs> HR_TimeLogs { get; set; }
          public virtual DbSet<IT_DownloadLogs> IT_DownloadLogs { get; set; }
          public virtual DbSet<IT_IPAddresses> IT_IPAddresses { get; set; }
          public virtual DbSet<IT_NetworkAlerts> IT_NetworkAlerts { get; set; }
          public virtual DbSet<IT_RemotePowerUnits> IT_RemotePowerUnits { get; set; }
          public virtual DbSet<IT_Servers> IT_Servers { get; set; }
          public virtual DbSet<IT_WebTraffic> IT_WebTraffic { get; set; }
          public virtual DbSet<KnowledgeBase> KnowledgeBases { get; set; }
          public virtual DbSet<Legal_Agreements> Legal_Agreements { get; set; }
          public virtual DbSet<Logistics_Addresses> Logistics_Addresses { get; set; }
          public virtual DbSet<Logistics_Board> Logistics_Board { get; set; }
          public virtual DbSet<Logistics_FeatureOptions> Logistics_FeatureOptions { get; set; }
          public virtual DbSet<Logistics_Features> Logistics_Features { get; set; }
          public virtual DbSet<Logistics_Inventory> Logistics_Inventory { get; set; }
          public virtual DbSet<Logistics_Organizations> Logistics_Organizations { get; set; }
          public virtual DbSet<Logistics_Products> Logistics_Products { get; set; }
          public virtual DbSet<Logistics_Projects> Logistics_Projects { get; set; }
          public virtual DbSet<Logistics_Stock> Logistics_Stock { get; set; }
          public virtual DbSet<Marketing_Blogs> Marketing_Blogs { get; set; }
          public virtual DbSet<Marketing_PressReleases> Marketing_PressReleases { get; set; }
          public virtual DbSet<Sales_Discounts> Sales_Discounts { get; set; }
          public virtual DbSet<Sales_Leads> Sales_Leads { get; set; }
          public virtual DbSet<Sales_LicenseKeyActivations> Sales_LicenseKeyActivations { get; set; }
          public virtual DbSet<Sales_LicenseKeys> Sales_LicenseKeys { get; set; }
          public virtual DbSet<Sales_Orders> Sales_Orders { get; set; }
          public virtual DbSet<Sales_Plans> Sales_Plans { get; set; }
          public virtual DbSet<Sales_Resellers> Sales_Resellers { get; set; }
          public virtual DbSet<Sales_ShoppingCartItems> Sales_ShoppingCartItems { get; set; }
          public virtual DbSet<Source_Patches> Source_Patches { get; set; }
          public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
          public virtual DbSet<System_Tests> System_Tests { get; set; }
          public virtual DbSet<System_URLs> System_URLs { get; set; }
          public virtual DbSet<System_Users> System_Users { get; set; }
          public virtual DbSet<Vendors_PayPal_IPNs> Vendors_PayPal_IPNs { get; set; }
          public virtual DbSet<Accounting_LedgerItemTags> Accounting_LedgerItemTags { get; set; }
          public virtual DbSet<Logistics_DIDs> Logistics_DIDs { get; set; }
          public virtual DbSet<Logistics_ProductsTemp> Logistics_ProductsTemp { get; set; }
          public virtual DbSet<Accounting_AccountBalances> Accounting_AccountBalances { get; set; }
          public virtual DbSet<ShowAllTrigger> ShowAllTriggers { get; set; }
          public virtual DbSet<vw_aspnet_Applications> vw_aspnet_Applications { get; set; }
          public virtual DbSet<vw_aspnet_MembershipUsers> vw_aspnet_MembershipUsers { get; set; }
          public virtual DbSet<vw_aspnet_Profiles> vw_aspnet_Profiles { get; set; }
          public virtual DbSet<vw_aspnet_Roles> vw_aspnet_Roles { get; set; }
          public virtual DbSet<vw_aspnet_Users> vw_aspnet_Users { get; set; }
          public virtual DbSet<vw_aspnet_UsersInRoles> vw_aspnet_UsersInRoles { get; set; }
          public virtual DbSet<vw_aspnet_WebPartState_Paths> vw_aspnet_WebPartState_Paths { get; set; }
          public virtual DbSet<vw_aspnet_WebPartState_Shared> vw_aspnet_WebPartState_Shared { get; set; }
          public virtual DbSet<vw_aspnet_WebPartState_User> vw_aspnet_WebPartState_User { get; set; }

          protected override void OnModelCreating(DbModelBuilder modelBuilder)
          {
               modelBuilder.Entity<Accounting_Accounts>()
                   .Property(e => e.AccountNumber)
                   .IsUnicode(false);

               modelBuilder.Entity<Accounting_Accounts>()
                   .Property(e => e.Name)
                   .IsUnicode(false);

               modelBuilder.Entity<Accounting_Accounts>()
                   .Property(e => e.LedgerType)
                   .IsUnicode(false);

               modelBuilder.Entity<Accounting_Accounts>()
                   .HasMany(e => e.Accounting_Accounts1)
                   .WithRequired(e => e.Accounting_Accounts2)
                   .HasForeignKey(e => e.UpdatedBy);

               modelBuilder.Entity<Accounting_Accounts>()
                   .HasMany(e => e.Accounting_Checks)
                   .WithRequired(e => e.FundingSourceData)
                   .HasForeignKey(e => e.AccountId)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<Accounting_Accounts>()
                   .HasMany(e => e.Accounting_OFXSettings)
                   .WithOptional(e => e.Accounting_Accounts)
                   .HasForeignKey(e => e.AccountId);

               modelBuilder.Entity<Accounting_Accounts>()
                   .HasMany(e => e.Accounting_Reconciliations)
                   .WithRequired(e => e.Accounting_Accounts)
                   .HasForeignKey(e => e.Account)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<Accounting_Checks>()
                   .Property(e => e.Status)
                   .IsUnicode(false);

               modelBuilder.Entity<Accounting_Checks>()
                   .Property(e => e.Amount)
                   .HasPrecision(19, 4);

               modelBuilder.Entity<Accounting_Checks>()
                   .Property(e => e.Memo)
                   .IsUnicode(false);

               modelBuilder.Entity<Accounting_Checks>()
                   .Property(e => e.ExternalId)
                   .IsUnicode(false);

               modelBuilder.Entity<Accounting_CreditCards>()
                   .Property(e => e.Name)
                   .IsUnicode(false);

               modelBuilder.Entity<Accounting_CreditCards>()
                   .Property(e => e.Number)
                   .IsUnicode(false);

               modelBuilder.Entity<Accounting_CreditCards>()
                   .Property(e => e.Issuer)
                   .IsUnicode(false);

               modelBuilder.Entity<Accounting_CreditCards>()
                   .Property(e => e.FirstName)
                   .IsUnicode(false);

               modelBuilder.Entity<Accounting_CreditCards>()
                   .Property(e => e.LastName)
                   .IsUnicode(false);

               modelBuilder.Entity<Accounting_CreditCards>()
                   .Property(e => e.EmailAddress)
                   .IsUnicode(false);

               modelBuilder.Entity<Accounting_CreditCards>()
                   .Property(e => e.AddressLine1)
                   .IsUnicode(false);

               modelBuilder.Entity<Accounting_CreditCards>()
                   .Property(e => e.AddressLine2)
                   .IsUnicode(false);

               modelBuilder.Entity<Accounting_CreditCards>()
                   .Property(e => e.State)
                   .IsUnicode(false);

               modelBuilder.Entity<Accounting_CreditCards>()
                   .Property(e => e.ZipCode)
                   .IsUnicode(false);

               modelBuilder.Entity<Accounting_CreditCards>()
                   .Property(e => e.PhoneNumber)
                   .IsUnicode(false);

               modelBuilder.Entity<Accounting_CreditCards>()
                   .Property(e => e.PhoneExtension)
                   .IsUnicode(false);

               modelBuilder.Entity<Accounting_CreditCards>()
                   .Property(e => e.SecurityCode)
                   .IsUnicode(false);

               modelBuilder.Entity<Accounting_LedgerItems>()
                   .Property(e => e.ExternalId)
                   .IsUnicode(false);

               modelBuilder.Entity<Accounting_LedgerItems>()
                   .Property(e => e.LedgerType)
                   .IsUnicode(false);

               modelBuilder.Entity<Accounting_LedgerItems>()
                   .Property(e => e.Code)
                   .IsUnicode(false);

               modelBuilder.Entity<Accounting_LedgerItems>()
                   .Property(e => e.Memo)
                   .IsUnicode(false);

               modelBuilder.Entity<Accounting_LedgerItems>()
                   .Property(e => e.Amount)
                   .HasPrecision(19, 4);

               modelBuilder.Entity<Accounting_OFXSettings>()
                   .Property(e => e.Name)
                   .IsUnicode(false);

               modelBuilder.Entity<Accounting_OFXSettings>()
                   .Property(e => e.Url)
                   .IsUnicode(false);

               modelBuilder.Entity<Accounting_OFXSettings>()
                   .Property(e => e.FinancialInstitutionName)
                   .IsUnicode(false);

               modelBuilder.Entity<Accounting_OFXSettings>()
                   .Property(e => e.BankId)
                   .IsUnicode(false);

               modelBuilder.Entity<Accounting_OFXSettings>()
                   .Property(e => e.Username)
                   .IsUnicode(false);

               modelBuilder.Entity<Accounting_OFXSettings>()
                   .Property(e => e.Password)
                   .IsUnicode(false);

               modelBuilder.Entity<Accounting_OFXSettings>()
                   .Property(e => e.LedgerBalance)
                   .HasPrecision(19, 4);

               modelBuilder.Entity<Accounting_OFXSettings>()
                   .Property(e => e.AvailableBalance)
                   .HasPrecision(19, 4);

               modelBuilder.Entity<Accounting_Reconciliations>()
                   .Property(e => e.StartingBalance)
                   .HasPrecision(19, 4);

               modelBuilder.Entity<Accounting_Reconciliations>()
                   .Property(e => e.EndingBalance)
                   .HasPrecision(19, 4);

               modelBuilder.Entity<Accounting_Reconciliations>()
                   .Property(e => e.Credits)
                   .HasPrecision(19, 4);

               modelBuilder.Entity<Accounting_Reconciliations>()
                   .Property(e => e.Debits)
                   .HasPrecision(19, 4);

               modelBuilder.Entity<Accounting_RecurringBillables>()
                   .Property(e => e.Status)
                   .IsUnicode(false);

               modelBuilder.Entity<Accounting_RecurringBillables>()
                   .Property(e => e.Memo)
                   .IsUnicode(false);

               modelBuilder.Entity<Accounting_RecurringBillables>()
                   .Property(e => e.Amount)
                   .HasPrecision(19, 4);

               modelBuilder.Entity<Accounting_RecurringBillables>()
                   .Property(e => e.BillingDirection)
                   .IsUnicode(false);

               modelBuilder.Entity<Accounting_RecurringBillables>()
                   .Property(e => e.BillingPeriod)
                   .IsUnicode(false);

               modelBuilder.Entity<Accounting_RecurringBillables>()
                   .Property(e => e.UnbilledAmount)
                   .HasPrecision(18, 0);

               modelBuilder.Entity<aspnet_Applications>()
                   .HasMany(e => e.aspnet_Membership)
                   .WithRequired(e => e.aspnet_Applications)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<aspnet_Applications>()
                   .HasMany(e => e.aspnet_Paths)
                   .WithRequired(e => e.aspnet_Applications)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<aspnet_Applications>()
                   .HasMany(e => e.aspnet_Roles)
                   .WithRequired(e => e.aspnet_Applications)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<aspnet_Applications>()
                   .HasMany(e => e.aspnet_Users)
                   .WithRequired(e => e.aspnet_Applications)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<aspnet_Paths>()
                   .HasOptional(e => e.aspnet_PersonalizationAllUsers)
                   .WithRequired(e => e.aspnet_Paths);

               modelBuilder.Entity<aspnet_Roles>()
                   .HasMany(e => e.aspnet_Users)
                   .WithMany(e => e.aspnet_Roles)
                   .Map(m => m.ToTable("aspnet_UsersInRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

               modelBuilder.Entity<aspnet_Users>()
                   .HasOptional(e => e.aspnet_Membership)
                   .WithRequired(e => e.aspnet_Users);

               modelBuilder.Entity<aspnet_Users>()
                   .HasOptional(e => e.aspnet_Profile)
                   .WithRequired(e => e.aspnet_Users);

               modelBuilder.Entity<aspnet_WebEvent_Events>()
                   .Property(e => e.EventId)
                   .IsFixedLength()
                   .IsUnicode(false);

               modelBuilder.Entity<aspnet_WebEvent_Events>()
                   .Property(e => e.EventSequence)
                   .HasPrecision(19, 0);

               modelBuilder.Entity<aspnet_WebEvent_Events>()
                   .Property(e => e.EventOccurrence)
                   .HasPrecision(19, 0);

               modelBuilder.Entity<CMS_Pages>()
                   .Property(e => e.MasterPage)
                   .IsUnicode(false);

               modelBuilder.Entity<CMS_Pages>()
                   .Property(e => e.Title)
                   .IsUnicode(false);

               modelBuilder.Entity<CMS_Pages>()
                   .Property(e => e.Page)
                   .IsUnicode(false);

               modelBuilder.Entity<CommEngines_Asterisk>()
                   .Property(e => e.Host)
                   .IsUnicode(false);

               modelBuilder.Entity<CommEngines_Asterisk>()
                   .Property(e => e.Username)
                   .IsUnicode(false);

               modelBuilder.Entity<CommEngines_Asterisk>()
                   .Property(e => e.Password)
                   .IsUnicode(false);

               modelBuilder.Entity<Communication_EmailAccounts>()
                   .Property(e => e.Type)
                   .IsFixedLength();

               modelBuilder.Entity<Communication_EmailAccounts>()
                   .Property(e => e.Host)
                   .IsUnicode(false);

               modelBuilder.Entity<Communication_EmailAccounts>()
                   .Property(e => e.Username)
                   .IsUnicode(false);

               modelBuilder.Entity<Communication_EmailAccounts>()
                   .Property(e => e.Password)
                   .IsUnicode(false);

               modelBuilder.Entity<Communication_Emails>()
                   .Property(e => e.From)
                   .IsUnicode(false);

               modelBuilder.Entity<Communication_Emails>()
                   .Property(e => e.Subject)
                   .IsUnicode(false);

               modelBuilder.Entity<Communication_Emails>()
                   .Property(e => e.Raw)
                   .IsUnicode(false);

               modelBuilder.Entity<Communication_Emails>()
                   .Property(e => e.To)
                   .IsUnicode(false);

               modelBuilder.Entity<Communication_Emails>()
                   .Property(e => e.HTMLBody)
                   .IsUnicode(false);

               modelBuilder.Entity<Communication_Messages>()
                   .Property(e => e.Body)
                   .IsUnicode(false);

               modelBuilder.Entity<Communication_MessageTemplates>()
                   .Property(e => e.Name)
                   .IsUnicode(false);

               modelBuilder.Entity<Communication_MessageTemplates>()
                   .Property(e => e.Subject)
                   .IsUnicode(false);

               modelBuilder.Entity<Communication_MessageTemplates>()
                   .Property(e => e.Body)
                   .IsUnicode(false);

               modelBuilder.Entity<CustomerService_Tickets>()
                   .Property(e => e.Status)
                   .IsUnicode(false);

               modelBuilder.Entity<CustomerService_Tickets>()
                   .Property(e => e.ContactNumber)
                   .IsFixedLength();

               modelBuilder.Entity<CustomerService_Tickets>()
                   .Property(e => e.FullName)
                   .IsUnicode(false);

               modelBuilder.Entity<CustomerService_Tickets>()
                   .Property(e => e.EmailAddress)
                   .IsUnicode(false);

               modelBuilder.Entity<CustomerService_Tickets>()
                   .Property(e => e.Subject)
                   .IsUnicode(false);

               modelBuilder.Entity<CustomerService_Tickets>()
                   .Property(e => e.Message)
                   .IsUnicode(false);

               modelBuilder.Entity<Data_Links>()
                   .Property(e => e.Object1Type)
                   .IsUnicode(false);

               modelBuilder.Entity<Data_Links>()
                   .Property(e => e.Object2Type)
                   .IsUnicode(false);

               modelBuilder.Entity<Data_RowLookups>()
                   .Property(e => e.TableName)
                   .IsUnicode(false);

               modelBuilder.Entity<HR_Applications>()
                   .Property(e => e.EmailAddress)
                   .IsUnicode(false);

               modelBuilder.Entity<HR_Applications>()
                   .Property(e => e.Department)
                   .IsUnicode(false);

               modelBuilder.Entity<HR_Applications>()
                   .Property(e => e.NameFirst)
                   .IsUnicode(false);

               modelBuilder.Entity<HR_Applications>()
                   .Property(e => e.NameLast)
                   .IsUnicode(false);

               modelBuilder.Entity<HR_Applications>()
                   .Property(e => e.CoverLetter)
                   .IsUnicode(false);

               modelBuilder.Entity<HR_Applications>()
                   .Property(e => e.ResumePath)
                   .IsUnicode(false);

               modelBuilder.Entity<HR_Jobs>()
                   .Property(e => e.Title)
                   .IsUnicode(false);

               modelBuilder.Entity<HR_Jobs>()
                   .Property(e => e.Location)
                   .IsUnicode(false);

               modelBuilder.Entity<HR_Jobs>()
                   .Property(e => e.Compensation)
                   .IsUnicode(false);

               modelBuilder.Entity<HR_Jobs>()
                   .Property(e => e.Description)
                   .IsUnicode(false);

               modelBuilder.Entity<HR_Jobs>()
                   .Property(e => e.Requirements)
                   .IsUnicode(false);

               modelBuilder.Entity<HR_Jobs>()
                   .Property(e => e.Responsibilities)
                   .IsUnicode(false);

               modelBuilder.Entity<HR_Jobs>()
                   .Property(e => e.Bonus)
                   .IsUnicode(false);

               modelBuilder.Entity<HR_Staff>()
                   .Property(e => e.FirstName)
                   .IsUnicode(false);

               modelBuilder.Entity<HR_Staff>()
                   .Property(e => e.MiddleName)
                   .IsUnicode(false);

               modelBuilder.Entity<HR_Staff>()
                   .Property(e => e.LastName)
                   .IsUnicode(false);

               modelBuilder.Entity<HR_Staff>()
                   .Property(e => e.EmailAddress)
                   .IsUnicode(false);

               modelBuilder.Entity<HR_Staff>()
                   .Property(e => e.Username)
                   .IsUnicode(false);

               modelBuilder.Entity<HR_Staff>()
                   .Property(e => e.Password)
                   .IsUnicode(false);

               modelBuilder.Entity<HR_Staff>()
                   .Property(e => e.PassCode)
                   .IsUnicode(false);

               modelBuilder.Entity<HR_Staff>()
                   .Property(e => e.Status)
                   .IsUnicode(false);

               modelBuilder.Entity<HR_Staff>()
                   .Property(e => e.Position)
                   .IsUnicode(false);

               modelBuilder.Entity<HR_Staff>()
                   .Property(e => e.Location)
                   .IsUnicode(false);

               modelBuilder.Entity<HR_Staff>()
                   .Property(e => e.Bio)
                   .IsUnicode(false);

               modelBuilder.Entity<HR_Staff>()
                   .Property(e => e.HourlyWage)
                   .HasPrecision(19, 4);

               modelBuilder.Entity<HR_Staff>()
                   .Property(e => e.MonthlyBudget)
                   .HasPrecision(19, 4);

               modelBuilder.Entity<HR_Staff>()
                   .Property(e => e.Extension)
                   .IsUnicode(false);

               modelBuilder.Entity<HR_Staff>()
                   .HasMany(e => e.Sales_Resellers)
                   .WithRequired(e => e.HR_Staff)
                   .HasForeignKey(e => e.Manager)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<HR_Staff>()
                   .HasMany(e => e.HR_Tasks)
                   .WithOptional(e => e.HR_Staff)
                   .HasForeignKey(e => e.AssignedTo);

               modelBuilder.Entity<HR_Tasks>()
                   .Property(e => e.Name)
                   .IsUnicode(false);

               modelBuilder.Entity<HR_Tasks>()
                   .Property(e => e.Status)
                   .IsUnicode(false);

               modelBuilder.Entity<HR_Tasks>()
                   .Property(e => e.Description)
                   .IsUnicode(false);

               modelBuilder.Entity<HR_Tasks>()
                   .Property(e => e.CostBudget)
                   .HasPrecision(19, 4);

               modelBuilder.Entity<HR_Tasks>()
                   .Property(e => e.TimeEstimate)
                   .HasPrecision(18, 0);

               modelBuilder.Entity<HR_Tasks>()
                   .Property(e => e.TimeMax)
                   .HasPrecision(18, 0);

               modelBuilder.Entity<HR_Tasks>()
                   .HasMany(e => e.HR_Tasks1)
                   .WithOptional(e => e.HR_Tasks2)
                   .HasForeignKey(e => e.ParentTask);

               modelBuilder.Entity<HR_TimeLogs>()
                   .Property(e => e.Memo)
                   .IsUnicode(false);

               modelBuilder.Entity<HR_TimeLogs>()
                   .Property(e => e.Earned)
                   .HasPrecision(19, 4);

               modelBuilder.Entity<IT_DownloadLogs>()
                   .Property(e => e.FileName)
                   .IsUnicode(false);

               modelBuilder.Entity<IT_DownloadLogs>()
                   .Property(e => e.DownloadedByIP)
                   .IsUnicode(false);

               modelBuilder.Entity<IT_IPAddresses>()
                   .Property(e => e.IPAddress)
                   .IsUnicode(false);

               modelBuilder.Entity<IT_IPAddresses>()
                   .Property(e => e.Memo)
                   .IsUnicode(false);

               modelBuilder.Entity<IT_NetworkAlerts>()
                   .Property(e => e.Log)
                   .IsUnicode(false);

               modelBuilder.Entity<IT_RemotePowerUnits>()
                   .Property(e => e.Name)
                   .IsUnicode(false);

               modelBuilder.Entity<IT_RemotePowerUnits>()
                   .Property(e => e.Brand)
                   .IsUnicode(false);

               modelBuilder.Entity<IT_RemotePowerUnits>()
                   .Property(e => e.Model)
                   .IsUnicode(false);

               modelBuilder.Entity<IT_RemotePowerUnits>()
                   .Property(e => e.Host)
                   .IsUnicode(false);

               modelBuilder.Entity<IT_RemotePowerUnits>()
                   .Property(e => e.Password)
                   .IsUnicode(false);

               modelBuilder.Entity<IT_Servers>()
                   .Property(e => e.ServerName)
                   .IsUnicode(false);

               modelBuilder.Entity<IT_Servers>()
                   .Property(e => e.IPAddress)
                   .IsUnicode(false);

               modelBuilder.Entity<IT_Servers>()
                   .Property(e => e.Location)
                   .IsUnicode(false);

               modelBuilder.Entity<IT_Servers>()
                   .Property(e => e.MAC)
                   .IsUnicode(false);

               modelBuilder.Entity<IT_Servers>()
                   .Property(e => e.Notes)
                   .IsUnicode(false);

               modelBuilder.Entity<IT_WebTraffic>()
                   .Property(e => e.Object)
                   .IsUnicode(false);

               modelBuilder.Entity<IT_WebTraffic>()
                   .Property(e => e.RequestorIP)
                   .IsUnicode(false);

               modelBuilder.Entity<IT_WebTraffic>()
                   .Property(e => e.ReferrerUrl)
                   .IsUnicode(false);

               modelBuilder.Entity<IT_WebTraffic>()
                   .Property(e => e.UserAgent)
                   .IsUnicode(false);

               modelBuilder.Entity<KnowledgeBase>()
                   .Property(e => e.Title)
                   .IsUnicode(false);

               modelBuilder.Entity<KnowledgeBase>()
                   .Property(e => e.HtmlBody)
                   .IsUnicode(false);

               modelBuilder.Entity<KnowledgeBase>()
                   .HasMany(e => e.KnowledgeBase1)
                   .WithOptional(e => e.KnowledgeBase2)
                   .HasForeignKey(e => e.ParentId);

               modelBuilder.Entity<Legal_Agreements>()
                   .Property(e => e.Name)
                   .IsUnicode(false);

               modelBuilder.Entity<Legal_Agreements>()
                   .Property(e => e.Body)
                   .IsUnicode(false);

               modelBuilder.Entity<Logistics_Addresses>()
                   .Property(e => e.Name)
                   .IsUnicode(false);

               modelBuilder.Entity<Logistics_Addresses>()
                   .Property(e => e.Line1)
                   .IsUnicode(false);

               modelBuilder.Entity<Logistics_Addresses>()
                   .Property(e => e.Line2)
                   .IsUnicode(false);

               modelBuilder.Entity<Logistics_Addresses>()
                   .Property(e => e.City)
                   .IsUnicode(false);

               modelBuilder.Entity<Logistics_Addresses>()
                   .Property(e => e.State)
                   .IsUnicode(false);

               modelBuilder.Entity<Logistics_Addresses>()
                   .Property(e => e.ZipCode)
                   .IsUnicode(false);

               modelBuilder.Entity<Logistics_Addresses>()
                   .HasMany(e => e.Sales_Orders)
                   .WithOptional(e => e.Logistics_Addresses)
                   .HasForeignKey(e => e.BillingContactAddress);

               modelBuilder.Entity<Logistics_Addresses>()
                   .HasMany(e => e.Sales_Orders1)
                   .WithOptional(e => e.Logistics_Addresses1)
                   .HasForeignKey(e => e.PrimaryContactAddress);

               modelBuilder.Entity<Logistics_Board>()
                   .Property(e => e.Id)
                   .IsFixedLength();

               modelBuilder.Entity<Logistics_FeatureOptions>()
                   .Property(e => e.Name)
                   .IsUnicode(false);

               modelBuilder.Entity<Logistics_FeatureOptions>()
                   .Property(e => e.BillingType)
                   .IsUnicode(false);

               modelBuilder.Entity<Logistics_FeatureOptions>()
                   .Property(e => e.Cost)
                   .HasPrecision(19, 4);

               modelBuilder.Entity<Logistics_Features>()
                   .Property(e => e.Name)
                   .IsUnicode(false);

               modelBuilder.Entity<Logistics_Inventory>()
                   .Property(e => e.Name)
                   .IsUnicode(false);

               modelBuilder.Entity<Logistics_Organizations>()
                   .Property(e => e.OrganizationType)
                   .IsUnicode(false);

               modelBuilder.Entity<Logistics_Organizations>()
                   .Property(e => e.Name)
                   .IsUnicode(false);

               modelBuilder.Entity<Logistics_Organizations>()
                   .Property(e => e.EIN)
                   .IsUnicode(false);

               modelBuilder.Entity<Logistics_Organizations>()
                   .Property(e => e.Bio)
                   .IsUnicode(false);

               modelBuilder.Entity<Logistics_Organizations>()
                   .Property(e => e.VanityURL)
                   .IsUnicode(false);

               modelBuilder.Entity<Logistics_Organizations>()
                   .Property(e => e.AuthorizeNet_LoginId)
                   .IsUnicode(false);

               modelBuilder.Entity<Logistics_Organizations>()
                   .Property(e => e.AuthorizeNet_TransactionKey)
                   .IsUnicode(false);

               modelBuilder.Entity<Logistics_Organizations>()
                   .Property(e => e.AuthorizeNet_Hash)
                   .IsUnicode(false);

               modelBuilder.Entity<Logistics_Organizations>()
                   .Property(e => e.ActiveDirectory_Server)
                   .IsUnicode(false);

               modelBuilder.Entity<Logistics_Organizations>()
                   .Property(e => e.ActiveDirectory_Domain)
                   .IsUnicode(false);

               modelBuilder.Entity<Logistics_Organizations>()
                   .Property(e => e.ActiveDirectory_Password)
                   .IsUnicode(false);

               modelBuilder.Entity<Logistics_Organizations>()
                   .Property(e => e.SmtpServer)
                   .IsUnicode(false);

               modelBuilder.Entity<Logistics_Organizations>()
                   .Property(e => e.FreeSwitch_Server)
                   .IsUnicode(false);

               modelBuilder.Entity<Logistics_Organizations>()
                   .HasMany(e => e.Accounting_Accounts)
                   .WithRequired(e => e.Logistics_Organizations)
                   .HasForeignKey(e => e.CreatedBy)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<Logistics_Organizations>()
                   .HasMany(e => e.Accounting_Accounts1)
                   .WithRequired(e => e.Logistics_Organizations1)
                   .HasForeignKey(e => e.OrganizationId)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<Logistics_Organizations>()
                   .HasMany(e => e.Accounting_Checks)
                   .WithRequired(e => e.PayeeData)
                   .HasForeignKey(e => e.Payee)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<Logistics_Organizations>()
                   .HasMany(e => e.Accounting_Checks1)
                   .WithRequired(e => e.OrganizationData)
                   .HasForeignKey(e => e.OrganizationId)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<Logistics_Organizations>()
                   .HasMany(e => e.Accounting_CreditCards)
                   .WithRequired(e => e.Logistics_Organizations)
                   .HasForeignKey(e => e.OrganizationId)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<Logistics_Organizations>()
                   .HasMany(e => e.Accounting_LedgerItems)
                   .WithRequired(e => e.Logistics_Organizations)
                   .HasForeignKey(e => e.OrganizationId)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<Logistics_Organizations>()
                   .HasMany(e => e.Accounting_RecurringBillables)
                   .WithRequired(e => e.AccountFromData)
                   .HasForeignKey(e => e.AccountFrom)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<Logistics_Organizations>()
                   .HasMany(e => e.Accounting_RecurringBillables1)
                   .WithRequired(e => e.AccountToData)
                   .HasForeignKey(e => e.AccountTo)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<Logistics_Organizations>()
                   .HasMany(e => e.Accounting_RecurringBillables2)
                   .WithRequired(e => e.OrganizationData)
                   .HasForeignKey(e => e.OrganizationId)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<Logistics_Organizations>()
                   .HasMany(e => e.CustomerService_Tickets)
                   .WithRequired(e => e.Logistics_Organizations)
                   .HasForeignKey(e => e.OrganizationId)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<Logistics_Organizations>()
                   .HasMany(e => e.CustomerService_Tickets1)
                   .WithOptional(e => e.Logistics_Organizations1)
                   .HasForeignKey(e => e.CustomerId);

               modelBuilder.Entity<Logistics_Organizations>()
                   .HasMany(e => e.HR_Jobs)
                   .WithRequired(e => e.Logistics_Organizations)
                   .HasForeignKey(e => e.OrganizationId)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<Logistics_Organizations>()
                   .HasMany(e => e.HR_Staff)
                   .WithRequired(e => e.Logistics_Organizations)
                   .HasForeignKey(e => e.OrganizationId)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<Logistics_Organizations>()
                   .HasMany(e => e.HR_Tasks)
                   .WithRequired(e => e.Logistics_Organizations)
                   .HasForeignKey(e => e.OrganizationId)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<Logistics_Organizations>()
                   .HasMany(e => e.HR_TimeLogs)
                   .WithRequired(e => e.Logistics_Organizations)
                   .HasForeignKey(e => e.OrganizationId)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<Logistics_Organizations>()
                   .HasMany(e => e.Accounting_LedgerItemTags)
                   .WithRequired(e => e.Logistics_Organizations)
                   .HasForeignKey(e => e.OrganizationId)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<Logistics_Organizations>()
                   .HasMany(e => e.Logistics_Products)
                   .WithRequired(e => e.Logistics_Organizations)
                   .HasForeignKey(e => e.OrganizationId)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<Logistics_Organizations>()
                   .HasMany(e => e.Marketing_Blogs)
                   .WithRequired(e => e.Logistics_Organizations)
                   .HasForeignKey(e => e.OrganizationId)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<Logistics_Organizations>()
                   .HasMany(e => e.Sales_Discounts)
                   .WithRequired(e => e.Logistics_Organizations)
                   .HasForeignKey(e => e.OrganizationId)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<Logistics_Organizations>()
                   .HasMany(e => e.Sales_Resellers)
                   .WithRequired(e => e.Logistics_Organizations)
                   .HasForeignKey(e => e.OrganizationId)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<Logistics_Organizations>()
                   .HasMany(e => e.Sales_Resellers1)
                   .WithRequired(e => e.Logistics_Organizations1)
                   .HasForeignKey(e => e.ClientId)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<Logistics_Organizations>()
                   .HasMany(e => e.Sales_LicenseKeyActivations)
                   .WithRequired(e => e.Logistics_Organizations)
                   .HasForeignKey(e => e.OrganizationId)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<Logistics_Organizations>()
                   .HasMany(e => e.Sales_LicenseKeys)
                   .WithOptional(e => e.Logistics_Organizations)
                   .HasForeignKey(e => e.AssignedTo);

               modelBuilder.Entity<Logistics_Organizations>()
                   .HasMany(e => e.Sales_LicenseKeys1)
                   .WithRequired(e => e.Logistics_Organizations1)
                   .HasForeignKey(e => e.OrganizationId)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<Logistics_Organizations>()
                   .HasMany(e => e.Sales_Orders)
                   .WithOptional(e => e.Logistics_Organizations)
                   .HasForeignKey(e => e.Orderee);

               modelBuilder.Entity<Logistics_Products>()
                   .Property(e => e.Name)
                   .IsUnicode(false);

               modelBuilder.Entity<Logistics_Products>()
                   .Property(e => e.Brief)
                   .IsUnicode(false);

               modelBuilder.Entity<Logistics_Products>()
                   .Property(e => e.Description)
                   .IsUnicode(false);

               modelBuilder.Entity<Logistics_Products>()
                   .Property(e => e.BillingNotes)
                   .IsUnicode(false);

               modelBuilder.Entity<Logistics_Products>()
                   .Property(e => e.SetUp)
                   .HasPrecision(19, 4);

               modelBuilder.Entity<Logistics_Products>()
                   .Property(e => e.Deposit)
                   .HasPrecision(19, 4);

               modelBuilder.Entity<Logistics_Products>()
                   .Property(e => e.UnitCost)
                   .HasPrecision(19, 4);

               modelBuilder.Entity<Logistics_Products>()
                   .Property(e => e.URL)
                   .IsUnicode(false);

               modelBuilder.Entity<Logistics_Products>()
                   .Property(e => e.UnitRetailPrice)
                   .HasPrecision(19, 4);

               modelBuilder.Entity<Logistics_Products>()
                   .Property(e => e.PluginURL)
                   .IsUnicode(false);

               modelBuilder.Entity<Logistics_Products>()
                   .Property(e => e.UnitMonthly)
                   .HasPrecision(19, 4);

               modelBuilder.Entity<Logistics_Products>()
                   .HasOptional(e => e.Logistics_FeatureOptions)
                   .WithRequired(e => e.Logistics_Products);

               modelBuilder.Entity<Logistics_Projects>()
                   .Property(e => e.Name)
                   .IsUnicode(false);

               modelBuilder.Entity<Logistics_Projects>()
                   .Property(e => e.Brief)
                   .IsUnicode(false);

               modelBuilder.Entity<Logistics_Projects>()
                   .Property(e => e.Description)
                   .IsUnicode(false);

               modelBuilder.Entity<Logistics_Projects>()
                   .Property(e => e.URL)
                   .IsUnicode(false);

               modelBuilder.Entity<Marketing_Blogs>()
                   .Property(e => e.Title)
                   .IsUnicode(false);

               modelBuilder.Entity<Marketing_Blogs>()
                   .Property(e => e.Body)
                   .IsUnicode(false);

               modelBuilder.Entity<Marketing_Blogs>()
                   .Property(e => e.Status)
                   .IsUnicode(false);

               modelBuilder.Entity<Marketing_PressReleases>()
                   .Property(e => e.Title)
                   .IsUnicode(false);

               modelBuilder.Entity<Marketing_PressReleases>()
                   .Property(e => e.Body)
                   .IsUnicode(false);

               modelBuilder.Entity<Marketing_PressReleases>()
                   .Property(e => e.HTMLBody)
                   .IsUnicode(false);

               modelBuilder.Entity<Sales_Discounts>()
                   .Property(e => e.Scope)
                   .IsUnicode(false);

               modelBuilder.Entity<Sales_Discounts>()
                   .Property(e => e.Code)
                   .IsUnicode(false);

               modelBuilder.Entity<Sales_Discounts>()
                   .Property(e => e.AmountOffRetail)
                   .HasPrecision(19, 4);

               modelBuilder.Entity<Sales_Discounts>()
                   .Property(e => e.PercentOffRetail)
                   .HasPrecision(5, 2);

               modelBuilder.Entity<Sales_Leads>()
                   .Property(e => e.Source)
                   .IsUnicode(false);

               modelBuilder.Entity<Sales_Leads>()
                   .Property(e => e.EmailAddress)
                   .IsUnicode(false);

               modelBuilder.Entity<Sales_Leads>()
                   .Property(e => e.FirstName)
                   .IsUnicode(false);

               modelBuilder.Entity<Sales_Leads>()
                   .Property(e => e.LastName)
                   .IsUnicode(false);

               modelBuilder.Entity<Sales_Leads>()
                   .Property(e => e.ContactNumber)
                   .IsUnicode(false);

               modelBuilder.Entity<Sales_Leads>()
                   .Property(e => e.OrganizationSize)
                   .IsUnicode(false);

               modelBuilder.Entity<Sales_Leads>()
                   .Property(e => e.Website)
                   .IsUnicode(false);

               modelBuilder.Entity<Sales_Leads>()
                   .Property(e => e.Notes)
                   .IsUnicode(false);

               modelBuilder.Entity<Sales_Leads>()
                   .Property(e => e.ReferredBy)
                   .IsUnicode(false);

               modelBuilder.Entity<Sales_LicenseKeyActivations>()
                   .Property(e => e.MachineCode)
                   .IsUnicode(false);

               modelBuilder.Entity<Sales_LicenseKeys>()
                   .Property(e => e.FullName)
                   .IsUnicode(false);

               modelBuilder.Entity<Sales_LicenseKeys>()
                   .Property(e => e.Organization)
                   .IsUnicode(false);

               modelBuilder.Entity<Sales_LicenseKeys>()
                   .Property(e => e.Key)
                   .IsUnicode(false);

               modelBuilder.Entity<Sales_LicenseKeys>()
                   .Property(e => e.Notes)
                   .IsUnicode(false);

               modelBuilder.Entity<Sales_LicenseKeys>()
                   .Property(e => e.ExtraXML)
                   .IsUnicode(false);

               modelBuilder.Entity<Sales_LicenseKeys>()
                   .HasMany(e => e.Sales_LicenseKeyActivations)
                   .WithRequired(e => e.Sales_LicenseKeys)
                   .HasForeignKey(e => e.LicenseKeyId)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<Sales_Orders>()
                   .Property(e => e.Status)
                   .IsUnicode(false);

               modelBuilder.Entity<Sales_Orders>()
                   .Property(e => e.PrimaryContactEmail)
                   .IsUnicode(false);

               modelBuilder.Entity<Sales_Orders>()
                   .Property(e => e.PrimaryContactNameFirst)
                   .IsUnicode(false);

               modelBuilder.Entity<Sales_Orders>()
                   .Property(e => e.PrimaryContactNameLast)
                   .IsUnicode(false);

               modelBuilder.Entity<Sales_Orders>()
                   .Property(e => e.PrimaryContactOrganization)
                   .IsUnicode(false);

               modelBuilder.Entity<Sales_Orders>()
                   .Property(e => e.PrimaryContactPhoneNum)
                   .IsUnicode(false);

               modelBuilder.Entity<Sales_Orders>()
                   .Property(e => e.PrimaryContactPhoneExt)
                   .IsUnicode(false);

               modelBuilder.Entity<Sales_Orders>()
                   .Property(e => e.BillingContactEmail)
                   .IsUnicode(false);

               modelBuilder.Entity<Sales_Orders>()
                   .Property(e => e.BillingContactNameFirst)
                   .IsUnicode(false);

               modelBuilder.Entity<Sales_Orders>()
                   .Property(e => e.BillingContactNameLast)
                   .IsUnicode(false);

               modelBuilder.Entity<Sales_Orders>()
                   .Property(e => e.BillingContactOrganization)
                   .IsUnicode(false);

               modelBuilder.Entity<Sales_Orders>()
                   .Property(e => e.BillingContactPhoneNum)
                   .IsUnicode(false);

               modelBuilder.Entity<Sales_Orders>()
                   .Property(e => e.BillingContactPhoneExt)
                   .IsUnicode(false);

               modelBuilder.Entity<Sales_Orders>()
                   .Property(e => e.Cart)
                   .IsUnicode(false);

               modelBuilder.Entity<Sales_Orders>()
                   .Property(e => e.Notes)
                   .IsUnicode(false);

               modelBuilder.Entity<Sales_Plans>()
                   .Property(e => e.Name)
                   .IsUnicode(false);

               modelBuilder.Entity<Sales_Plans>()
                   .Property(e => e.Description)
                   .IsUnicode(false);

               modelBuilder.Entity<Sales_Resellers>()
                   .HasMany(e => e.Sales_Discounts)
                   .WithRequired(e => e.Sales_Resellers)
                   .HasForeignKey(e => e.ResellerId)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<Sales_ShoppingCartItems>()
                   .Property(e => e.SessionId)
                   .IsUnicode(false);

               modelBuilder.Entity<Sales_ShoppingCartItems>()
                   .Property(e => e.Name)
                   .IsUnicode(false);

               modelBuilder.Entity<Sales_ShoppingCartItems>()
                   .Property(e => e.UnitCost)
                   .HasPrecision(19, 4);

               modelBuilder.Entity<Sales_ShoppingCartItems>()
                   .Property(e => e.SetUp)
                   .HasPrecision(18, 0);

               modelBuilder.Entity<Sales_ShoppingCartItems>()
                   .Property(e => e.Deposit)
                   .HasPrecision(18, 0);

               modelBuilder.Entity<Sales_ShoppingCartItems>()
                   .Property(e => e.Monthly)
                   .HasPrecision(18, 0);

               modelBuilder.Entity<Sales_ShoppingCartItems>()
                   .Property(e => e.BackLink)
                   .IsUnicode(false);

               modelBuilder.Entity<Sales_ShoppingCartItems>()
                   .Property(e => e.Notes)
                   .IsUnicode(false);

               modelBuilder.Entity<Sales_ShoppingCartItems>()
                   .Property(e => e.Total)
                   .HasPrecision(36, 4);

               modelBuilder.Entity<Source_Patches>()
                   .Property(e => e.Status)
                   .IsUnicode(false);

               modelBuilder.Entity<Source_Patches>()
                   .Property(e => e.Notes)
                   .IsUnicode(false);

               modelBuilder.Entity<Source_Patches>()
                   .Property(e => e.Diff)
                   .IsUnicode(false);

               modelBuilder.Entity<System_Tests>()
                   .Property(e => e.Status)
                   .IsUnicode(false);

               modelBuilder.Entity<System_Tests>()
                   .Property(e => e.Path)
                   .IsUnicode(false);

               modelBuilder.Entity<System_Tests>()
                   .Property(e => e.Log)
                   .IsUnicode(false);

               modelBuilder.Entity<System_URLs>()
                   .Property(e => e.TableName)
                   .IsUnicode(false);

               modelBuilder.Entity<System_URLs>()
                   .Property(e => e.PageTemplate)
                   .IsUnicode(false);

               modelBuilder.Entity<System_URLs>()
                   .Property(e => e.Path)
                   .IsUnicode(false);

               modelBuilder.Entity<System_Users>()
                   .Property(e => e.EmailAddress)
                   .IsUnicode(false);

               modelBuilder.Entity<System_Users>()
                   .Property(e => e.Username)
                   .IsUnicode(false);

               modelBuilder.Entity<System_Users>()
                   .Property(e => e.Password)
                   .IsUnicode(false);

               modelBuilder.Entity<System_Users>()
                   .Property(e => e.UserCode)
                   .IsUnicode(false);

               modelBuilder.Entity<System_Users>()
                   .Property(e => e.PassCode)
                   .IsUnicode(false);

               modelBuilder.Entity<System_Users>()
                   .Property(e => e.FirstName)
                   .IsUnicode(false);

               modelBuilder.Entity<System_Users>()
                   .Property(e => e.MiddleName)
                   .IsUnicode(false);

               modelBuilder.Entity<System_Users>()
                   .Property(e => e.LastName)
                   .IsUnicode(false);

               modelBuilder.Entity<System_Users>()
                   .Property(e => e.ReferredBy)
                   .IsUnicode(false);

               modelBuilder.Entity<System_Users>()
                   .Property(e => e.ActivationKey)
                   .IsUnicode(false);

               modelBuilder.Entity<System_Users>()
                   .Property(e => e.PasswordQuestion)
                   .IsUnicode(false);

               modelBuilder.Entity<System_Users>()
                   .Property(e => e.PasswordAnswer)
                   .IsUnicode(false);

               modelBuilder.Entity<System_Users>()
                   .HasMany(e => e.Accounting_OFXSettings)
                   .WithRequired(e => e.System_Users)
                   .HasForeignKey(e => e.CreatedBy)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<System_Users>()
                   .HasMany(e => e.Accounting_OFXSettings1)
                   .WithRequired(e => e.System_Users1)
                   .HasForeignKey(e => e.UpdatedBy)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<System_Users>()
                   .HasMany(e => e.Accounting_RecurringBillables)
                   .WithRequired(e => e.System_Users)
                   .HasForeignKey(e => e.CreatedBy)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<System_Users>()
                   .HasMany(e => e.Accounting_RecurringBillables1)
                   .WithRequired(e => e.System_Users1)
                   .HasForeignKey(e => e.UpdatedBy)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<System_Users>()
                   .HasMany(e => e.CMS_Pages)
                   .WithRequired(e => e.System_Users)
                   .HasForeignKey(e => e.CreatedBy)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<System_Users>()
                   .HasMany(e => e.CMS_Pages1)
                   .WithRequired(e => e.System_Users1)
                   .HasForeignKey(e => e.UpdatedBy)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<System_Users>()
                   .HasMany(e => e.Communication_EmailAccounts)
                   .WithRequired(e => e.System_Users)
                   .HasForeignKey(e => e.CreatedBy)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<System_Users>()
                   .HasMany(e => e.Communication_EmailAccounts1)
                   .WithRequired(e => e.System_Users1)
                   .HasForeignKey(e => e.UpdatedBy)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<System_Users>()
                   .HasMany(e => e.Communication_Emails)
                   .WithRequired(e => e.System_Users)
                   .HasForeignKey(e => e.CreatedBy)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<System_Users>()
                   .HasMany(e => e.Communication_Emails1)
                   .WithRequired(e => e.System_Users1)
                   .HasForeignKey(e => e.UpdatedBy)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<System_Users>()
                   .HasMany(e => e.CustomerService_Tickets)
                   .WithRequired(e => e.System_Users)
                   .HasForeignKey(e => e.CreatedBy)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<System_Users>()
                   .HasMany(e => e.CustomerService_Tickets1)
                   .WithRequired(e => e.System_Users1)
                   .HasForeignKey(e => e.UpdatedBy)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<System_Users>()
                   .HasMany(e => e.Data_Links)
                   .WithRequired(e => e.System_Users)
                   .HasForeignKey(e => e.CreatedBy)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<System_Users>()
                   .HasMany(e => e.Data_Links1)
                   .WithRequired(e => e.System_Users1)
                   .HasForeignKey(e => e.UpdatedBy)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<System_Users>()
                   .HasMany(e => e.HR_Tasks)
                   .WithRequired(e => e.System_Users)
                   .HasForeignKey(e => e.CreatedBy)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<System_Users>()
                   .HasMany(e => e.HR_Tasks1)
                   .WithRequired(e => e.System_Users1)
                   .HasForeignKey(e => e.UpdatedBy)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<System_Users>()
                   .HasMany(e => e.Logistics_Organizations)
                   .WithRequired(e => e.System_Users)
                   .HasForeignKey(e => e.CreatedBy)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<System_Users>()
                   .HasMany(e => e.Logistics_Organizations1)
                   .WithRequired(e => e.System_Users1)
                   .HasForeignKey(e => e.UpdatedBy)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<System_Users>()
                   .HasMany(e => e.Logistics_Products)
                   .WithRequired(e => e.System_Users)
                   .HasForeignKey(e => e.CreatedBy)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<System_Users>()
                   .HasMany(e => e.Logistics_Products1)
                   .WithRequired(e => e.System_Users1)
                   .HasForeignKey(e => e.UpdatedBy)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<System_Users>()
                   .HasMany(e => e.Sales_LicenseKeyActivations)
                   .WithRequired(e => e.System_Users)
                   .HasForeignKey(e => e.CreatedBy)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<System_Users>()
                   .HasMany(e => e.Sales_LicenseKeyActivations1)
                   .WithRequired(e => e.System_Users1)
                   .HasForeignKey(e => e.UpdatedBy)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<System_Users>()
                   .HasMany(e => e.Sales_LicenseKeys)
                   .WithRequired(e => e.System_Users)
                   .HasForeignKey(e => e.CreatedBy)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<System_Users>()
                   .HasMany(e => e.Sales_LicenseKeys1)
                   .WithRequired(e => e.System_Users1)
                   .HasForeignKey(e => e.UpdatedBy)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<System_Users>()
                   .HasMany(e => e.Sales_Orders)
                   .WithRequired(e => e.System_Users)
                   .HasForeignKey(e => e.CreatedBy)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<System_Users>()
                   .HasMany(e => e.Sales_Orders1)
                   .WithRequired(e => e.System_Users1)
                   .HasForeignKey(e => e.UpdatedBy)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<System_Users>()
                   .HasMany(e => e.Sales_ShoppingCartItems)
                   .WithRequired(e => e.System_Users)
                   .HasForeignKey(e => e.CreatedBy)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<System_Users>()
                   .HasMany(e => e.Sales_ShoppingCartItems1)
                   .WithRequired(e => e.System_Users1)
                   .HasForeignKey(e => e.UpdatedBy)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<System_Users>()
                   .HasMany(e => e.System_URLs)
                   .WithRequired(e => e.System_Users)
                   .HasForeignKey(e => e.CreatedBy)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<System_Users>()
                   .HasMany(e => e.System_URLs1)
                   .WithRequired(e => e.System_Users1)
                   .HasForeignKey(e => e.UpdatedBy)
                   .WillCascadeOnDelete(false);

               modelBuilder.Entity<Vendors_PayPal_IPNs>()
                   .Property(e => e.TxnId)
                   .IsUnicode(false);

               modelBuilder.Entity<Vendors_PayPal_IPNs>()
                   .Property(e => e.TxnType)
                   .IsUnicode(false);

               modelBuilder.Entity<Vendors_PayPal_IPNs>()
                   .Property(e => e.ReceiverEmail)
                   .IsUnicode(false);

               modelBuilder.Entity<Vendors_PayPal_IPNs>()
                   .Property(e => e.ItemName)
                   .IsUnicode(false);

               modelBuilder.Entity<Vendors_PayPal_IPNs>()
                   .Property(e => e.ItemNumber)
                   .IsUnicode(false);

               modelBuilder.Entity<Vendors_PayPal_IPNs>()
                   .Property(e => e.Invoice)
                   .IsUnicode(false);

               modelBuilder.Entity<Vendors_PayPal_IPNs>()
                   .Property(e => e.Custom)
                   .IsUnicode(false);

               modelBuilder.Entity<Vendors_PayPal_IPNs>()
                   .Property(e => e.PaymentStatus)
                   .IsUnicode(false);

               modelBuilder.Entity<Vendors_PayPal_IPNs>()
                   .Property(e => e.PendingReason)
                   .IsUnicode(false);

               modelBuilder.Entity<Vendors_PayPal_IPNs>()
                   .Property(e => e.PaymentFee)
                   .HasPrecision(19, 4);

               modelBuilder.Entity<Vendors_PayPal_IPNs>()
                   .Property(e => e.PaymentGross)
                   .HasPrecision(19, 4);

               modelBuilder.Entity<Vendors_PayPal_IPNs>()
                   .Property(e => e.FirstName)
                   .IsUnicode(false);

               modelBuilder.Entity<Vendors_PayPal_IPNs>()
                   .Property(e => e.LastName)
                   .IsUnicode(false);

               modelBuilder.Entity<Vendors_PayPal_IPNs>()
                   .Property(e => e.AddressStreet)
                   .IsUnicode(false);

               modelBuilder.Entity<Vendors_PayPal_IPNs>()
                   .Property(e => e.AddressCity)
                   .IsUnicode(false);

               modelBuilder.Entity<Vendors_PayPal_IPNs>()
                   .Property(e => e.AddressState)
                   .IsUnicode(false);

               modelBuilder.Entity<Vendors_PayPal_IPNs>()
                   .Property(e => e.AddressZip)
                   .IsUnicode(false);

               modelBuilder.Entity<Vendors_PayPal_IPNs>()
                   .Property(e => e.AddressCountry)
                   .IsUnicode(false);

               modelBuilder.Entity<Vendors_PayPal_IPNs>()
                   .Property(e => e.AddressStatus)
                   .IsUnicode(false);

               modelBuilder.Entity<Vendors_PayPal_IPNs>()
                   .Property(e => e.PayerEmail)
                   .IsUnicode(false);

               modelBuilder.Entity<Vendors_PayPal_IPNs>()
                   .Property(e => e.PayerStatus)
                   .IsUnicode(false);

               modelBuilder.Entity<Vendors_PayPal_IPNs>()
                   .Property(e => e.PaymentType)
                   .IsUnicode(false);

               modelBuilder.Entity<Vendors_PayPal_IPNs>()
                   .Property(e => e.NotifyVersion)
                   .IsUnicode(false);

               modelBuilder.Entity<Vendors_PayPal_IPNs>()
                   .Property(e => e.VerifySign)
                   .IsUnicode(false);

               modelBuilder.Entity<Accounting_LedgerItemTags>()
                   .Property(e => e.Name)
                   .IsUnicode(false);

               modelBuilder.Entity<Accounting_LedgerItemTags>()
                   .Property(e => e.StartsWith)
                   .IsUnicode(false);

               modelBuilder.Entity<Logistics_DIDs>()
                   .Property(e => e.number)
                   .IsUnicode(false);

               modelBuilder.Entity<Logistics_ProductsTemp>()
                   .Property(e => e.Name)
                   .IsUnicode(false);

               modelBuilder.Entity<Logistics_ProductsTemp>()
                   .Property(e => e.Brief)
                   .IsUnicode(false);

               modelBuilder.Entity<Logistics_ProductsTemp>()
                   .Property(e => e.Description)
                   .IsUnicode(false);

               modelBuilder.Entity<Logistics_ProductsTemp>()
                   .Property(e => e.URL)
                   .IsUnicode(false);

               modelBuilder.Entity<Logistics_ProductsTemp>()
                   .Property(e => e.UnitCost)
                   .HasPrecision(19, 4);

               modelBuilder.Entity<Logistics_ProductsTemp>()
                   .Property(e => e.UnitPrice)
                   .HasPrecision(19, 4);

               modelBuilder.Entity<Accounting_AccountBalances>()
                   .Property(e => e.LedgerType)
                   .IsUnicode(false);

               modelBuilder.Entity<Accounting_AccountBalances>()
                   .Property(e => e.Balance)
                   .HasPrecision(19, 4);
          }
     }
}
