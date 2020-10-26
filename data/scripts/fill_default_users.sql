#Drop data and reset index
DELETE FROM users WHERE id>0;
ALTER TABLE users AUTO_INCREMENT = 1;

INSERT INTO users VALUES
(NULL, 'Default administrator', 'admin@istore.com', '$2b$10$n45gXcwVp4Niyr385xh.CevsQWP3xRNCck/fLJ6Honn4URJMV6VgK', curdate(), NULL, 1), #pass = admin
(NULL, 'Default user', 'user@istore.com', '$2b$10$Jme/D8ENr09qQYcydWHknOQ2LA0RoUYPLJjfKiTjkWW3I5jdgkdnu', curdate(), NULL, 2), #pass = user
(NULL, 'Daria Eliseeva', 'deliseeva@istore.com', '$2b$10$pdaAMIWQd9MyH/HK6K3q7uPt.Chr/J4aF7vGYAzcYrNlSh7a.ZYLu', '1990-10-04 0:00:00', 'Senior manager of \"Abby Tech\" Inc.', 2) #pass = qwerty123