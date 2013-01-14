
ALTER TABLE Data_Links WITH NOCHECK
ADD CONSTRAINT Data_Links_UpdatedBy
    FOREIGN KEY (UpdatedBy)
    REFERENCES System_Users(Id)

ALTER TABLE Data_Links WITH NOCHECK
ADD CONSTRAINT Data_Links_CreatedBy
    FOREIGN KEY (CreatedBy)
    REFERENCES System_Users(Id)

ALTER TABLE Data_Links NOCHECK CONSTRAINT Data_Links_UpdatedBy
ALTER TABLE Data_Links NOCHECK CONSTRAINT Data_Links_CreatedBy