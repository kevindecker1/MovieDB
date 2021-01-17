using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MovieDB
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Settings : ContentPage
    {
        private ViewModels.SettingsModel _settingsModel;

        public Settings()
        {
            InitializeComponent();

            _settingsModel = new ViewModels.SettingsModel();
            BindingContext = _settingsModel;
        }

        private void listCountPreference_Completed(object sender, EventArgs e)
        {
            var element = (AiForms.Renderers.EntryCell)sender;
            var listCount = listCountPreference.ValueText;
            var session = App.Session;
            if (!session.IsGuest && session.IsUserLoggedIn)
            {
                var pref = App.Database.GetUserPreferenceByNameAsync(session.User.ID, Enums.Preferences.ListCount.GetName()); //"ListCount"
            }
        }
    }
}