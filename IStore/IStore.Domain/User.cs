﻿using System;

namespace IStore.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Credentials { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime Birthday { get; set; }
        public string Comment { get; set; }
        public UserRole UserRole { get; set; }
        
        public int UserRole_Id { get; }
    }
}
