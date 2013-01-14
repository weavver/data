

ALTER TABLE Accounting_LedgerItems WITH CHECK
ADD CONSTRAINT ucAccounting_LedgerItems_ExternalId UNIQUE(AccountId, ExternalId)


ALTER TABLE Accounting_LedgerItems WITH NOCHECK
ADD CONSTRAINT Accounting_LedgerItems_CreatedBy
    FOREIGN KEY (CreatedBy)
    REFERENCES System_Users(Id)

ALTER TABLE Accounting_LedgerItems WITH NOCHECK
ADD CONSTRAINT Accounting_LedgerItems_UpdatedBy
    FOREIGN KEY (UpdatedBy)
    REFERENCES System_Users(Id)

--ALTER TABLE Accounting_LedgerItems CHECK CONSTRAINT ALL
--ALTER TABLE Accounting_LedgerItems NOCHECK CONSTRAINT ALL



-- Constraints added for EDMX modeling reasons.. but turned off for practical reasons
     -- Specifically so tables like Accounting_RecurringBillables can insert records
     -- And use the CreatedBy/UpdatedBy fields to track changes

ALTER TABLE Accounting_LedgerItems NOCHECK CONSTRAINT Accounting_LedgerItems_CreatedBy
ALTER TABLE Accounting_LedgerItems NOCHECK CONSTRAINT Accounting_LedgerItems_UpdatedBy