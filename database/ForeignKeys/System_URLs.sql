


ALTER TABLE [System_URLs] WITH NOCHECK
ADD CONSTRAINT System_URLs_UpdatedBy
    FOREIGN KEY (UpdatedBy)
    REFERENCES System_Users(Id)

ALTER TABLE [System_URLs] WITH NOCHECK
ADD CONSTRAINT System_URLs_CreatedBy
    FOREIGN KEY (CreatedBy)
    REFERENCES System_Users(Id)