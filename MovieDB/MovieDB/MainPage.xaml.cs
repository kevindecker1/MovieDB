using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MovieDB;

namespace MovieDB
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            menuList.ItemsSource = GetMenuItems();

            var loginPage = typeof(Login);
            Detail = new NavigationPage((Page)Activator.CreateInstance(loginPage));

            IsPresented = false;
        }

        private List<MenuItem> GetMenuItems()
        {
            var list = new List<MenuItem>();

            list.Add(new MenuItem()
            {
                Text = "Home",
                Detail = "Dashboard",
                ImagePath = "home.png",
                TargetPage = typeof(Dashboard)
            });

            list.Add(new MenuItem()
            {
                Text = "Movies",
                Detail = "Search Movies",
                ImagePath = "movie.png",
                TargetPage = typeof(MovieSearch)
            });

            list.Add(new MenuItem()
            {
                Text = "TV Shows",
                Detail = "Search TV Shows",
                ImagePath = "tvshow.png",
                TargetPage = typeof(TVShowSearch)
            });

            list.Add(new MenuItem()
            {
                Text = "People",
                Detail = "Search People",
                ImagePath = "person.png",
                TargetPage = typeof(PeopleSearch)
            });

            list.Add(new MenuItem()
            {
                Text = "Settings",
                Detail = "Account Settings",
                ImagePath = "settings.png",
                TargetPage = typeof(Settings)
            });

            return list;
        }

        private void menuList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedMenuItem = (MenuItem)e.SelectedItem;
            Type selectedPage = selectedMenuItem.TargetPage;
            Detail = new NavigationPage((Page)Activator.CreateInstance(selectedPage));
            IsPresented = false;
        }
    }
}
