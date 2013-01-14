
-- Connect the Checks table to the Accounts table

ALTER TABLE Accounting_Checks WITH NOCHECK
ADD CONSTRAINT Accounting_Checks_AccountId
    FOREIGN KEY (AccountId)
    REFERENCES Accounting_Accounts(Id)

ALTER TABLE Accounting_Checks WITH NOCHECK
ADD CONSTRAINT Accounting_Checks_Payee
    FOREIGN KEY (Payee)
    REFERENCES Logistics_Organizations(Id)

ALTER TABLE Accounting_Checks NOCHECK CONSTRAINT Accounting_Checks_AccountId
ALTER TABLE Accounting_Checks NOCHECK CONSTRAINT Accounting_Checks_Payee