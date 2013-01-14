


    
ALTER TABLE Logistics_Organizations
ADD CONSTRAINT Logistics_Organizations_ParentId
    FOREIGN KEY (OrganizationId)
    REFERENCES Logistics_Organizations(Id)


ALTER TABLE Logistics_Organizations WITH NOCHECK
ADD
    CONSTRAINT Logistics_Organizations_BillingAddress
    FOREIGN KEY (BillingAddress)
    REFERENCES Logistics_Addresses(Id)

    
ALTER TABLE Logistics_Organizations WITH NOCHECK
ADD
    CONSTRAINT Logistics_Organizations_CreatedBy
    FOREIGN KEY (CreatedBy)
    REFERENCES System_Users(Id)
    
ALTER TABLE Logistics_Organizations WITH NOCHECK
ADD
    CONSTRAINT Logistics_Organizations_UpdatedBy
    FOREIGN KEY (UpdatedBy)
    REFERENCES System_Users(Id)

    
ALTER TABLE Logistics_Organizations NOCHECK CONSTRAINT Logistics_Organizations_CreatedBy
ALTER TABLE Logistics_Organizations NOCHECK CONSTRAINT Logistics_Organizations_UpdatedBy