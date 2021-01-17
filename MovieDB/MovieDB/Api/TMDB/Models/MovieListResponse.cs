using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace MovieDB.Api.TMDB.Models
{
    public class MovieListResponse
    {
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
    public class MovieResult
    {
        [DataMember(Name = "adult")]
        [XmlElement("adult")]
        public bool IsAdult { get; set; }

        [DataMember(Name = "backdrop_path")]
        [XmlElement("backdrop_path")]
        public string BackdropPath { get; set; }

        [DataMember(Name = "genre_ids")]
        [XmlElement("genre_ids")]
        public List<int> GenreIDs { get; set; }

        [DataMember(Name = "id")]
        [XmlElement("id")]
        public long ID { get; set; }

        [DataMember(Name = "original_language")]
        [XmlElement("original_language")]
        public string LanguageCode { get; set; }

        [DataMember(Name = "original_title")]
        [XmlElement("original_title")]
        public string OriginalTitle { get; set; }

        [DataMember(Name = "overview")]
        [XmlElement("overview")]
        public string Overview { get; set; }

        [DataMember(Name = "popularity")]
        [XmlElement("popularity")]
        public decimal Popularity { get; set; }

        [DataMember(Name = "poster_path")]
        [XmlElement("poster_path")]
        public string PosterPath { get; set; }

        [DataMember(Name = "release_date")]
        [XmlElement("release_date")]
        public DateTime? ReleaseDate { get; set; }

        [DataMember(Name = "title")]
        [XmlElement("title")]
        public string Title { get; set; }

        [DataMember(Name = "video")]
        [XmlElement("video")]
        public bool HasVideo { get; set; }

        [DataMember(Name = "vote_average")]
        [XmlElement("vote_average")]
        public decimal VoteAverage { get; set; }

        [DataMember(Name = "vote_count")]
        [XmlElement("vote_count")]
        public long VoteCount { get; set; }
    }
}
