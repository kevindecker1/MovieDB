using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDB.Api.TMS.Requests
{
    public class MoviesPlayingInLocalTheatresRequest : TMSRequest
    {
        [ParameterName("zip")]
        public int ZipCode { get; set; }

        [ParameterName("lat")]
        public decimal Latitude { get; set; }

        [ParameterName("lng")]
        public decimal Longitude { get; set; }

        /// <summary>
        /// Measurement is defaulted to miles, with a default value of 5.
        /// </summary>
        [ParameterName("radius")]
        public int Radius { get; set; }

        /// <summary>
        /// Defaults to miles (mi), or kilometers (km)
        /// </summary>
        [ParameterName("units")]
        public string RadiusMeasurement { get; set; }

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

        public MoviesPlayingInLocalTheatresRequest(DateTime startDate)
        {
            this.BaseEndpoint = $"/movies/showings?startDate={startDate}&api_key={this.ApiKey}";
        }
    }
}
