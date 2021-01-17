using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace MovieDB.Api.OMDb.Models
{
    public class MovieResponse : BaseResponse
    {
        [DataMember(Name = "Title")]
        [XmlElement("Title")]
        public string Title { get; set; }

        [DataMember(Name = "Year")]
        [XmlElement("Year")]
        public string Year { get; set; }

        [DataMember(Name = "Rated")]
        [XmlElement("Rated")]
        public string Rated { get; set; }

        [DataMember(Name = "Released")]
        [XmlElement("Released")]
        public string Released { get; set; }

        [DataMember(Name = "Runtime")]
        [XmlElement("Runtime")]
        public string Runtime { get; set; }

        [DataMember(Name = "Genre")]
        [XmlElement("Genre")]
        public string Genre { get; set; }

        [DataMember(Name = "Director")]
        [XmlElement("Director")]
        public string Director { get; set; }

        [DataMember(Name = "Writer")]
        [XmlElement("Writer")]
        public string Writer { get; set; }

        [DataMember(Name = "Actors")]
        [XmlElement("Actors")]
        public string Actors { get; set; }

        [DataMember(Name = "Plot")]
        [XmlElement("Plot")]
        public string Plot { get; set; }

        [DataMember(Name = "Language")]
        [XmlElement("Language")]
        public string Language { get; set; }

        [DataMember(Name = "Country")]
        [XmlElement("Country")]
        public string Country { get; set; }

        [DataMember(Name = "Awards")]
        [XmlElement("Awards")]
        public string Awards { get; set; }

        [DataMember(Name = "Poster")]
        [XmlElement("Poster")]
        public string Poster { get; set; }

        [DataMember(Name = "Ratings")]
        [XmlElement("Ratings")]
        public List<Rating> Ratings { get; set; }

        [DataMember(Name = "Metascore")]
        [XmlElement("Metascore")]
        public string Metascore { get; set; }

        [DataMember(Name = "imdbRating")]
        [XmlElement("imdbRating")]
        public string ImdbRating { get; set; }

        [DataMember(Name = "imdbVotes")]
        [XmlElement("imdbVotes")]
        public string ImdbVotes { get; set; }

        [DataMember(Name = "imdbID")]
        [XmlElement("imdbID")]
        public string ImdbID { get; set; }

        [DataMember(Name = "Type")]
        [XmlElement("Type")]
        public string Type { get; set; }

        [DataMember(Name = "totalSeasons")]
        [XmlElement("totalSeasons")]
        public string TotalSeasons { get; set; }

        [DataMember(Name = "Response")]
        [XmlElement("Response")]
        public string Response { get; set; }
    }

    public class Rating
    {
        [DataMember(Name = "Source")]
        [XmlElement("Source")]
        public string Source { get; set; }

        [DataMember(Name = "Value")]
        [XmlElement("Value")]
        public string Value { get; set; }
    }
}
