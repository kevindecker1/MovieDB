using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MovieDB.DataAccess
{
    public class RecentSearch
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public int UserID { get; set; }
        public string SearchText { get; set; }
        public DateTime? WhenSearched { get; set; }
    }
}
