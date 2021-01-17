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
using MovieDB;
using Xamarin.Forms;

namespace MovieDB.Droid.BackgroundServices
{
    [Service]
    public class AndroidService : Service
    {
        private static bool _isRunning;

        public override IBinder OnBind(Intent intent)
        {
            return null;
        }

        [return: GeneratedEnum]
        public override StartCommandResult OnStartCommand(Intent intent, [GeneratedEnum] StartCommandFlags flags, int startId)
        {
            if (!_isRunning)
            {
                BackgroundService.BackgroundServiceHost.ServiceInstance.Start();

                _isRunning = true;
            }

            return StartCommandResult.Sticky;
        }

        public override void OnDestroy()
        {
            _isRunning = false;
            BackgroundService.BackgroundServiceHost.ServiceInstance.Stop();

            base.OnDestroy();
        }
    }
}