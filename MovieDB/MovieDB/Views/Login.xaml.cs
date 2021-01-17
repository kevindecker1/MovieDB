using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MovieDB
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();

            if (Remember.RememberMe)
            {
                ieUsername.Text = Remember.LastUsedUsername;
                iePassword.Text = Remember.LastUsedPassword;
                chkRememberMe.IsChecked = true;

                // Auto Login user? 
                //var session = App.Database.Authenticate(ieUsername.Text, iePassword.Text);
                //if (session != null)
                //{

                //}
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (Remember.RememberMe)
            {
                ieUsername.Text = Remember.LastUsedUsername;
                iePassword.Text = Remember.LastUsedPassword;
                chkRememberMe.IsChecked = true;

                // Auto Login user? 
            }
        }

        private void Handle_Clicked(object sender, EventArgs args)
        {
            Navigation.SendTo(typeof(Dashboard));
        }

        private async void LoginButton_Clicked(object sender, EventArgs ars)
        {
            var username = ieUsername.Text;
            var password = iePassword.Text;

            bool validCredentials = username.HasValue() && password.HasValue();

            if (validCredentials)
            {
                LoginAttempt loginAttempt = new LoginAttempt();
                loginAttempt.EnteredUsername = username;
                loginAttempt.DateOfAttempt = DateTime.Now.ToLocalTime();

                Session session = null;
                try
                {
                    session = App.Database.Authenticate(username, password);
                }
                catch (Exception ex)
                {
                    // Need to show an error message 
                }

                loginAttempt.WasSuccessful = false;
                loginAttempt.FailureReason = "User does not exist.";

                bool proceedToDashboard = false;
                if (session != null && session.User != null)
                {
                    proceedToDashboard = true;
                    loginAttempt.UserID = session.User.ID;
                    loginAttempt.WasSuccessful = true;
                }

                await App.Database.SaveLoginAttemptAsync(loginAttempt);

                if (proceedToDashboard)
                {
                    await Navigation.PushAsync(new Dashboard());
                }
            }
        }

        private void chkRememberMe_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (chkRememberMe.IsChecked)
            {
                Remember.RememberMe = true;
                Remember.LastUsedUsername = ieUsername.Text;
                Remember.LastUsedPassword = iePassword.Text;
            }
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            // Navigate to Register page
            await Navigation.PushAsync(new Register());
        }
    }
}