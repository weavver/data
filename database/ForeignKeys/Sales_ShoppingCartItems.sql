
ALTER TABLE Sales_ShoppingCartItems WITH NOCHECK
ADD CONSTRAINT Sales_ShoppingCartItems_UpdatedBy
    FOREIGN KEY (UpdatedBy)
    REFERENCES System_Users(Id)

ALTER TABLE Sales_ShoppingCartItems WITH NOCHECK
ADD CONSTRAINT Sales_ShoppingCartItems_CreatedBy
    FOREIGN KEY (CreatedBy)
    REFERENCES System_Users(Id)

ALTER TABLE Sales_ShoppingCartItems
     NOCHECK CONSTRAINT Sales_ShoppingCartItems_UpdatedBy

ALTER TABLE Sales_ShoppingCartItems
     NOCHECK CONSTRAINT Sales_ShoppingCartItems_CreatedBy