using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace MovieDB.Api.TVMaze.Models
{
    public class ShowResponse : BaseResponse
    {
        [DataMember(Name = "score")]
        [XmlElement("score")]
        public decimal? Score { get; set; }

        [DataMember(Name = "show")]
        [XmlElement("show")]
        public Show Show { get; set; }
    }

    [DataContract]
    public class Show
    {
        [DataMember(Name = "id")]
        [XmlElement("id")]
        public int ID { get; set; }

        [DataMember(Name = "url")]
        [XmlElement("url")]
        public string Url { get; set; }

        [DataMember(Name = "name")]
        [XmlElement("name")]
        public string Name { get; set; }

        [DataMember(Name = "type")]
        [XmlElement("type")]
        public string Type { get; set; }

        [DataMember(Name = "language")]
        [XmlElement("language")]
        public string Language { get; set; }

        [DataMember(Name = "genres")]
        [XmlElement("genres")]
        public List<String> Genres { get; set; }

        [DataMember(Name = "status")]
        [XmlElement("status")]
        public string Status { get; set; }

        [DataMember(Name = "runtime")]
        [XmlElement("runtime")]
        public int Runtime { get; set; }

        [DataMember(Name = "premiered")]
        [XmlElement("premiered")]
        public DateTime? Premiered { get; set; }

        [DataMember(Name = "officialSite")]
        [XmlElement("officialSite")]
        public string OfficialSite { get; set; }

        [DataMember(Name = "schedule")]
        [XmlElement("schedule")]
        public Schedule Schedule { get; set; }

        [DataMember(Name = "rating")]
        [XmlElement("rating")]
        public Rating Rating { get; set; }

        [DataMember(Name = "weight")]
        [XmlElement("weight")]
        public int Weight { get; set; }

        [DataMember(Name = "externals")]
        [XmlElement("externals")]
        public External Externals { get; set; }

        [DataMember(Name = "image")]
        [XmlElement("image")]
        public Image Image { get; set; }

        [DataMember(Name = "summary")]
        [XmlElement("summary")]
        public string Summary { get; set; }
    }

    [DataContract]
    public class Schedule
    {
        [DataMember(Name = "time")]
        [XmlElement("time")]
        public string Time { get; set; }

        [DataMember(Name = "days")]
        [XmlElement("days")]
        public List<string> Days { get; set; }
    }

    [DataContract]
    public class Rating
    {
        [DataMember(Name = "average")]
        [XmlElement("average")]
        public decimal? Average { get; set; }
    }

    [DataContract]
    public class Network
    {
        [DataMember(Name = "id")]
        [XmlElement("id")]
        public int ID { get; set; }

        [DataMember(Name = "name")]
        [XmlElement("name")]
        public string Name { get; set; }

        [DataMember(Name = "country")]
        [XmlElement("country")]
        public Country Country { get; set; }

        [DataMember(Name = "webChannel")]
        [XmlElement("webChannel")]
        public string WebChannel { get; set; }
    }

    [DataContract]
    public class Country
    {
        [DataMember(Name = "name")]
        [XmlElement("name")]
        public string Name { get; set; }

        [DataMember(Name = "code")]
        [XmlElement("code")]
        public string Code { get; set; }

        [DataMember(Name = "timezone")]
        [XmlElement("timezone")]
        public string Timezone { get; set; }
    }

    [DataContract]
    public class External
    {
        [DataMember(Name = "tvrage")]
        [XmlElement("tvrage")]
        public long? TVRage { get; set; }

        [DataMember(Name = "thetvdb")]
        [XmlElement("thetvdb")]
        public long? TheTVDB { get; set; }

        [DataMember(Name = "imdb")]
        [XmlElement("imdb")]
        public string IMDB { get; set; }
    }

    [DataContract]
    public class Image
    {
        [DataMember(Name = "medium")]
        [XmlElement("medium")]
        public string Medium { get; set; }

        [DataMember(Name = "original")]
        [XmlElement("original")]
        public string Original { get; set; }
    }
}
