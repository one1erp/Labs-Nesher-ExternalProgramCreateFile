using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Configuration;

class Program
{
    static void Main(string[] args)
    {
       
        // Check if the required parameter is provided
        if (args.Length != 1)
        {
            return;
        }

        string cuurrenCoaId = args[0];

        string url = ConfigurationManager.AppSettings["URL"] + cuurrenCoaId;

        // Create the request
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "POST";
        request.ContentLength = 0;

        // Make the request and read the response
        string apiReqResult;
        using (WebResponse response = request.GetResponse())
        {
            using (Stream responseStream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(responseStream))
                {
                    apiReqResult = reader.ReadToEnd();
                }
            }
        }

    }
}