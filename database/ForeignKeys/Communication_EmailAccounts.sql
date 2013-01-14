
ALTER TABLE Communication_EmailAccounts WITH NOCHECK
ADD CONSTRAINT Communication_EmailAccounts_UpdatedBy
    FOREIGN KEY (UpdatedBy)
    REFERENCES System_Users(Id)

ALTER TABLE Communication_EmailAccounts WITH NOCHECK
ADD CONSTRAINT Communication_EmailAccounts_CreatedBy
    FOREIGN KEY (CreatedBy)
    REFERENCES System_Users(Id)
    
ALTER TABLE Communication_EmailAccounts NOCHECK CONSTRAINT Communication_EmailAccounts_UpdatedBy
ALTER TABLE Communication_EmailAccounts NOCHECK CONSTRAINT Communication_EmailAccounts_CreatedBy