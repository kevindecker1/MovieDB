using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDB.Api.TVMaze.Requests
{
    public class CastRequest : TVMazeRequest
    {
        public CastRequest(int showID)
        {
            this.BaseEndpoint = $"/shows/{showID}/cast";
        }
    }
}
