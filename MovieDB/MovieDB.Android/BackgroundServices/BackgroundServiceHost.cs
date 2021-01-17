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
using Xamarin.Forms;
using MovieDB.Droid;

namespace MovieDB.Droid.BackgroundServices
{
    public class BackgroundServiceHost
    {
        public static void Init(ContextWrapper context)
        {
            MessagingCenter.Subscribe<BackgroundService.StartTask>(context, nameof(BackgroundService.StartTask), message =>
            {
                var intent = new Intent(context, typeof(AndroidService));
                context.StartService(intent);
            });

            MessagingCenter.Subscribe<BackgroundService.StopTask>(context, nameof(BackgroundService.StopTask), message =>
            {
                var intent = new Intent(context, typeof(AndroidService));
                context.StopService(intent);
            });
        }
    }
}