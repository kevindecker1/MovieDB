using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDB
{
    public class Interfaces
    {
        public interface IStartService
        {
            void StartBackgroundService();
        }

        public interface ICleanupRecentSearchService
        {
            void CleanupUserRecentSearches();
        }
    }
}
