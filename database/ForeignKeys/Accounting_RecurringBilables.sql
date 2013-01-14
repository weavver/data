
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].Accounting_RecurringBillables_OrganizationId'))
BEGIN
	ALTER TABLE Accounting_RecurringBillables
	DROP CONSTRAINT Accounting_RecurringBillables_OrganizationId
END

ALTER TABLE Accounting_RecurringBillables WITH NOCHECK
ADD
    CONSTRAINT Accounting_RecurringBillables_OrganizationId
    FOREIGN KEY (OrganizationId)
    REFERENCES Logistics_Organizations(Id)

ALTER TABLE Accounting_RecurringBillables WITH NOCHECK
ADD CONSTRAINT Accounting_RecurringBillables_AccountFrom
    FOREIGN KEY (AccountFrom)
    REFERENCES Logistics_Organizations(Id)

ALTER TABLE Accounting_RecurringBillables WITH NOCHECK
ADD CONSTRAINT Accounting_RecurringBillables_AccountTo
    FOREIGN KEY (AccountTo)
    REFERENCES Logistics_Organizations(Id)

ALTER TABLE Accounting_RecurringBillables WITH NOCHECK
ADD CONSTRAINT Accounting_RecurringBillables_CreatedBy
    FOREIGN KEY (CreatedBy)
    REFERENCES System_Users(Id)

ALTER TABLE Accounting_RecurringBillables WITH NOCHECK
ADD CONSTRAINT Accounting_RecurringBillables_UpdatedBy
    FOREIGN KEY (UpdatedBy)
    REFERENCES System_Users(Id)
    
ALTER TABLE Accounting_RecurringBillables NOCHECK CONSTRAINT Accounting_RecurringBillables_OrganizationId
ALTER TABLE Accounting_RecurringBillables NOCHECK CONSTRAINT Accounting_RecurringBillables_AccountFrom
ALTER TABLE Accounting_RecurringBillables NOCHECK CONSTRAINT Accounting_RecurringBillables_AccountTo
ALTER TABLE Accounting_RecurringBillables NOCHECK CONSTRAINT Accounting_RecurringBillables_CreatedBy
ALTER TABLE Accounting_RecurringBillables NOCHECK CONSTRAINT Accounting_RecurringBillables_UpdatedBy