using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDB.Api.OMDb
{
    public class OMDbRequest : BaseRequest
    {
        public override string ApiKey => "ded9a20a";

        public override string BaseUri => "https://www.omdbapi.com";

        public override bool RequireApiKey => true;

        /// <summary>
        /// Captures the searched input
        /// </summary>
        [ParameterName("t")]
        public virtual string Input { get; set; }
    }
}
