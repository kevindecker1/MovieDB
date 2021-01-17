using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace MovieDB.Api.TMS.Models
{
    public class TheatreShowtimesResponse
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

    [DataContract]
    public class MovieRating
    {
        [DataMember(Name = "body")]
        [XmlElement("body")]
        public string Association { get; set; }

        [DataMember(Name = "code")]
        [XmlElement("code")]
        public string Rating { get; set; }
    }

    [DataContract]
    public class PreferredImage
    {
        [DataMember(Name = "width")]
        [XmlElement("width")]
        public string Width { get; set; }

        [DataMember(Name = "height")]
        [XmlElement("height")]
        public string Height { get; set; }

        [DataMember(Name = "caption")]
        [XmlElement("caption")]
        public ImageCaption Caption { get; set; }

        [DataMember(Name = "uri")]
        [XmlElement("uri")]
        public string Url { get; set; }

        [DataMember(Name = "category")]
        [XmlElement("category")]
        public string Category { get; set; }

        [DataMember(Name = "text")]
        [XmlElement("text")]
        public string Text { get; set; }

        [DataMember(Name = "primary")]
        [XmlElement("primary")]
        public string Primary { get; set; }
    }

    [DataContract]
    public class ImageCaption
    {
        [DataMember(Name = "content")]
        [XmlElement("content")]
        public string Content { get; set; }

        [DataMember(Name = "lang")]
        [XmlElement("lang")]
        public string Language { get; set; }
    }

    [DataContract]
    public class Showtime
    {
        public TheatreShowtime Theatre { get; set; }
        public DateTime? Time { get; set; }
        public bool? Barg { get; set; }
    }

    [DataContract]
    public class TheatreShowtime
    {
        [DataMember(Name = "id")]
        [XmlElement("id")]
        public string ID { get; set; }

        [DataMember(Name = "name")]
        [XmlElement("name")]
        public string Name { get; set; }
    }
}
