
ALTER TABLE [Data_AuditTrails] WITH NOCHECK
ADD CONSTRAINT Data_AuditTrails_CreatedBy
    FOREIGN KEY (CreatedBy)
    REFERENCES System_Users(Id)