namespace Weavver.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class System_Users
    {
        public System_Users()
        {
            Accounting_OFXSettings = new HashSet<Accounting_OFXSettings>();
            Accounting_OFXSettings1 = new HashSet<Accounting_OFXSettings>();
            Accounting_RecurringBillables = new HashSet<Accounting_RecurringBillables>();
            Accounting_RecurringBillables1 = new HashSet<Accounting_RecurringBillables>();
            CMS_Pages = new HashSet<CMS_Pages>();
            CMS_Pages1 = new HashSet<CMS_Pages>();
            Communication_EmailAccounts = new HashSet<Communication_EmailAccounts>();
            Communication_EmailAccounts1 = new HashSet<Communication_EmailAccounts>();
            Communication_Emails = new HashSet<Communication_Emails>();
            Communication_Emails1 = new HashSet<Communication_Emails>();
            CustomerService_Tickets = new HashSet<CustomerService_Tickets>();
            CustomerService_Tickets1 = new HashSet<CustomerService_Tickets>();
            Data_Links = new HashSet<Data_Links>();
            Data_Links1 = new HashSet<Data_Links>();
            HR_Tasks = new HashSet<HR_Tasks>();
            HR_Tasks1 = new HashSet<HR_Tasks>();
            Logistics_Organizations = new HashSet<Logistics_Organizations>();
            Logistics_Organizations1 = new HashSet<Logistics_Organizations>();
            Logistics_Products = new HashSet<Logistics_Products>();
            Logistics_Products1 = new HashSet<Logistics_Products>();
            Sales_LicenseKeyActivations = new HashSet<Sales_LicenseKeyActivations>();
            Sales_LicenseKeyActivations1 = new HashSet<Sales_LicenseKeyActivations>();
            Sales_LicenseKeys = new HashSet<Sales_LicenseKeys>();
            Sales_LicenseKeys1 = new HashSet<Sales_LicenseKeys>();
            Sales_Orders = new HashSet<Sales_Orders>();
            Sales_Orders1 = new HashSet<Sales_Orders>();
            Sales_ShoppingCartItems = new HashSet<Sales_ShoppingCartItems>();
            Sales_ShoppingCartItems1 = new HashSet<Sales_ShoppingCartItems>();
            System_URLs = new HashSet<System_URLs>();
            System_URLs1 = new HashSet<System_URLs>();
        }

        public Guid Id { get; set; }

        public Guid OrganizationId { get; set; }

        [StringLength(50)]
        public string EmailAddress { get; set; }

        [StringLength(50)]
        public string Username { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(25)]
        public string UserCode { get; set; }

        [StringLength(25)]
        public string PassCode { get; set; }

        [StringLength(75)]
        public string FirstName { get; set; }

        [StringLength(75)]
        public string MiddleName { get; set; }

        [StringLength(75)]
        public string LastName { get; set; }

        [StringLength(300)]
        public string ReferredBy { get; set; }

        public bool Activated { get; set; }

        [StringLength(300)]
        public string ActivationKey { get; set; }

        public bool Locked { get; set; }

        public DateTime? LastLoggedIn { get; set; }

        [StringLength(250)]
        public string PasswordQuestion { get; set; }

        [StringLength(250)]
        public string PasswordAnswer { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Guid UpdatedBy { get; set; }

        public virtual ICollection<Accounting_OFXSettings> Accounting_OFXSettings { get; set; }

        public virtual ICollection<Accounting_OFXSettings> Accounting_OFXSettings1 { get; set; }

        public virtual ICollection<Accounting_RecurringBillables> Accounting_RecurringBillables { get; set; }

        public virtual ICollection<Accounting_RecurringBillables> Accounting_RecurringBillables1 { get; set; }

        public virtual ICollection<CMS_Pages> CMS_Pages { get; set; }

        public virtual ICollection<CMS_Pages> CMS_Pages1 { get; set; }

        public virtual ICollection<Communication_EmailAccounts> Communication_EmailAccounts { get; set; }

        public virtual ICollection<Communication_EmailAccounts> Communication_EmailAccounts1 { get; set; }

        public virtual ICollection<Communication_Emails> Communication_Emails { get; set; }

        public virtual ICollection<Communication_Emails> Communication_Emails1 { get; set; }

        public virtual ICollection<CustomerService_Tickets> CustomerService_Tickets { get; set; }

        public virtual ICollection<CustomerService_Tickets> CustomerService_Tickets1 { get; set; }

        public virtual ICollection<Data_Links> Data_Links { get; set; }

        public virtual ICollection<Data_Links> Data_Links1 { get; set; }

        public virtual ICollection<HR_Tasks> HR_Tasks { get; set; }

        public virtual ICollection<HR_Tasks> HR_Tasks1 { get; set; }

        public virtual ICollection<Logistics_Organizations> Logistics_Organizations { get; set; }

        public virtual ICollection<Logistics_Organizations> Logistics_Organizations1 { get; set; }

        public virtual ICollection<Logistics_Products> Logistics_Products { get; set; }

        public virtual ICollection<Logistics_Products> Logistics_Products1 { get; set; }

        public virtual ICollection<Sales_LicenseKeyActivations> Sales_LicenseKeyActivations { get; set; }

        public virtual ICollection<Sales_LicenseKeyActivations> Sales_LicenseKeyActivations1 { get; set; }

        public virtual ICollection<Sales_LicenseKeys> Sales_LicenseKeys { get; set; }

        public virtual ICollection<Sales_LicenseKeys> Sales_LicenseKeys1 { get; set; }

        public virtual ICollection<Sales_Orders> Sales_Orders { get; set; }

        public virtual ICollection<Sales_Orders> Sales_Orders1 { get; set; }

        public virtual ICollection<Sales_ShoppingCartItems> Sales_ShoppingCartItems { get; set; }

        public virtual ICollection<Sales_ShoppingCartItems> Sales_ShoppingCartItems1 { get; set; }

        public virtual ICollection<System_URLs> System_URLs { get; set; }

        public virtual ICollection<System_URLs> System_URLs1 { get; set; }
    }
}
