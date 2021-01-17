using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDB.Api.TVMaze.Requests
{
    public class ScheduleRequest : TVMazeRequest
    {
        [ParameterName("country")]
        public string CountryCode { get; set; }

        [ParameterName("date")]
        public DateTime? Date { get; set; }

        public ScheduleRequest()
        {
            this.BaseEndpoint = $"/schedule?";
        }
    }
}
