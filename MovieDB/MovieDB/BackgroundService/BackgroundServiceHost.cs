using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace MovieDB.BackgroundService
{
    public partial class BackgroundServiceHost
    {
        internal static readonly CompositeDisposable EventSubscriptions = new CompositeDisposable();

        private static BackgroundServiceHost _serviceInstance;
        private static Dictionary<string, IPeriodicTask> _schedules = new Dictionary<string, IPeriodicTask>();

        static BackgroundServiceHost() { }
        private BackgroundServiceHost() { }

        public static void Add<T>(Func<T> schedule) where T: IPeriodicTask
        {
            var typeName = schedule.GetType().GetGenericArguments()[0]?.Name;
            if (typeName != null && !_schedules.ContainsKey(typeName))
            {
                _schedules.Add(typeName, schedule());
            }
        }

        public static void StartBackgroundService()
        {
            var message = new StartTask();
            MessagingCenter.Send(message, nameof(StartTask));
        }

        public static void StopBackgroundService()
        {
            var message = new StopTask();
            MessagingCenter.Send(message, nameof(StopTask));
        }

        public static BackgroundServiceHost ServiceInstance { get; } = _serviceInstance ?? (_serviceInstance = new BackgroundServiceHost());

        public void Start()
        {
            foreach (var schedule in _schedules)
            {
                var observable = SyncRepeatObservable(schedule.Value);
                EventSubscriptions.Add(observable);
            }
        }

        public void Stop()
        {
            EventSubscriptions.Clear();
        }

        public void Clear()
        {
            EventSubscriptions.Clear();
            _schedules.Clear();
        }

        private static IDisposable SyncRepeatObservable(IPeriodicTask schedule)
        {
            return Observable
                .FromAsync(schedule.StartJob)
                .Delay(schedule.Interval)
                .Repeat()
                .TakeWhile(e => e)
                .Subscribe();
        }
    }
}
