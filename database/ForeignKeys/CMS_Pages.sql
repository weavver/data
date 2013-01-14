

ALTER TABLE CMS_Pages WITH NOCHECK
ADD
    CONSTRAINT CMS_Pages_CreatedBy
    FOREIGN KEY (CreatedBy)
    REFERENCES System_Users(Id)

ALTER TABLE CMS_Pages WITH NOCHECK
ADD CONSTRAINT CMS_Pages_UpdatedBy
    FOREIGN KEY (UpdatedBy)
    REFERENCES System_Users(Id)