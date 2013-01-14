
ALTER TABLE Accounting_Accounts WITH NOCHECK
ADD CONSTRAINT Accounting_Accounts_UpdatedBy
    FOREIGN KEY (UpdatedBy)
    REFERENCES System_Users(Id)

ALTER TABLE Accounting_Accounts WITH NOCHECK
ADD CONSTRAINT Accounting_Accounts_CreatedBy
    FOREIGN KEY (CreatedBy)
    REFERENCES System_Users(Id)

ALTER TABLE Accounting_Accounts NOCHECK CONSTRAINT Accounting_Accounts_UpdatedBy
ALTER TABLE Accounting_Accounts NOCHECK CONSTRAINT Accounting_Accounts_CreatedBy