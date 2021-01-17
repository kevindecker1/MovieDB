using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace MovieDB.Api.TMDB.Requests
{
    public class MovieListRequest : TMDBRequest
    {
        [ParameterName("language")]
        public string Language { get; set; }

        [ParameterName("page")]
        public int? Page { get; set; }

        [ParameterName("include_adult")]
        public bool IncludeAdult { get; set; }

        [ParameterName("region")]
        public string Region { get; set; }

        [ParameterName("year")]
        public int? Year { get; set; }

        [ParameterName("primary_release_year")]
        public int? ReleaseYear { get; set; }

        public MovieListRequest() 
        {
            this.BaseEndpoint = $"/3/search/movie?api_key={this.ApiKey}";
        }

        public MovieListRequest(string input)
            : this()
        {
            this.Input = input;
        }
    }
}
