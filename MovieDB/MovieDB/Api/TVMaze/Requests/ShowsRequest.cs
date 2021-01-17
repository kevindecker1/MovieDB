using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDB.Api.TVMaze.Requests
{
    public class ShowsRequest : TVMazeRequest
    {
        public ShowsRequest()
        {
            this.BaseEndpoint = $"/search/shows?";
        }

        public ShowsRequest(string input)
            : this()
        {
            this.Input = input;
        }
    }
}
