using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MovieDB.Droid.Extras;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: Xamarin.Forms.Dependency(typeof(StatusBar))]
namespace MovieDB.Droid.Extras
{
    public interface IStatusBarPlatformSpecific
    {
        public void SetStatusBarColor(Color color);
    }

    public class StatusBar : IStatusBarPlatformSpecific
    {
        public void SetStatusBarColor(Color color)
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                var androidColor = color.ToAndroid();
                //Xamarin.Essentials.Platform.CurrentActivity.Window.SetStatusBarColor(androidColor);
                //Xamarin.Essentials.Platform.CurrentActivity.Window.SetStatusBarColor(androidColor);
            }
        }
    }
}