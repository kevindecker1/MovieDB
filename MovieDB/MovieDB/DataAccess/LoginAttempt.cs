using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MovieDB
{
    public class LoginAttempt
    {
        [PrimaryKey, AutoIncrement, Indexed]
        public int ID { get; set; }

        [Indexed]
        public int? UserID { get; set; }
        public string EnteredUsername { get; set; }
        public DateTime? DateOfAttempt { get; set; }
        public bool WasSuccessful { get; set; }
        public string FailureReason { get; set; }
    }
}
