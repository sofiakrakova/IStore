#Drop data and reset index
DELETE FROM users WHERE id>0;
ALTER TABLE users AUTO_INCREMENT = 1;

INSERT INTO users VALUES

#email = admin@istore.com
#pass = admin
(NULL, 'oUQakkJXB8kem92su0kwBeGLdU3SFT4cySrIZUoOnl8=', 'ms+kd8GFK5lXitA0xHFFfRuitlgH4D50GxUpXD7Or4I=', '$2b$10$n45gXcwVp4Niyr385xh.CevsQWP3xRNCck/fLJ6Honn4URJMV6VgK', 'bIM6BJb+vFkBTam0PEtU4A==', 'tc/rN12QkJHfnLd3yMUcv2Bv7VBlneR+tjovXnZSpp1/IWSoHw2viF3rfFMDP4Q/', 1),

#email = user@istore.com
#pass = user
(NULL, 'Z+vdOE1jn6L4EUvOiefGlA==', 'ZpLIPTb6RPu3ahyvUegHiQ==', '$2b$10$Jme/D8ENr09qQYcydWHknOQ2LA0RoUYPLJjfKiTjkWW3I5jdgkdnu', 'bIM6BJb+vFkBTam0PEtU4A==', 'v3WGiuMrPuIwpuQKSPX42G034Idsbe0+expfakfk+B8=', 2);