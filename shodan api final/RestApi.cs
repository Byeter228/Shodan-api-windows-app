using System;
using System.Text;
using System.Net;
using System.IO;

namespace shodan_api_final
{
    public enum httpverb
    {
        GET,
        POST,
        PUT,
        DELETE
    }
    class RestApi
    {
        //link to be requested
        public string endpoint { get; set; }
        //http method to request with
        public httpverb httpmethod { get; set; }
        //common url for all shodan methods
        public static string baseUrl = "https://api.shodan.io/shodan/";
        //shodan api key
        public static string apiKey = "";
        //default constructor
        public RestApi()
        {
            endpoint = string.Empty;
            //shodan use only get http method in all search methods
            httpmethod = httpverb.GET;
        }
        //function to request the api link and return the resonse string(json file)
        public string makeRequest()
        {
            string strResponseValue = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endpoint);
            request.Method = httpmethod.ToString();
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new ApplicationException("error code = " + response.StatusCode);
                }
                using (Stream responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            strResponseValue = reader.ReadToEnd();
                        }
                    }
                }
            }



            return strResponseValue;

        }

    }
}
