

ALTER TABLE Sales_LicenseKeyActivations WITH NOCHECK
     ADD CONSTRAINT Sales_LicenseKeyActivations_OrganizationId
     FOREIGN KEY (OrganizationId)
     REFERENCES Logistics_Organizations(Id)

ALTER TABLE Sales_LicenseKeyActivations WITH NOCHECK
     ADD CONSTRAINT Sales_LicenseKeyActivations_LicenseKeyId
     FOREIGN KEY (LicenseKeyId)
     REFERENCES Sales_LicenseKeys(Id)

ALTER TABLE Sales_LicenseKeyActivations WITH NOCHECK
     ADD CONSTRAINT Sales_LicenseKeyActivations_UpdatedBy
     FOREIGN KEY (UpdatedBy)
     REFERENCES System_Users(Id)

ALTER TABLE Sales_LicenseKeyActivations WITH NOCHECK
     ADD CONSTRAINT Sales_LicenseKeyActivations_CreatedBy
     FOREIGN KEY (CreatedBy)
     REFERENCES System_Users(Id)
     
ALTER TABLE Sales_LicenseKeyActivations NOCHECK CONSTRAINT Sales_LicenseKeyActivations_LicenseKeyId
ALTER TABLE Sales_LicenseKeyActivations NOCHECK CONSTRAINT Sales_LicenseKeyActivations_UpdatedBy
ALTER TABLE Sales_LicenseKeyActivations NOCHECK CONSTRAINT Sales_LicenseKeyActivations_CreatedBy