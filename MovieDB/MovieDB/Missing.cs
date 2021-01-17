using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Globalization;
using Xamarin.Forms;

namespace MovieDB
{
    public static class Missing
    {
        public static string GetName(this Enum value)
        {
            var enumName = string.Empty;
            var customAttributes = value.GetReflectedPropertyValue("CustomAttributes");
            //if (customAttributes)
            //{

            //}

            return enumName;
        }

        public static List<string> ToStringList(this string value, string separator = ",")
        {
            if (!value.HasValue()) { return new List<string>(); }
            return value.Split(separator).ToList();
        }

        public static string RemoveHtmlTags(this string value)
        {
            if (!value.HasValue()) { return string.Empty; }

            // Let's check to see if the string value even has html in it
            bool containsHtml = Regex.IsMatch(value, @"<(\s*[(\/?)\w+]*)", RegexOptions.IgnoreCase);
            if (containsHtml)
            {
                value = Regex.Replace(value, "<.*?>", string.Empty);
            }

            return value;
        }

        public static void SendTo(this INavigation navComponent, Type destPage)
        {
            MasterDetailPage masterPage = (MasterDetailPage)App.Current.MainPage.GetReflectedPropertyValue("RootPage");

            masterPage.Detail = new NavigationPage((Page)Activator.CreateInstance(destPage));
            masterPage.IsPresented = false;
        }

        public static Page GetMasterPage()
        {
            var page = (MasterDetailPage)App.Current.MainPage.GetReflectedPropertyValue("RootPage");
            return page.Master;
        }

        public static void UpdateAppTheme(string selectedTheme, Xamarin.Forms.Color themeColorToApply)
        {
            // Setting the new theme color on the Navigation slide-out
            Page masterPage = Missing.GetMasterPage();
            masterPage.BackgroundColor = themeColorToApply;

            var navBarColorToApply = themeColorToApply;
            if (selectedTheme == "Default")
            {
                navBarColorToApply = Color.FromHex("#009dff");
            }
            // Setting the new theme color on the top nav bar
            App.Current.Resources["navBarColor"] = navBarColorToApply;
        }

        public static string Capitalize(this string value)
        {
            if(String.IsNullOrEmpty(value)) { return string.Empty; }

            return value.First().ToString().ToUpper() + value.Substring(1);
        }

        public static string FormatMovieImageUrl(this string url)
        {
            return $"https://image.tmdb.org/t/p/w500{url}";
        }

        public static object GetReflectedPropertyValue(this object obj, string propertyName)
        {
            if (obj == null) { return new InvalidOperationException("The object does not have a value."); }

            Type t = obj.GetType();

            if (t == typeof(System.Data.DataRow))
            {
                var dataRow = (System.Data.DataRow)obj;
                if (dataRow != null)
                {
                    try
                    {
                        return dataRow[propertyName];
                    }
                    catch
                    {
                        return propertyName;
                    }
                }
            }
            else
            {
                PropertyInfo property = t.GetProperty(propertyName);
                if (property != null)
                {
                    return property.GetValue(obj, null);
                }

                FieldInfo field = t.GetField(propertyName);
                if (field != null)
                {
                    return field.GetValue(obj);
                }
            }

            return null;
        }

        public static bool ValidEmailAddress(string email)
        {
            if (!email.HasValue()) { return false; }

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper, RegexOptions.None, TimeSpan.FromMilliseconds(200));

                string DomainMapper(Match match)
                {
                    var idn = new IdnMapping();
                    string domainName = idn.GetAscii(match.Groups[2].Value);
                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
    }
}
