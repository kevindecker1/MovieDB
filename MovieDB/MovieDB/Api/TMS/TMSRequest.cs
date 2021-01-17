using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDB.Api.TMS
{
    public class TMSRequest : BaseRequest
    {
        public override string ApiKey => "6ws5gkaws2vechb38mbtfp37"; //utj5fagdqx4rkvewj79f6t4s

        public override string BaseUri => "http://data.tmsapi.com/v1.1";

        public override bool RequireApiKey => true;
    }
}
