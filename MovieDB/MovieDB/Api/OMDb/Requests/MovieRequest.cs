using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDB.Api.OMDb.Requests
{
    public class MovieRequest : OMDbRequest
    {
        [ParameterName("y")]
        public string Year { get; set; }

        [ParameterName("plot")]
        public string Plot { get; set; }

        public MovieRequest()
        {
            this.BaseEndpoint = $"/?apikey={this.ApiKey}";
        }

        public MovieRequest(string input)
            : this()
        {
            this.Input = input;
        }
    }
}
