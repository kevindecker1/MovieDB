using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDB.Api.TMDB
{
    public class TMDBRequest : BaseRequest
    {
        public override string ApiKey => "135bbf7fcc7a98aef2ff2cd9552701bb";

        public override string BaseUri => "https://api.themoviedb.org";

        public override bool RequireApiKey => true;

        /// <summary>
        /// Captures the searched input
        /// </summary>
        [ParameterName("query")]
        public virtual string Input { get; set; }
    }
}
