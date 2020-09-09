#Drop data and reset index
DELETE FROM categories WHERE id>0;
ALTER TABLE categories AUTO_INCREMENT = 1;

#Insert top categories
INSERT INTO categories VALUE(NULL, NULL, 'Electronics', 0);
INSERT INTO categories VALUE(NULL, NULL, 'Computers', 0);
INSERT INTO categories VALUE(NULL, NULL, 'Automotive', 0);
INSERT INTO categories VALUE(NULL, NULL, 'Beauty and personal care', 0);
INSERT INTO categories VALUE(NULL, NULL, 'Home and Kitchen', 0);
INSERT INTO categories VALUE(NULL, NULL, 'Sports and Outdoors', 0);
INSERT INTO categories VALUE(NULL, NULL, 'Video Games', 0);

#Insert child categories
INSERT INTO categories VALUE(NULL, 1, 'Accessories &amp; Supplies', 0);
INSERT INTO categories VALUE(NULL, 1, 'Camera &amp; Photo', 0);
INSERT INTO categories VALUE(NULL, 1, 'Car &amp; Vehicle Electronics', 0);
INSERT INTO categories VALUE(NULL, 1, 'Cell Phones &amp; Accessories', 0);
INSERT INTO categories VALUE(NULL, 1, 'Computers &amp; Accessories', 0);
INSERT INTO categories VALUE(NULL, 1, 'GPS &amp; Navigation', 0);
INSERT INTO categories VALUE(NULL, 1, 'Headphones', 0);
INSERT INTO categories VALUE(NULL, 1, 'Home Audio', 0);
INSERT INTO categories VALUE(NULL, 1, 'Office Electronics', 0);
INSERT INTO categories VALUE(NULL, 1, 'Portable Audio &amp; Video', 0);
INSERT INTO categories VALUE(NULL, 1, 'Security &amp; Surveillance', 0);
INSERT INTO categories VALUE(NULL, 1, 'Service Plans', 0);
INSERT INTO categories VALUE(NULL, 1, 'Television &amp; Video', 0);
INSERT INTO categories VALUE(NULL, 1, 'Video Game Consoles &amp; Accessories', 0);
INSERT INTO categories VALUE(NULL, 1, 'Video Projectors', 0);
INSERT INTO categories VALUE(NULL, 1, 'Wearable Technology', 0);
INSERT INTO categories VALUE(NULL, 1, 'eBook Readers &amp; Accessories', 0);
INSERT INTO categories VALUE(NULL, 2, 'Computer Accessories &amp; Peripherals', 0);
INSERT INTO categories VALUE(NULL, 2, 'Computer Components', 0);
INSERT INTO categories VALUE(NULL, 2, 'Computers &amp; Tablets', 0);
INSERT INTO categories VALUE(NULL, 2, 'Data Storage', 0);
INSERT INTO categories VALUE(NULL, 2, 'External Components', 0);
INSERT INTO categories VALUE(NULL, 2, 'Laptop Accessories', 0);
INSERT INTO categories VALUE(NULL, 2, 'Monitors', 0);
INSERT INTO categories VALUE(NULL, 2, 'Networking Products', 0);
INSERT INTO categories VALUE(NULL, 2, 'Power Strips &amp; Surge Protectors', 0);
INSERT INTO categories VALUE(NULL, 2, 'Printers', 0);
INSERT INTO categories VALUE(NULL, 2, 'Scanners', 0);
INSERT INTO categories VALUE(NULL, 2, 'Servers', 0);
INSERT INTO categories VALUE(NULL, 2, 'Tablet Accessories', 0);
INSERT INTO categories VALUE(NULL, 2, 'Tablet Replacement Parts', 0);
INSERT INTO categories VALUE(NULL, 2, 'Warranties &amp; Services', 0);
INSERT INTO categories VALUE(NULL, 3, 'Car Care', 0);
INSERT INTO categories VALUE(NULL, 3, 'Car Electronics &amp; Accessories', 0);
INSERT INTO categories VALUE(NULL, 3, 'Exterior Accessories', 0);
INSERT INTO categories VALUE(NULL, 3, 'Interior Accessories', 0);
INSERT INTO categories VALUE(NULL, 3, 'Lights &amp; Lighting Accessories', 0);
INSERT INTO categories VALUE(NULL, 3, 'Motorcycle &amp; Powersports', 0);
INSERT INTO categories VALUE(NULL, 3, 'Oils &amp; Fluids', 0);
INSERT INTO categories VALUE(NULL, 3, 'Paint &amp; Paint Supplies', 0);
INSERT INTO categories VALUE(NULL, 3, 'Performance Parts &amp; Accessories', 0);
INSERT INTO categories VALUE(NULL, 3, 'Replacement Parts', 0);
INSERT INTO categories VALUE(NULL, 3, 'RV Parts &amp; Accessories', 0);
INSERT INTO categories VALUE(NULL, 3, 'Tires &amp; Wheels', 0);
INSERT INTO categories VALUE(NULL, 3, 'Tools &amp; Equipment', 0);
INSERT INTO categories VALUE(NULL, 3, 'Automotive Enthusiast Merchandise', 0);
INSERT INTO categories VALUE(NULL, 3, 'Heavy Duty &amp; Commercial Vehicle Equipment', 0);
INSERT INTO categories VALUE(NULL, 4, 'Makeup', 0);
INSERT INTO categories VALUE(NULL, 4, 'Skin Care', 0);
INSERT INTO categories VALUE(NULL, 4, 'Hair Care', 0);
INSERT INTO categories VALUE(NULL, 4, 'Fragrance', 0);
INSERT INTO categories VALUE(NULL, 4, 'Foot, Hand &amp; Nail Care', 0);
INSERT INTO categories VALUE(NULL, 4, 'Tools &amp; Accessories', 0);
INSERT INTO categories VALUE(NULL, 4, 'Shave &amp; Hair Removal', 0);
INSERT INTO categories VALUE(NULL, 4, 'Personal Care', 0);
INSERT INTO categories VALUE(NULL, 4, 'Oral Care', 0);
INSERT INTO categories VALUE(NULL, 5, 'Kids Home Store', 0);
INSERT INTO categories VALUE(NULL, 5, 'Kitchen &amp; Dining', 0);
INSERT INTO categories VALUE(NULL, 5, 'Bedding', 0);
INSERT INTO categories VALUE(NULL, 5, 'Bath', 0);
INSERT INTO categories VALUE(NULL, 5, 'Furniture', 0);
INSERT INTO categories VALUE(NULL, 5, 'Home Décor', 0);
INSERT INTO categories VALUE(NULL, 5, 'Wall Art', 0);
INSERT INTO categories VALUE(NULL, 5, 'Lighting &amp; Ceiling Fans', 0);
INSERT INTO categories VALUE(NULL, 5, 'Seasonal Décor', 0);
INSERT INTO categories VALUE(NULL, 5, 'Event &amp; Party Supplies', 0);
INSERT INTO categories VALUE(NULL, 5, 'Heating, Cooling &amp; Air Quality', 0);
INSERT INTO categories VALUE(NULL, 5, 'Irons &amp; Steamers', 0);
INSERT INTO categories VALUE(NULL, 5, 'Vacuums &amp; Floor Care', 0);
INSERT INTO categories VALUE(NULL, 5, 'Storage &amp; Organization', 0);
INSERT INTO categories VALUE(NULL, 5, 'Cleaning Supplies', 0);
INSERT INTO categories VALUE(NULL, 6, 'Sports and Outdoors', 0);
INSERT INTO categories VALUE(NULL, 6, 'Outdoor Recreation', 0);
INSERT INTO categories VALUE(NULL, 6, 'Sports &amp; Fitness', 0);
INSERT INTO categories VALUE(NULL, 6, 'Fan Shop', 0);
INSERT INTO categories VALUE(NULL, 7, 'Video Games', 0);
INSERT INTO categories VALUE(NULL, 7, 'PlayStation 4', 0);
INSERT INTO categories VALUE(NULL, 7, 'PlayStation 3', 0);
INSERT INTO categories VALUE(NULL, 7, 'Xbox One', 0);
INSERT INTO categories VALUE(NULL, 7, 'Xbox 360', 0);
INSERT INTO categories VALUE(NULL, 7, 'Nintendo Switch', 0);
INSERT INTO categories VALUE(NULL, 7, 'Wii U', 0);
INSERT INTO categories VALUE(NULL, 7, 'Wii', 0);
INSERT INTO categories VALUE(NULL, 7, 'PC', 0);
INSERT INTO categories VALUE(NULL, 7, 'Mac', 0);
INSERT INTO categories VALUE(NULL, 7, 'Nintendo 3DS &amp; 2DS', 0);
INSERT INTO categories VALUE(NULL, 7, 'Nintendo DS', 0);
INSERT INTO categories VALUE(NULL, 7, 'PlayStation Vita', 0);
INSERT INTO categories VALUE(NULL, 7, 'Sony PSP', 0);
INSERT INTO categories VALUE(NULL, 7, 'Retro Gaming &amp; Microconsoles', 0);
INSERT INTO categories VALUE(NULL, 7, 'Accessories', 0);
INSERT INTO categories VALUE(NULL, 7, 'Digital Games', 0);
INSERT INTO categories VALUE(NULL, 7, 'Kids &amp; Family', 0);

#SELECT * FROM categories;