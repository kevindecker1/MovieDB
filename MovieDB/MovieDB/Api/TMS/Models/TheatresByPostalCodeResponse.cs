using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace MovieDB.Api.TMS.Models
{
    public class TheatresByPostalCodeResponse
    {
        [DataMember(Name = "theatreId")]
        [XmlElement("theatreId")]
        public string ID { get; set; }

        [DataMember(Name = "name")]
        [XmlElement("name")]
        public string Name { get; set; }

        [DataMember(Name = "location")]
        [XmlElement("location")]
        public TheatreLocation Location { get; set; }
    }

    [DataContract]
    public class TheatreLocation
    {
        [DataMember(Name = "distance")]
        [XmlElement("distance")]
        public decimal? Distance { get; set; }

        [DataMember(Name = "telephone")]
        [XmlElement("telephone")]
        public string Telephone { get; set; }

        [DataMember(Name = "geoCode")]
        [XmlElement("geoCode")]
        public TheatreGeoCode GeoCode { get; set; }

        [DataMember(Name = "address")]
        [XmlElement("address")]
        public TheatreAddress Address { get; set; }
    }

    [DataContract]
    public class TheatreGeoCode
    {
        [DataMember(Name = "latitude")]
        [XmlElement("latitude")]
        public string Latitude { get; set; }

        [DataMember(Name = "longitude")]
        [XmlElement("longitude")]
        public string Longitude { get; set; }
    }

    [DataContract]
    public class TheatreAddress
    {
        [DataMember(Name = "street")]
        [XmlElement("street")]
        public string Street { get; set; }

        [DataMember(Name = "state")]
        [XmlElement("state")]
        public string State { get; set; }

        [DataMember(Name = "city")]
        [XmlElement("city")]
        public string City { get; set; }

        [DataMember(Name = "country")]
        [XmlElement("country")]
        public string Country { get; set; }

        [DataMember(Name = "postalCode")]
        [XmlElement("postalCode")]
        public string PostalCode { get; set; }
    }
}
