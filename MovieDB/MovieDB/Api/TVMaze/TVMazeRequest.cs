using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDB.Api.TVMaze
{
    public class TVMazeRequest : BaseRequest
    {
        public override string ApiKey => "";

        public override string BaseUri => "https://api.tvmaze.com";

        public override bool RequireApiKey => false;

        /// <summary>
        /// Captures the searched input
        /// </summary>
        [ParameterName("q")]
        public virtual string Input { get; set; }
    }
}
