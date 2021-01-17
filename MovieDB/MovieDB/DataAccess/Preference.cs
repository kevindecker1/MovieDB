using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MovieDB.DataAccess
{
    public class Preference
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string PreferenceName { get; set; }
        public int UserID { get; set; }
        public string Value { get; set; }
    }
}
