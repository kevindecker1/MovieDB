using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace MovieDB.Api.TMDB.Models
{
    public class MovieDetailResponse : BaseResponse
    {
        [DataMember(Name = "adult")]
        [XmlElement("adult")]
        public bool IsAdult { get; set; }

        [DataMember(Name = "backdrop_path")]
        [XmlElement("backdrop_path")]
        public string BackdropPath { get; set; }

        [DataMember(Name = "belongs_to_collection")]
        [XmlElement("belongs_to_collection")]
        public BelongsToCollection Collection { get; set; }

        [DataMember(Name = "budget")]
        [XmlElement("budget")]
        public long? Budget { get; set; }

        [DataMember(Name = "genres")]
        [XmlElement("genres")]
        public List<Genre> Genres { get; set; }

        [DataMember(Name = "homepage")]
        [XmlElement("homepage")]
        public string Homepage { get; set; }

        [DataMember(Name = "id")]
        [XmlElement("id")]
        public long ID { get; set; }

        [DataMember(Name = "overview")]
        [XmlElement("overview")]
        public string Overview { get; set; }

        [DataMember(Name = "production_companies")]
        [XmlElement("production_companies")]
        public List<ProductionCompany> ProductionCompanies { get; set; }

        [DataMember(Name = "production_countries")]
        [XmlElement("production_countries")]
        public List<ProductionCountry> ProductionCountries { get; set; }

        [DataMember(Name = "release_date")]
        [XmlElement("release_date")]
        public DateTime? ReleaseDate { get; set; }

        [DataMember(Name = "revenue")]
        [XmlElement("revenue")]
        public long? Revenue { get; set; }

        [DataMember(Name = "runtime")]
        [XmlElement("runtime")]
        public int? Runtime { get; set; }

        [DataMember(Name = "status")]
        [XmlElement("status")]
        public string Status { get; set; }

        [DataMember(Name = "tagline")]
        [XmlElement("tagline")]
        public string Tagline { get; set; }

        [DataMember(Name = "title")]
        [XmlElement("title")]
        public string Title { get; set; }
    }

    [DataContract]
    public class BelongsToCollection
    {
        [DataMember(Name = "id")]
        [XmlElement("id")]
        public long? ID { get; set; }

        [DataMember(Name = "name")]
        [XmlElement("name")]
        public string Name { get; set; }

        [DataMember(Name = "poster_path")]
        [XmlElement("poster_path")]
        public string PosterPath { get; set; }

        [DataMember(Name = "backdrop_path")]
        [XmlElement("backdrop_path")]
        public string BackdropPath { get; set; }
    }

    [DataContract]
    public class Genre
    {
        [DataMember(Name = "id")]
        [XmlElement("id")]
        public int ID { get; set; }

        [DataMember(Name = "name")]
        [XmlElement("name")]
        public string Name { get; set; }
    }

    [DataContract]
    public class ProductionCompany
    {
        [DataMember(Name = "id")]
        [XmlElement("id")]
        public int ID { get; set; }

        [DataMember(Name = "logo_path")]
        [XmlElement("logo_path")]
        public string LogoPath { get; set; }

        [DataMember(Name = "name")]
        [XmlElement("name")]
        public string Name { get; set; }

        [DataMember(Name = "origin_country")]
        [XmlElement("origin_country")]
        public string Country { get; set; }
    }

    [DataContract]
    public class ProductionCountry
    {
        [DataMember(Name = "iso_3166_1")]
        [XmlElement("iso_3166_1")]
        public string ISO { get; set; }

        [DataMember(Name = "name")]
        [XmlElement("name")]
        public string Name { get; set; }
    }
}
