
ALTER TABLE Accounting_Reconciliations
ADD CONSTRAINT Accounting_Reconciliations_Account
    FOREIGN KEY (Account)
    REFERENCES Accounting_Accounts(Id)
    
ALTER TABLE Accounting_Reconciliations NOCHECK CONSTRAINT Accounting_Reconciliations_Account