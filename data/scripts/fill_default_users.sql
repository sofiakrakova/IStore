#Drop data and reset index
DELETE FROM users WHERE id>0;
ALTER TABLE users AUTO_INCREMENT = 1;

#admin - admin
#user - user
INSERT INTO users VALUE(NULL, 'Default administrator', 'admin@istore.com', '$2b$10$n45gXcwVp4Niyr385xh.CevsQWP3xRNCck/fLJ6Honn4URJMV6VgK', curdate(), NULL, 1);
INSERT INTO users VALUE(NULL, 'Default user', 'user@istore.com', '$2b$10$Jme/D8ENr09qQYcydWHknOQ2LA0RoUYPLJjfKiTjkWW3I5jdgkdnu', curdate(), NULL, 2);