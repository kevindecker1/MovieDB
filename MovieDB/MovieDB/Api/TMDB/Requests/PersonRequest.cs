using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDB.Api.TMDB.Requests
{
    public class PersonRequest : TMDBRequest
    {
        [ParameterName("language")]
        public string Language { get; set; }

        [ParameterName("page")]
        public int? Page { get; set; }

        [ParameterName("include_adult")]
        public bool IncludeAdult { get; set; }

        [ParameterName("region")]
        public string Region { get; set; }

        public PersonRequest()
        {
            this.BaseEndpoint = $"/3/search/person?api_key={this.ApiKey}";
        }

        public PersonRequest(string input)
            : this()
        {
            this.Input = input;
        }
    }
}
