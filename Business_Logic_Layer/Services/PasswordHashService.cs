using System;
using System.Collections.Generic;
using System.Text;
using BCrypt.Net;

namespace Business_Logic_Layer.Services
{
    public class PasswordHashService 
    {
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
