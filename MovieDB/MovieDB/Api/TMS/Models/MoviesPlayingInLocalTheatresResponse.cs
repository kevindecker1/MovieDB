using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace MovieDB.Api.TMS.Models
{
    public class MoviesPlayingInLocalTheatresResponse
    {
        [DataMember(Name = "tmsId")]
        [XmlElement("tmsId")]
        public string TMSId { get; set; }

        [DataMember(Name = "subType")]
        [XmlElement("subType")]
        public string SubType { get; set; }

        [DataMember(Name = "title")]
        [XmlElement("title")]
        public string Title { get; set; }

        [DataMember(Name = "releaseYear")]
        [XmlElement("releaseYear")]
        public int? ReleaseYear { get; set; }

        [DataMember(Name = "releaseDate")]
        [XmlElement("releaseDate")]
        public DateTime? ReleaseDate { get; set; }

        [DataMember(Name = "titleLang")]
        [XmlElement("titleLang")]
        public string TitleLanguage { get; set; }

        [DataMember(Name = "descriptionLang")]
        [XmlElement("descriptionLang")]
        public string DescriptionLanguage { get; set; }

        [DataMember(Name = "entityType")]
        [XmlElement("entityType")]
        public string EntityType { get; set; }

        [DataMember(Name = "genres")]
        [XmlElement("genres")]
        public List<string> Genres { get; set; }

        [DataMember(Name = "longDescription")]
        [XmlElement("longDescription")]
        public string LongDescription { get; set; }

        [DataMember(Name = "shortDescription")]
        [XmlElement("shortDescription")]
        public string ShortDescription { get; set; }

        [DataMember(Name = "topCast")]
        [XmlElement("topCast")]
        public List<string> TopCast { get; set; }

        [DataMember(Name = "directors")]
        [XmlElement("directors")]
        public List<string> Directors { get; set; }

        [DataMember(Name = "officialUrl")]
        [XmlElement("officialUrl")]
        public string OfficialUrl { get; set; }

        [DataMember(Name = "ratings")]
        [XmlElement("ratings")]
        public List<MovieRating> Ratings { get; set; }

        [DataMember(Name = "runTime")]
        [XmlElement("runTime")]
        public string Runtime { get; set; }

        [DataMember(Name = "preferredImage")]
        [XmlElement("preferredImage")]
        public PreferredImage PreferredImage { get; set; }

        [DataMember(Name = "showtimes")]
        [XmlElement("showtimes")]
        public List<Showtime> Showtimes { get; set; }
    }
}
