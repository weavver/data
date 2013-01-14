


ALTER TABLE KnowledgeBase WITH NOCHECK
ADD CONSTRAINT KnowledgeBase_ParentId
    FOREIGN KEY (ParentId)
    REFERENCES KnowledgeBase(Id)


ALTER TABLE KnowledgeBase
ADD CONSTRAINT KnowledgeBase_UpdatedBy
    FOREIGN KEY (UpdatedBy)
    REFERENCES System_Users(Id),
CONSTRAINT KnowledgeBase_CreatedBy
    FOREIGN KEY (CreatedBy)
    REFERENCES System_Users(Id)
