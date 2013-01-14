

     
ALTER TABLE Marketing_Blogs
ADD CONSTRAINT Marketing_Blogs_OrganizationId
    FOREIGN KEY (OrganizationId)
    REFERENCES Logistics_Organizations(Id)