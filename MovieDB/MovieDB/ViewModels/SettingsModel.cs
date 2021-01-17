using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace MovieDB.ViewModels
{
    public class SettingsModel 
    {
        public string SelectedTheme { get; set; }
        public Dictionary<string, string> ThemeColorsDictionary { get; set; }
        public List<string> ThemeColors { get; set; }
        public int ListCount { get; set; }

        public ICommand ThemeColor_SelectionCommand { get; private set; }
        public Session Session { get; set; }

        public SettingsModel()
        {
            SetDefaults();

            this.Session = App.Session;

            if (this.Session != null)
            {
                this.SelectedTheme = this.Session.ThemeColor;
                this.ListCount = this.Session.ListCount;
            }
        }

        public void SetDefaults()
        {
            this.ListCount = 50;

            this.ThemeColors = new List<string>();
            this.ThemeColors.Add("Default");
            this.ThemeColors.Add("Pastel Blue");
            this.ThemeColors.Add("Bezique (Green)");
            this.ThemeColors.Add("Purple");
            this.ThemeColors.Add("Red");

            this.ThemeColorsDictionary = new Dictionary<string, string>();
            this.ThemeColorsDictionary.Add("Default", "#e8e8e8");
            this.ThemeColorsDictionary.Add("Pastel Blue", "#779ecb");
            this.ThemeColorsDictionary.Add("Bezique (Green)", "#8abba6");
            this.ThemeColorsDictionary.Add("Purple", "#b19cd9");
            this.ThemeColorsDictionary.Add("Red", "#ff6961");

            this.SelectedTheme = "Default";

            this.ThemeColor_SelectionCommand = new Command(
                execute: () =>
                {
                    var selectedTheme = this.SelectedTheme;
                    var storedTheme = this.ThemeColorsDictionary.Where(x => x.Key == selectedTheme).FirstOrDefault();
                    if (storedTheme.Key.HasValue())
                    {
                        var hex = storedTheme.Value;
                        Xamarin.Forms.Color themeColorToApply = Color.FromHex(hex);

                        Missing.UpdateAppTheme(selectedTheme, themeColorToApply);

                        var ses = SessionExtensions.GetSession();
                        if (!this.Session.IsGuest && this.Session.IsUserLoggedIn)
                        {
                            var pref = App.Database.GetUserPreferenceByNameAsync(this.Session.User.ID, "ThemeColor").Result;
                            pref.Value = selectedTheme;
                            App.Database.SavePreferenceAsync(pref);
                        }

                        // Now we need to update the user preference for this
                        this.Session.ThemeColor = storedTheme.Key;
                    }
                }    
            );
        }
    }
}
