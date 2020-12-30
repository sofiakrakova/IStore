#Drop data
DELETE FROM userroles WHERE id>0;

#Insert
INSERT INTO userroles VALUE(1, 'Administrator');
INSERT INTO userroles VALUE(2, 'User');
INSERT INTO userroles VALUE(3, 'Guest');

#SELECT * FROM userroles;