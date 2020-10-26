#Drop data and reset index
DELETE FROM suppliers WHERE id>0;
ALTER TABLE suppliers AUTO_INCREMENT = 1;

#Insert
INSERT INTO suppliers VALUES
(NULL, 'American Eagle'), 
(NULL, 'Antop'), 
(NULL, 'Bonapack'), 
(NULL, 'Delta Inc.'), 
(NULL, 'Himatsingka Linens'), 
(NULL, 'Shivam Impex')