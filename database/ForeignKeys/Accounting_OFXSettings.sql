
ALTER TABLE Accounting_OFXSettings WITH NOCHECK
ADD CONSTRAINT uc_Accounting_OFXSettings_AccountId UNIQUE(AccountId)
    
ALTER TABLE Accounting_OFXSettings WITH NOCHECK
ADD CONSTRAINT Accounting_OFXSettings_AccountId
    FOREIGN KEY (AccountId)
    REFERENCES Accounting_Accounts(Id)

ALTER TABLE Accounting_OFXSettings WITH NOCHECK
ADD CONSTRAINT Accounting_OFXSettings_UpdatedBy
    FOREIGN KEY (UpdatedBy)
    REFERENCES System_Users(Id)

ALTER TABLE Accounting_OFXSettings WITH NOCHECK
ADD CONSTRAINT Accounting_OFXSettings_CreatedBy
    FOREIGN KEY (CreatedBy)
    REFERENCES System_Users(Id)

ALTER TABLE Accounting_OFXSettings NOCHECK CONSTRAINT Accounting_OFXSettings_AccountId
ALTER TABLE Accounting_OFXSettings NOCHECK CONSTRAINT Accounting_OFXSettings_UpdatedBy
ALTER TABLE Accounting_OFXSettings NOCHECK CONSTRAINT Accounting_OFXSettings_CreatedBy