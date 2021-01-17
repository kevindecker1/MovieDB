using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace MovieDB.Api.TMDB.Models
{
    public class MovieNowPlayingResponse
    {
        [DataMember(Name = "dates")]
        [XmlElement("dates")]
        public DateRange Dates { get; set; }

        [DataMember(Name = "page")]
        [XmlElement("page")]
        public int Page { get; set; }

        [DataMember(Name = "results")]
        [XmlElement("results")]
        public List<MovieResult> Results { get; set; }

        [DataMember(Name = "total_pages")]
        [XmlElement("total_pages")]
        public int TotalPages { get; set; }

        [DataMember(Name = "total_results")]
        [XmlElement("total_results")]
        public int ResultCount { get; set; }
    }

    [DataContract]
    public class DateRange
    {
        [DataMember(Name = "maximum")]
        [XmlElement("maximum")]
        public DateTime? Maximum { get; set; }

        [DataMember(Name = "minimum")]
        [XmlElement("minimum")]
        public DateTime? Minimum { get; set; }
    }
}
