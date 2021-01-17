using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDB.Api.TMS.Requests
{
    public class TheatreShowtimesRequest : TMSRequest
    {
        [ParameterName("numDays")]
        public int NumberOfDays { get; set; }

        /// <summary>
        /// Values consist of "Sm", "Md", "Lg", "Ms". Defaults to "Md"
        /// </summary>
        [ParameterName("imageSize")]
        public string ImageSize { get; set; }

        /// <summary>
        /// Indicates if the images have text
        /// </summary>
        [ParameterName("imageText")]
        public bool? ImageText { get; set; }

        public TheatreShowtimesRequest(int theatreID, DateTime? startDate = null)
        {
            if (!startDate.HasValue) { startDate = DateTime.Today; }
            this.BaseEndpoint = $"/theatres/{theatreID}/showings?startDate={startDate}&api_key={this.ApiKey}";
        }
    }
}
