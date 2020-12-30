#Drop data and reset index
DELETE FROM istoredb.supplier_products WHERE id>0;
ALTER TABLE istoredb.supplier_products AUTO_INCREMENT = 1;

INSERT INTO istoredb.supplier_products
VALUES
(NULL, 2, 1, 2),
(NULL, 2, 2, 2), 
(NULL, 3, 8, 5), 
(NULL, 3, 9, 3), 
(NULL, 5, 11, 2);