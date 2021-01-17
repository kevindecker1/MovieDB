using System;
using System.Collections.Generic;
using System.Text;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using Xamarin.Essentials;
using System.Globalization;
using System.ComponentModel;

namespace MovieDB
{
    public class Session
    {
        public Session() 
        {
            this.RecentSearches = new List<string>();
        }

        public User User { get; set; }
        public CultureInfo Culture { get; set; }
        public List<string> RecentSearches { get; set; }
        public bool IsUserLoggedIn { get; set; }
        public bool IsGuest { get; set; }

        // User Preferences (Stored in Preference table)
        public int ListCount { get; set; }
        public string ThemeColor { get; set; }
        public bool TouchSoundEnabled { get; set; }

        // Theatre / Zip??
    }

    public static class SessionExtensions
    {
        public static object GetSessionValue(string key)
        {
            var obj = App.Current.Properties[key];
            if (obj == null) { return string.Empty; }
            return obj;
        }

        public static void SetSessionValue(string key, object value)
        {
            App.Current.Properties[key] = value;
        }

        public static Session CreateGuestSession()
        {
            var session = new Session();
            session.SetSessionDefaultsForGuest();

            return session;
        }

        public static Session GetSession()
        {
            Session session = null;
            try
            {
                session = (Session)App.Current.Properties["session"];
            }
            catch { }

            return session;
        }

        public static void ClearSession(this Session session)
        {
            App.Current.Properties["session"] = null;
        }

        public static void SetSessionDefaultsForGuest(this Session session)
        {
            if (session != null)
            {
                session.IsUserLoggedIn = false;
                session.Culture = CultureInfo.CurrentCulture;
                session.ThemeColor = "Default";
                session.ListCount = 50;
                session.IsGuest = true;
            }
        }

        public static string GetSessionFirstName(this Session session)
        {
            string firstName = "";
            if (session != null)
            {
                if (session.IsUserLoggedIn)
                {
                    firstName = session.User.FirstName;
                }
                else
                {
                    firstName = "There";
                }
            }

            return firstName;
        }

        public static void AddRecentSearch(this Session session, string searchQuery)
        {
            if (session != null)
            {
                if(session.RecentSearches == null) { session.RecentSearches = new List<string>(); }
                session.RecentSearches.Add(searchQuery);
            }
        }

        public static List<string> GetRecentSearches(this Session session)
        {
            List<string> searches = new List<string>();
            if (session != null)
            {
                if (session.RecentSearches == null) { session.RecentSearches = new List<string>(); }
                searches = session.RecentSearches;
            }

            return searches;
        }
    }
}
