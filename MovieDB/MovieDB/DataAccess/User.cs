using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MovieDB
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [MaxLength(20), Unique]
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime? WhenLastLoggedIn { get; set; }
        public byte[] Image { get; set; }
    }
}
