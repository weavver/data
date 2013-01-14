

ALTER TABLE CustomerService_Tickets WITH NOCHECK
ADD
    CONSTRAINT CustomerService_Tickets_CreatedBy
    FOREIGN KEY (CreatedBy)
    REFERENCES System_Users(Id)

ALTER TABLE CustomerService_Tickets WITH NOCHECK
ADD CONSTRAINT CustomerService_Tickets_UpdatedBy
    FOREIGN KEY (UpdatedBy)
    REFERENCES System_Users(Id)

ALTER TABLE CustomerService_Tickets NOCHECK CONSTRAINT CustomerService_Tickets_CreatedBy
ALTER TABLE CustomerService_Tickets NOCHECK CONSTRAINT CustomerService_Tickets_UpdatedBy