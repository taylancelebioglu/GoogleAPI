using RestSharp;
using System;
using System.Threading;

namespace GoogleAnalyticsConsumer.Business
{
    public class RequestSimulator
    {
        public void ExcuteRequests()
        {
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            
            int requestCount = rnd.Next(1, 20);

            for (int i = 0; i < requestCount; i++)
            {
                int urlIndex = rnd.Next(0, SimulatorParameters.PageUrlList.Count);
                int browserIndex = rnd.Next(0, SimulatorParameters.BrowserList.Count);
                int geoIdIndex = rnd.Next(0, SimulatorParameters.GeoIdList.Count);

                SendRequest(SimulatorParameters.PageUrlList[urlIndex].Value, SimulatorParameters.PageUrlList[urlIndex].Key, SimulatorParameters.GeoIdList[geoIdIndex], SimulatorParameters.BrowserList[browserIndex].Value);

                int waitingTime = rnd.Next(50, 150);
                Thread.Sleep(waitingTime);
            }
        }
        public void SendRequest(string url, string title, int geoid, string userAgent)
        {
            var client = new RestClient("http://www.google-analytics.com");

            var request = new RestRequest("/collect", Method.POST);

            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            int userId = rnd.Next(100, 9999);

            request.AddParameter("v", "1");
            request.AddParameter("t", "pageview");
            request.AddParameter("tid", "UA-100072697-1");
            request.AddParameter("cid", userId.ToString());
            request.AddParameter("dh", "http://analyticswebtest-digitalmarketing.azurewebsites.net");
            request.AddParameter("dp", url);
            request.AddParameter("dt", title);
            request.AddParameter("ua", userAgent);
            request.AddParameter("geoid", geoid.ToString());

            IRestResponse response = client.Execute(request);
            var content = response.Content;
        }
    }
}