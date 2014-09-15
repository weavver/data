namespace Weavver.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Logistics_Organizations
    {
        public Logistics_Organizations()
        {
            Accounting_Accounts = new HashSet<Accounting_Accounts>();
            Accounting_Accounts1 = new HashSet<Accounting_Accounts>();
            Accounting_Checks = new HashSet<Accounting_Checks>();
            Accounting_Checks1 = new HashSet<Accounting_Checks>();
            Accounting_CreditCards = new HashSet<Accounting_CreditCards>();
            Accounting_LedgerItems = new HashSet<Accounting_LedgerItems>();
            Accounting_RecurringBillables = new HashSet<Accounting_RecurringBillables>();
            Accounting_RecurringBillables1 = new HashSet<Accounting_RecurringBillables>();
            Accounting_RecurringBillables2 = new HashSet<Accounting_RecurringBillables>();
            CustomerService_Tickets = new HashSet<CustomerService_Tickets>();
            CustomerService_Tickets1 = new HashSet<CustomerService_Tickets>();
            HR_Jobs = new HashSet<HR_Jobs>();
            HR_Staff = new HashSet<HR_Staff>();
            HR_Tasks = new HashSet<HR_Tasks>();
            HR_TimeLogs = new HashSet<HR_TimeLogs>();
            Accounting_LedgerItemTags = new HashSet<Accounting_LedgerItemTags>();
            Logistics_Products = new HashSet<Logistics_Products>();
            Marketing_Blogs = new HashSet<Marketing_Blogs>();
            Sales_Discounts = new HashSet<Sales_Discounts>();
            Sales_Resellers = new HashSet<Sales_Resellers>();
            Sales_Resellers1 = new HashSet<Sales_Resellers>();
            Sales_LicenseKeyActivations = new HashSet<Sales_LicenseKeyActivations>();
            Sales_LicenseKeys = new HashSet<Sales_LicenseKeys>();
            Sales_LicenseKeys1 = new HashSet<Sales_LicenseKeys>();
            Sales_Orders = new HashSet<Sales_Orders>();
        }

        public Guid Id { get; set; }

        public Guid OrganizationId { get; set; }

        [StringLength(25)]
        public string OrganizationType { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(25)]
        public string EIN { get; set; }

        public DateTime? Founded { get; set; }

        public string Bio { get; set; }

        [StringLength(50)]
        public string VanityURL { get; set; }

        public Guid? ReferredBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Guid UpdatedBy { get; set; }

        public Guid? BillingAddress { get; set; }

        [StringLength(100)]
        public string AuthorizeNet_LoginId { get; set; }

        [StringLength(128)]
        public string AuthorizeNet_TransactionKey { get; set; }

        [StringLength(128)]
        public string AuthorizeNet_Hash { get; set; }

        [StringLength(128)]
        public string ActiveDirectory_Server { get; set; }

        [StringLength(128)]
        public string ActiveDirectory_Domain { get; set; }

        [StringLength(128)]
        public string ActiveDirectory_Password { get; set; }

        [StringLength(128)]
        public string SmtpServer { get; set; }

        public int? SmtpPort { get; set; }

        [StringLength(128)]
        public string FreeSwitch_Server { get; set; }

        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal? PayableBalance { get; set; }

        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal? ReceivableBalance { get; set; }

        public virtual ICollection<Accounting_Accounts> Accounting_Accounts { get; set; }

        public virtual ICollection<Accounting_Accounts> Accounting_Accounts1 { get; set; }

        public virtual ICollection<Accounting_Checks> Accounting_Checks { get; set; }

        public virtual ICollection<Accounting_Checks> Accounting_Checks1 { get; set; }

        public virtual ICollection<Accounting_CreditCards> Accounting_CreditCards { get; set; }

        public virtual ICollection<Accounting_LedgerItems> Accounting_LedgerItems { get; set; }

        public virtual ICollection<Accounting_RecurringBillables> Accounting_RecurringBillables { get; set; }

        public virtual ICollection<Accounting_RecurringBillables> Accounting_RecurringBillables1 { get; set; }

        public virtual ICollection<Accounting_RecurringBillables> Accounting_RecurringBillables2 { get; set; }

        public virtual ICollection<CustomerService_Tickets> CustomerService_Tickets { get; set; }

        public virtual ICollection<CustomerService_Tickets> CustomerService_Tickets1 { get; set; }

        public virtual ICollection<HR_Jobs> HR_Jobs { get; set; }

        public virtual ICollection<HR_Staff> HR_Staff { get; set; }

        public virtual ICollection<HR_Tasks> HR_Tasks { get; set; }

        public virtual ICollection<HR_TimeLogs> HR_TimeLogs { get; set; }

        public virtual ICollection<Accounting_LedgerItemTags> Accounting_LedgerItemTags { get; set; }

        public virtual ICollection<Logistics_Products> Logistics_Products { get; set; }

        public virtual ICollection<Marketing_Blogs> Marketing_Blogs { get; set; }

        public virtual ICollection<Sales_Discounts> Sales_Discounts { get; set; }

        public virtual ICollection<Sales_Resellers> Sales_Resellers { get; set; }

        public virtual ICollection<Sales_Resellers> Sales_Resellers1 { get; set; }

        public virtual System_Users System_Users { get; set; }

        public virtual System_Users System_Users1 { get; set; }

        public virtual ICollection<Sales_LicenseKeyActivations> Sales_LicenseKeyActivations { get; set; }

        public virtual ICollection<Sales_LicenseKeys> Sales_LicenseKeys { get; set; }

        public virtual ICollection<Sales_LicenseKeys> Sales_LicenseKeys1 { get; set; }

        public virtual ICollection<Sales_Orders> Sales_Orders { get; set; }
    }
}
