using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDB.Api.TMDB.Requests
{
    public class MoviePopularRequest : TMDBRequest
    {
        [ParameterName("language")]
        public string Language { get; set; }

        [ParameterName("page")]
        public int Page { get; set; }

        [ParameterName("region")]
        public string Region { get; set; }

        public MoviePopularRequest()
        {
            this.BaseEndpoint = $"/3/movie/popular?api_key={this.ApiKey}";
            this.Language = "en-US";
            this.Page = 1;
            this.Region = "US";
        }
    }
}
