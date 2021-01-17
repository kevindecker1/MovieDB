using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace MovieDB.Api.TVMaze.Models
{
    public class ScheduleResponse
    {
        [DataMember(Name = "id")]
        [XmlElement("id")]
        public long ID { get; set; }

        [DataMember(Name = "url")]
        [XmlElement("url")]
        public string Url { get; set; }

        [DataMember(Name = "name")]
        [XmlElement("name")]
        public string Name { get; set; }

        [DataMember(Name = "season")]
        [XmlElement("season")]
        public int Season { get; set; }

        [DataMember(Name = "number")]
        [XmlElement("number")]
        public int Number { get; set; }

        [DataMember(Name = "type")]
        [XmlElement("type")]
        public string Type { get; set; }

        [DataMember(Name = "airdate")]
        [XmlElement("airdate")]
        public DateTime AirDate { get; set; }

        [DataMember(Name = "airtime")]
        [XmlElement("airtime")]
        public TimeSpan AirTime { get; set; }

        [DataMember(Name = "airstamp")]
        [XmlElement("airstamp")]
        public DateTime AirStamp { get; set; }

        [DataMember(Name = "runtime")]
        [XmlElement("runtime")]
        public int Runtime { get; set; }

        [DataMember(Name = "image")]
        [XmlElement("image")]
        public string Image { get; set; }

        [DataMember(Name = "summary")]
        [XmlElement("summary")]
        public string Summary { get; set; }

        [DataMember(Name = "show")]
        [XmlElement("show")]
        public Show Show { get; set; }
    }
}
