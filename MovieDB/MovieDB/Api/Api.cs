using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace MovieDB.Api
{
    public static class Api<TEntity>
        where TEntity : class
    {
        public static TEntity SendRequest(BaseRequest request)
        {
            bool proceedWithRequest = true;
            if (request.RequireApiKey)
            {
                if (request.ApiKey == null  || request.ApiKey.Length == 0)
                {
                    proceedWithRequest = false;
                }
            }

            if (proceedWithRequest)
            {
                try
                {
                    request.BuildRequestParameters();

                    using (var client = new System.Net.Http.HttpClient())
                    {
                        client.BaseAddress = new Uri(request.BaseUri);
                        client.DefaultRequestHeaders.Accept.Clear();

                        System.Net.Http.HttpResponseMessage response = client.GetAsync(request.GetEndpoint()).Result; 
                        if (response.IsSuccessStatusCode)
                        {
                            var data = response.Content.ReadAsStringAsync().Result;
                            var model = JsonConvert.DeserializeObject<TEntity>(data);

                            return model;
                        }
                    }

                    return null;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return null;
        }

        public static List<TEntity> SendListRequest(BaseRequest request)
        {
            bool proceedWithRequest = true;
            if (request.RequireApiKey)
            {
                if (request.ApiKey == null || request.ApiKey.Length == 0)
                {
                    proceedWithRequest = false;
                }
            }

            if (proceedWithRequest)
            {
                try
                {
                    request.BuildRequestParameters();

                    using (var client = new System.Net.Http.HttpClient())
                    {
                        client.BaseAddress = new Uri(request.BaseUri);
                        client.DefaultRequestHeaders.Accept.Clear();

                        System.Net.Http.HttpResponseMessage response = client.GetAsync(request.GetEndpoint()).Result;
                        if (response.IsSuccessStatusCode)
                        {
                            var data = response.Content.ReadAsStringAsync().Result;
                            var model = JsonConvert.DeserializeObject<List<TEntity>>(data);

                            return model;
                        }
                    }

                    return null;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return null;
        }
    }
}
