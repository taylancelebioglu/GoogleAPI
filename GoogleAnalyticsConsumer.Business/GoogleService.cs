using Google.Apis.Analytics.v3;
using Google.Apis.Analytics.v3.Data;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using GoogleAnalyticsConsumer.Data;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace GoogleAnalyticsConsumer.Business
{
    public class GoogleService
    {
        private static string keyFilePath = @"C:\Users\tcelebioglu\Documents\visual studio 2015\Projects\GoogleAPIConsumer\GoogleAPIConsumer\Properties\DM Analytics Test-c681eda07c72.p12";
        string certificateFileUrl = "https://googleanalyticsrole.file.core.windows.net/googleanalyticscertificate/DMAnalyticsTest-c681eda07c72.p12";
        private static string serviceAccountEmail = "api-service-account@dm-analytics-test.iam.gserviceaccount.com";
        private static string keyPassword = "notasecret";
        private static string websiteCode = "151706061";

        string clientId = "592005169530-6lao4003qbviekbbtgsq429p5k4ne1n8.apps.googleusercontent.com";
        string clientSecret = "u7DTYc3AArCx_YdGQoyn7v5M";

        private AnalyticsService service;
        public GoogleService()
        {
            byte[] certFile = AzureStorageHelper.GetCertificateFile();

            var certificate = new X509Certificate2(certFile, keyPassword, X509KeyStorageFlags.Exportable);

            var scopes =
          new string[] {
             AnalyticsService.Scope.Analytics,              // view and manage your analytics data    
             AnalyticsService.Scope.AnalyticsEdit,          // edit management actives    
             AnalyticsService.Scope.AnalyticsManageUsers,   // manage users    
             AnalyticsService.Scope.AnalyticsReadonly};     // View analytics data 

            //Auhenticate with certificate
            var credential = new ServiceAccountCredential(new ServiceAccountCredential.Initializer(serviceAccountEmail)
            {
                Scopes = scopes
            }.FromCertificate(certificate));

            //OAuth
            //var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets
            //{
            //    ClientId = clientId,
            //    ClientSecret = clientSecret
            //}, scopes, serviceAccountEmail, CancellationToken.None, new FileDataStore("GoogleAnalytics.Auth.Store")).Result;

            service = new AnalyticsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential
            });
        }

        public List<PageViews> GetPageViewsData()
        {
            DataResource.GaResource.GetRequest request = service.Data.Ga.Get(
               "ga:" + websiteCode,
               DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd"),
               DateTime.Today.ToString("yyyy-MM-dd"),
               "ga:pageviews");
            request.Dimensions = "ga:pageTitle,ga:pagePathLevel1,ga:pagePath,ga:dateHourMinute,ga:country,ga:city";
            request.Sort = "-ga:dateHourMinute";

            var data = request.Execute();
            return GetPageViewsDurationEntity<PageViews>(data);
        }
        public List<UniquePageViews> GetUniquePageViewsData()
        {
            DataResource.GaResource.GetRequest request2 = service.Data.Ga.Get(
               "ga:" + websiteCode,
               DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd"),
               DateTime.Today.ToString("yyyy-MM-dd"),
               "ga:uniquePageviews");
            request2.Dimensions = "ga:pageTitle,ga:pagePathLevel1,ga:pagePath,ga:dateHourMinute,ga:country,ga:city";
            request2.Sort = "-ga:dateHourMinute";

            var data2 = request2.Execute();
            return GetPageViewsDurationEntity<UniquePageViews>(data2);
        }
        public List<PageViewsDuration> GetPageViewsDurationData()
        {
            DataResource.GaResource.GetRequest request3 = service.Data.Ga.Get(
              "ga:" + websiteCode,
              DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd"),
              DateTime.Today.ToString("yyyy-MM-dd"),
              "ga:avgTimeOnPage");
            request3.Dimensions = "ga:pageTitle,ga:pagePathLevel1,ga:pagePath,ga:dateHourMinute,ga:country,ga:city";
            request3.Sort = "-ga:dateHourMinute";

            var data3 = request3.Execute();
            return GetPageViewsDurationEntity<PageViewsDuration>(data3);
        }
        public List<Client> GetClientsData()
        {
            DataResource.GaResource.GetRequest request4 = service.Data.Ga.Get(
              "ga:" + websiteCode,
              DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd"),
              DateTime.Today.ToString("yyyy-MM-dd"),
              "ga:sessions");
            request4.Dimensions = "ga:browser,ga:operatingSystem,ga:deviceCategory,ga:dateHourMinute,ga:country,ga:city";
            request4.Sort = "-ga:dateHourMinute";

            var data4 = request4.Execute();
            return GetClientEntity(data4);
        }
        private List<Client> GetClientEntity(GaData data)
        {
            List<Client> result = null;
            if (data.Rows != null && data.Rows.Count > 0)
            {
                result = new List<Client>();

                foreach (var row in data.Rows)
                {
                    result.Add(new Client() {
                        Browser = Convert.ToString(row[0]),
                        OperatingSystem= Convert.ToString(row[1]),
                        DeviceCategory = Convert.ToString(row[2]),
                        DataTime = DateTime.ParseExact(Convert.ToString(row[3]), "yyyyMMdHHmm", System.Globalization.CultureInfo.InvariantCulture),
                        Data = Convert.ToString(row[4]),
                        Created = DateTime.Now
                    });
                }
            }
            return result;
        }
        private List<T> GetPageViewsDurationEntity<T>(GaData data) where T : IPageViews
        {
            List<T> result = null;
            if (data.Rows != null && data.Rows.Count > 0)
            {
                result = new List<T>();

                foreach (var row in data.Rows)
                {
                    var entity = System.Activator.CreateInstance<T>();
                    entity.PageTitle = Convert.ToString(row[0]);
                    entity.PagePathLevel = Convert.ToString(row[1]);
                    entity.PagePath = Convert.ToString(row[2]);
                    entity.DataTime = DateTime.ParseExact(Convert.ToString(row[3]), "yyyyMMdHHmm", System.Globalization.CultureInfo.InvariantCulture);
                    entity.Country = Convert.ToString(row[4]);
                    entity.City = Convert.ToString(row[5]);

                    //Allways last index is data.
                    entity.Data = Convert.ToString(row[6]);
                    entity.Created = DateTime.Now;
                    result.Add(entity);
                }
            }
            return result;
        }
    }
}