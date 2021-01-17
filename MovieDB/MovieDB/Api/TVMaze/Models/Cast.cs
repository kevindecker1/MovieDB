using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace MovieDB.Api.TVMaze.Models
{
    public class Cast
    {
        [DataMember(Name = "person")]
        [XmlElement("person")]
        public Person Person { get; set; }

        [DataMember(Name = "character")]
        [XmlElement("character")]
        public Character Character { get; set; }

        [DataMember(Name = "self")]
        [XmlElement("self")]
        public bool IsSelf { get; set; }

        [DataMember(Name = "voice")]
        [XmlElement("voice")]
        public bool IsVoice { get; set; }
    }

    public class Person
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

        [DataMember(Name = "country")]
        [XmlElement("country")]
        public Country Country { get; set; }

        [DataMember(Name = "birthday")]
        [XmlElement("birthday")]
        public DateTime Birthday { get; set; }

        [DataMember(Name = "deathday")]
        [XmlElement("deathday")]
        public DateTime Deathday { get; set; }

        [DataMember(Name = "gender")]
        [XmlElement("gender")]
        public string Gender { get; set; }

        [DataMember(Name = "image")]
        [XmlElement("image")]
        public Image Image { get; set; }
    }

    public class Character
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

        [DataMember(Name = "image")]
        [XmlElement("image")]
        public Image Image { get; set; }
    }
}
