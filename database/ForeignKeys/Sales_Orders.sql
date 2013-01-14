
ALTER TABLE Sales_Orders WITH NOCHECK
ADD CONSTRAINT Sales_Orders_Orderee
    FOREIGN KEY (Orderee)
    REFERENCES Logistics_Organizations(Id)

ALTER TABLE Sales_Orders WITH NOCHECK
ADD
    CONSTRAINT Sales_Orders_PrimaryContactAddress
    FOREIGN KEY (PrimaryContactAddress)
    REFERENCES Logistics_Addresses(Id)
    
ALTER TABLE Sales_Orders WITH NOCHECK
ADD
    CONSTRAINT Sales_Orders_BillingContactAddress
    FOREIGN KEY (BillingContactAddress)
    REFERENCES Logistics_Addresses(Id)

ALTER TABLE Sales_Orders WITH NOCHECK
ADD CONSTRAINT Sales_Orders_UpdatedBy
    FOREIGN KEY (UpdatedBy)
    REFERENCES System_Users(Id)

ALTER TABLE Sales_Orders WITH NOCHECK
ADD CONSTRAINT Sales_Orders_CreatedBy
    FOREIGN KEY (CreatedBy)
    REFERENCES System_Users(Id)

   
ALTER TABLE Sales_Orders NOCHECK CONSTRAINT Sales_Orders_Orderee
ALTER TABLE Sales_Orders NOCHECK CONSTRAINT Sales_Orders_PrimaryContactAddress
ALTER TABLE Sales_Orders NOCHECK CONSTRAINT Sales_Orders_BillingContactAddress
ALTER TABLE Sales_Orders NOCHECK CONSTRAINT Sales_Orders_UpdatedBy
ALTER TABLE Sales_Orders NOCHECK CONSTRAINT Sales_Orders_CreatedBy
