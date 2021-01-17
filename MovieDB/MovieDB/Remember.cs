using System;
using System.Collections.Generic;
using System.Text;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace MovieDB
{
    public static class Remember
    {
        private static ISettings RememberSettings => CrossSettings.Current;

        public static void Clear()
        {
            RememberSettings.Clear();
        }

        #region Setting Constants

        private const string LastUsedUsernameSettingsKey = "last_used_username_key";
        private const string LastUsedPasswordSettingsKey = "last_used_password_key";
        private const string RememberMeSettingsKey = "remember_me_key";
        private static readonly string SettingsDefault = string.Empty;
        private static readonly bool BooleanSettingsDefault = false;

        #endregion

        public static string LastUsedUsername
        {
            get
            {
                return RememberSettings.GetValueOrDefault(LastUsedUsernameSettingsKey, SettingsDefault);
            }
            set 
            {
                RememberSettings.AddOrUpdateValue(LastUsedUsernameSettingsKey, value);
            }
        }

        public static string LastUsedPassword
        {
            get
            {
                return RememberSettings.GetValueOrDefault(LastUsedPasswordSettingsKey, SettingsDefault);
            }
            set
            {
                RememberSettings.AddOrUpdateValue(LastUsedPasswordSettingsKey, value);
            }
        }

        public static bool RememberMe
        {
            get
            {
                return RememberSettings.GetValueOrDefault(RememberMeSettingsKey, BooleanSettingsDefault);
            }
            set
            {
                RememberSettings.AddOrUpdateValue(RememberMeSettingsKey, value);
            }
        }

        //private const string UsernameKey = "Username";
        //private static readonly string UsernameDefault = string.Empty;
        //public static string Username
        //{
        //    get => AppSettings.GetValueOrDefault(UsernameKey, UsernameDefault);
        //    set => AppSettings.AddOrUpdateValue(UsernameKey, value);
        //}

        //private const string PasswordKey = "Password";
        //private static readonly string PasswordDefault = string.Empty;

        //public static string Password
        //{
        //    get => AppSettings.GetValueOrDefault(PasswordKey, PasswordDefault);
        //    set => AppSettings.AddOrUpdateValue(PasswordKey, value);
        //}

        //private const string RememberMe = "RememberMe";
        //private static readonly string RememberMeDefault = "false";

        //public static string GetRememberMe
        //{
        //    get => AppSettings.GetValueOrDefault(RememberMe, RememberMeDefault);
        //    set => AppSettings.AddOrUpdateValue(RememberMe, value);
        //}
    }
}
