

    
ALTER TABLE Sales_LicenseKeys WITH NOCHECK
ADD CONSTRAINT Sales_LicenseKeys_OrganizationId
    FOREIGN KEY (OrganizationId)
    REFERENCES Logistics_Organizations(Id)

ALTER TABLE Sales_LicenseKeys WITH NOCHECK
ADD CONSTRAINT Sales_LicenseKeys_AssignedTo
    FOREIGN KEY (AssignedTo)
    REFERENCES Logistics_Organizations(Id)

ALTER TABLE Sales_LicenseKeys WITH NOCHECK
ADD CONSTRAINT Sales_LicenseKeys_UpdatedBy
    FOREIGN KEY (UpdatedBy)
    REFERENCES System_Users(Id)

ALTER TABLE Sales_LicenseKeys WITH NOCHECK
ADD CONSTRAINT Sales_LicenseKeys_CreatedBy
    FOREIGN KEY (CreatedBy)
    REFERENCES System_Users(Id)


ALTER TABLE Sales_LicenseKeys NOCHECK CONSTRAINT Sales_LicenseKeys_AssignedTo
ALTER TABLE Sales_LicenseKeys NOCHECK CONSTRAINT Sales_LicenseKeys_UpdatedBy
ALTER TABLE Sales_LicenseKeys NOCHECK CONSTRAINT Sales_LicenseKeys_CreatedBy