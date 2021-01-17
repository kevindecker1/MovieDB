using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.BackgroundService.Services
{
    public class CleanupRecentSearchService : IPeriodicTask
    {
        public TimeSpan Interval { get; set; }

        public CleanupRecentSearchService(int seconds)
        {
            Interval = TimeSpan.FromSeconds(seconds);
        }

        public async Task<bool> StartJob()
        {
            // Custom logic
            var db = App.Database;
            var session = App.Session;
            if (session.User != null)
            {
                try
                {
                    var searches = await db.GetRecentSearchesByUserAsync(session.User.ID);
                    var mostRecentSearches = searches.OrderByDescending(x => x.WhenSearched).Take(10);

                    var searchesToRemove = searches.Except(mostRecentSearches).ToList();

                    await db.DeleteUserRecentSearchesAsync(searchesToRemove);
                }
                catch (Exception ex)
                {
                    
                }
            }
            
            return true;
        }
    }
}
