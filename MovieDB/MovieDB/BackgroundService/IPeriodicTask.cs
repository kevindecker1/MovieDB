using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieDB.BackgroundService
{
    public interface IPeriodicTask
    {
        TimeSpan Interval { get; }
        Task<bool> StartJob();
    }
}
