using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDB.Api.TMS.Requests
{
    public class TheatresByPostalCodeRequest : TMSRequest
    {
        [ParameterName("zip")]
        public int ZipCode { get; set; }

        [ParameterName("lat")]
        public decimal Latitude { get; set; }

        [ParameterName("lng")]
        public decimal Longitude { get; set; }

        [ParameterName("numTheatres")]
        public int NumberOfTheatres { get; set; }

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

        public TheatresByPostalCodeRequest()
        {
            this.BaseEndpoint = $"/theatres?api_key={this.ApiKey}";
        }
    }
}
