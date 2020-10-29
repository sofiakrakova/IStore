#Drop data and reset index
DELETE FROM settings WHERE id>0;
ALTER TABLE settings AUTO_INCREMENT = 1;

#Insert
INSERT INTO settings VALUES 
(default, 'AesKey', '6kTLFK501oqlVe6z9QkR5IbIDdcRetwEqKpFdr+j4ac='),
(default, 'AesIV', 'kvSia81oXPv+/wsRjgdqJw==');

#SELECT * FROM settings;