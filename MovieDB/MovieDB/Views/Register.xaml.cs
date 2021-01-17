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
    public partial class Register : ContentPage
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            // Register user
            if (isValid())
            {
                User newUser = new User();
                newUser.Username = eUsername.Text;
                newUser.Password = ePassword.Text;
                newUser.FirstName = eFirstName.Text;
                newUser.LastName = eLastName.Text;
                newUser.Email = eEmail.Text;
                newUser.WhenLastLoggedIn = DateTime.Now.ToLocalTime();

                App.Database.SaveUserAsync(newUser);

                LoginAttempt loginAttempt = new LoginAttempt();
                loginAttempt.EnteredUsername = eUsername.Text;
                loginAttempt.DateOfAttempt = DateTime.Now.ToLocalTime();
                loginAttempt.WasSuccessful = false;
                loginAttempt.FailureReason = "User does not exist.";

                Session session = null;
                try
                {
                    session = App.Database.Authenticate(eUsername.Text, ePassword.Text);
                }
                catch(Exception ex) 
                {
                    loginAttempt.FailureReason = ex.Message;
                }

                if (session != null)
                {
                    loginAttempt.WasSuccessful = true;
                    loginAttempt.FailureReason = "";
                    loginAttempt.UserID = session.User.ID;
                }

                App.Database.SaveLoginAttemptAsync(loginAttempt);

                if (session != null)
                {
                    // Send to Dashboard
                    Navigation.SendTo(typeof(Dashboard));
                }
            }
        }

        private bool isValid()
        {
            // Username must be filled in
            if (!eUsername.Text.HasValue()) { return false; }
            // Checks the database to see if username is available
            if (!App.Database.IsUsernameAvailable(eUsername.Text)) { return false; }

            // Checks if it's a valid password
            if (!PasswordValidator.IsValidPassword(ePassword.Text)) { return false; }
            // Checks if Password and ConfirmPassword fields match
            if (!PasswordValidator.PasswordsMatch(ePassword.Text, eConfirmPassword.Text)) { return false; }

            // First Name must be filled in
            if (!eFirstName.Text.HasValue()) { return false; }
            // Last Name must be filled in
            if (!eLastName.Text.HasValue()) { return false; }
            // Email must be filled in
            if (!eEmail.Text.HasValue()) { return false; }

            // Checks to see if the Email is in valid format
            if (!Missing.ValidEmailAddress(eEmail.Text))
            {
                return false;
            }

            return true;
        }

        private void eConfirmPassword_Unfocused(object sender, FocusEventArgs e)
        {
            bool passwordsMatch = true;
            if (ePassword.Text.HasValue())
            {
                passwordsMatch = PasswordValidator.PasswordsMatch(ePassword.Text, eConfirmPassword.Text);
            }

            if (!passwordsMatch)
            {
                // show validation error
            }
        }
    }
}