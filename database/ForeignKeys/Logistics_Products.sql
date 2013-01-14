

ALTER TABLE Logistics_Products WITH NOCHECK
ADD CONSTRAINT Logistics_Products_UpdatedBy
    FOREIGN KEY (UpdatedBy)
    REFERENCES System_Users(Id)

ALTER TABLE Logistics_Products WITH NOCHECK
ADD CONSTRAINT Logistics_Products_CreatedBy
    FOREIGN KEY (CreatedBy)
    REFERENCES System_Users(Id)

ALTER TABLE Logistics_Products NOCHECK CONSTRAINT Logistics_Products_UpdatedBy
ALTER TABLE Logistics_Products NOCHECK CONSTRAINT Logistics_Products_CreatedBy