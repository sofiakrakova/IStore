#Drop data and reset index
DELETE FROM categories WHERE id>0;
ALTER TABLE categories AUTO_INCREMENT = 1;

#Insert top categories
INSERT INTO categories VALUE(NULL, NULL, 'Electronics');
INSERT INTO categories VALUE(NULL, NULL, 'Computers');
INSERT INTO categories VALUE(NULL, NULL, 'Automotive');
INSERT INTO categories VALUE(NULL, NULL, 'Beauty and personal care');
INSERT INTO categories VALUE(NULL, NULL, 'Home and Kitchen');
INSERT INTO categories VALUE(NULL, NULL, 'Sports and Outdoors');


#Insert child categories
INSERT INTO categories VALUE(NULL, 1, 'Accessories & Supplies');
INSERT INTO categories VALUE(NULL, 1, 'Camera & Photo & Headphones');
INSERT INTO categories VALUE(NULL, 1, 'Car & Vehicle Electronics');
INSERT INTO categories VALUE(NULL, 1, 'Video Game Consoles & Accessories');

INSERT INTO categories VALUE(NULL, 2, 'Data Storage');
INSERT INTO categories VALUE(NULL, 2, 'Laptop Accessories');
INSERT INTO categories VALUE(NULL, 2, 'Monitors');

INSERT INTO categories VALUE(NULL, 3, 'Car Care');
INSERT INTO categories VALUE(NULL, 3, 'Car Electronics & Accessories');

INSERT INTO categories VALUE(NULL, 4, 'Makeup');
INSERT INTO categories VALUE(NULL, 4, 'Skin Care');
INSERT INTO categories VALUE(NULL, 4, 'Hair Care');

INSERT INTO categories VALUE(NULL, 5, 'Kids Home Store');
INSERT INTO categories VALUE(NULL, 5, 'Kitchen & Dining');
INSERT INTO categories VALUE(NULL, 5, 'Bedding');

INSERT INTO categories VALUE(NULL, 6, 'Sports and Outdoors');
INSERT INTO categories VALUE(NULL, 6, 'Outdoor Recreation');


#SELECT * FROM categories;