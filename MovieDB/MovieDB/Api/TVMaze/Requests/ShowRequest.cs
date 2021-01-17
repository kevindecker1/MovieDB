using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDB.Api.TVMaze.Requests
{
    public class ShowRequest : TVMazeRequest
    {
        [ParameterName("tvrage")]
        public long? TVRage { get; set; }

        [ParameterName("thetvdv")]
        public long? TheTVDB { get; set; }

        [ParameterName("imdb")]
        public string IMDB { get; set; }

        public ShowRequest()
        {
            this.BaseEndpoint = $"/lookup/shows?";
        }

        public ShowRequest(string input)
            : this()
        {
            this.Input = input;
        }
    }
}
