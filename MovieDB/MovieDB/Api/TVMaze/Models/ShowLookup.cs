using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace MovieDB.Api.TVMaze.Models
{
    public class ShowLookup : BaseResponse
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

        [DataMember(Name = "network")]
        [XmlElement("network")]
        public Network Network { get; set; }

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
}
