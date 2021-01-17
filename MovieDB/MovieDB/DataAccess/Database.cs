using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using SQLite;
using Plugin.Settings.Abstractions;
using Plugin.Settings;
using System.Linq;

namespace MovieDB.DataAccess
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<User>().Wait();
            _database.CreateTableAsync<LoginAttempt>().Wait();
            _database.CreateTableAsync<Preference>().Wait();
            _database.CreateTableAsync<RecentSearch>().Wait();
        }

        //  Authenticate User
        public Session Authenticate(string username, string password)
        {
            var user = _database.Table<User>().Where(x => x.Username == username && x.Password == password).FirstOrDefaultAsync().Result;
            if (user == null) { return null; }

            // Fill the basic Settings
            Session session = new Session();
            session.User = user;
            session.Culture = CultureInfo.CurrentCulture;
            session.IsUserLoggedIn = true;
            session.IsGuest = false;

            // Preferences
            var preferences = App.Database.GetPreferencesByUserAsync(user.ID).Result;
            Preference listCount = preferences.Where(x => x.PreferenceName == "ListCount").FirstOrDefault();
            Preference themeColor = preferences.Where(x => x.PreferenceName == "ThemeColor").FirstOrDefault();
            if (preferences.Count == 0)
            {
                // Could be first time user, let's set some defaults
                listCount = new Preference() { PreferenceName = "ListCount", UserID = user.ID, Value = "50" };
                App.Database.SavePreferenceAsync(listCount);

                themeColor = new Preference() { PreferenceName = "ThemeColor", UserID = user.ID, Value = "Default" };
                App.Database.SavePreferenceAsync(themeColor);
            }

            session.ListCount = listCount.Value.ToInt32(); 
            session.ThemeColor = themeColor.Value; 

            // Let's limit to the 5 most recent searches
            // Plan on creating a background task that deletes old searches
            var recentSearches = App.Database.GetRecentSearchesByUserAsync(user.ID).Result.OrderByDescending(x => x.WhenSearched).Take(5);
            foreach (RecentSearch search in recentSearches)
            {
                session.AddRecentSearch(search.SearchText);
            }

            // More settings to come...

            SessionExtensions.SetSessionValue("session", session);

            return session;
        }

        // User actions
        public Task<List<User>> GetUsersAsync()
        {
            return _database.Table<User>().ToListAsync();
        }

        public Task<User> GetUserByUsernameAsync(string username)
        {
            return _database.Table<User>().Where(x => x.Username == username).FirstOrDefaultAsync();
        }

        public bool IsUsernameAvailable(string username)
        {
            var users = GetUsersAsync().Result;

            return !(users.Where(x => x.Username.Equals(username)).Any());
        }

        public Task<int> SaveUserAsync(User user)
        {
            return _database.InsertAsync(user);
        }

        public Task<int> DeleteUserAsync(User user)
        {
            return _database.DeleteAsync(user);
        }

        // Login Attempt actions

        public Task<List<LoginAttempt>> GetLoginAttemptsByUserAsync(int userID)
        {
            return _database.Table<LoginAttempt>().Where(x => x.UserID == userID).ToListAsync();
        }

        public Task<List<LoginAttempt>> GetLoginAttemptsByDateAsync(DateTime date)
        {
            return _database.Table<LoginAttempt>().Where(x => x.DateOfAttempt == date).ToListAsync();
        }

        public Task<int> SaveLoginAttemptAsync(LoginAttempt loginAttempt)
        {
            return _database.InsertAsync(loginAttempt);
        }

        // Preference actions

        public Task<List<Preference>> GetPreferencesByUserAsync(int userID)
        {
            return _database.Table<Preference>().Where(x => x.UserID == userID).ToListAsync();
        }

        public Task<int> SavePreferenceAsync(Preference preference)
        {
            return _database.InsertAsync(preference);
        }

        public Task<Preference> GetUserPreferenceByNameAsync(int userID, string preferenceName)
        {
            return _database.Table<Preference>().Where(x => x.UserID == userID && x.PreferenceName == preferenceName).FirstOrDefaultAsync();
        }

        // Recent Search actions

        public Task<List<RecentSearch>> GetRecentSearchesByUserAsync(int userID)
        {
            return _database.Table<RecentSearch>().Where(x => x.UserID == userID).ToListAsync();
        }

        public Task<int> SaveRecentSearchAsync(RecentSearch search)
        {
            return _database.InsertAsync(search);
        }

        public Task<int> DeleteUserRecentSearchesAsync(List<RecentSearch> recentSearches)
        {
            return _database.DeleteAsync(recentSearches);
        }
    }
}
