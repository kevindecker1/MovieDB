using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDB.Api.TMDB.Requests
{
    public class MovieDetailRequest : TMDBRequest
    {
        [ParameterName("language")]
        public string Language { get; set; }

        public MovieDetailRequest(int movieID)
        {
            this.BaseEndpoint = $"/3/movie/{movieID}?api_key={this.ApiKey}";
        }
    }
}
