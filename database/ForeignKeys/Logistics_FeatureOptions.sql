
ALTER TABLE Logistics_FeatureOptions WITH NOCHECK
ADD CONSTRAINT Logistics_FeatureOptions_Product
    FOREIGN KEY (Id)
    REFERENCES Logistics_Products(Id)

ALTER TABLE Logistics_FeatureOptions NOCHECK CONSTRAINT Logistics_FeatureOptions_Product