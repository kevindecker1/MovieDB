using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using System.Linq;

namespace MovieDB
{
    public partial class App : Application
    {
        static MovieDB.DataAccess.Database database;
        static MovieDB.Session session;

        public static DataAccess.Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new DataAccess.Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "app.db3"));
                }
                return database;
            }
        }

        public static Session Session
        {
            get
            {
                if (session == null)
                {
                    session = SessionExtensions.GetSession();
                }
                return session;
            }
        }

        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            MainPage = new NavigationPage(new MainPage());

            var enumName = Enums.Preferences.ListCount.GetName();

            Session session = SessionExtensions.CreateGuestSession();
            if (Remember.RememberMe)
            {
                var username = Remember.LastUsedUsername;
                var password = Remember.LastUsedPassword;

                session = App.Database.Authenticate(username, password);

                var settingsModel = new ViewModels.SettingsModel();
                var themeDictionary = settingsModel.ThemeColorsDictionary.Where(x => x.Key == session.ThemeColor).FirstOrDefault();
                Missing.UpdateAppTheme(session.ThemeColor, Color.FromHex(themeDictionary.Value));
            }

            SessionExtensions.SetSessionValue("session", session);
        }

        protected override void OnStart()
        {
            StartBackgroundService();
        }

        protected override void OnSleep()
        {
            if (App.Session != null && (!App.Session.IsUserLoggedIn || App.Session.IsGuest))
            {
                App.Session.ClearSession();
            }
        }

        protected override void OnResume()
        {
        }

        private static void StartBackgroundService()
        {
            // Register services to our host
            BackgroundService.BackgroundServiceHost.Add(() => new BackgroundService.Services.CleanupRecentSearchService(20));

            // Start up the background service
            BackgroundService.BackgroundServiceHost.StartBackgroundService();
        }
    }
}
