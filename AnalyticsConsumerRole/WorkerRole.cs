using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.ServiceRuntime;
using GoogleAnalyticsConsumer.Data;
using GoogleAnalyticsConsumer.Business;
using System.Linq;
using System;

namespace AnalyticsConsumerRole
{
    public class WorkerRole : RoleEntryPoint
    {
        private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private readonly ManualResetEvent runCompleteEvent = new ManualResetEvent(false);

        public override void Run()
        {
            Trace.TraceInformation("AnalyticsConsumerRole is running");

            try
            {
                this.RunAsync(this.cancellationTokenSource.Token).Wait();
            }
            finally
            {
                this.runCompleteEvent.Set();
            }
        }
        public override bool OnStart()
        {
            // Set the maximum number of concurrent connections
            ServicePointManager.DefaultConnectionLimit = 12;

            // For information on handling configuration changes
            // see the MSDN topic at https://go.microsoft.com/fwlink/?LinkId=166357.

            bool result = base.OnStart();

            Trace.TraceInformation("AnalyticsConsumerRole has been started");

            return result;
        }
        public override void OnStop()
        {
            Trace.TraceInformation("AnalyticsConsumerRole is stopping");

            this.cancellationTokenSource.Cancel();
            this.runCompleteEvent.WaitOne();

            base.OnStop();

            Trace.TraceInformation("AnalyticsConsumerRole has stopped");
        }
        private async Task RunAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    Trace.TraceInformation("Starting requests");
                    GoogleService service = new GoogleService();

                    var pageViews = service.GetPageViewsData();
                    var pageUniqueViews = service.GetUniquePageViewsData();
                    var pageViewsDuration = service.GetPageViewsDurationData();
                    var clients = service.GetClientsData();
                    Trace.TraceInformation("Requests are completed");

                    PageViewsRepository viewsRep = new PageViewsRepository();
                    PageViewUniqueRepository uniqueRep = new PageViewUniqueRepository();
                    PageViewsDurationRepository durationRep = new PageViewsDurationRepository();
                    ClientsRepository clientsRep = new ClientsRepository();

                    DateTime lastPageViewData = viewsRep.GetLast();
                    DateTime lastUniqueData = uniqueRep.GetLast();
                    DateTime lastDurationData = durationRep.GetLast();
                    DateTime lastClientData = clientsRep.GetLast();

                    if (pageViews.Count > 0)
                    {
                        pageViews = pageViews.OrderByDescending(v => v.DataTime).Where(v => v.DataTime > lastPageViewData).ToList();
                        Trace.TraceInformation(string.Format("Inserting pageViews count => {0}", pageViews.Count));
                        pageViews.ForEach((p) =>
                        {
                            viewsRep.Insert(p);
                        });
                    }
                    if (pageUniqueViews.Count > 0)
                    {
                        pageUniqueViews = pageUniqueViews.OrderByDescending(v => v.DataTime).Where(v => v.DataTime > lastUniqueData).ToList();
                        Trace.TraceInformation(string.Format("Inserting pageUniqueViews count => {0}", pageUniqueViews.Count));
                        pageUniqueViews.ForEach((p) =>
                        {
                            uniqueRep.Insert(p);
                        });
                    }
                    if (pageViewsDuration.Count > 0)
                    {
                        pageViewsDuration = pageViewsDuration.OrderByDescending(v => v.DataTime).Where(v => v.DataTime > lastDurationData).ToList();
                        Trace.TraceInformation(string.Format("Inserting pageViewsDuration count => {0}", pageViewsDuration.Count));
                        pageViewsDuration.ForEach((p) =>
                        {
                            durationRep.Insert(p);
                        });
                    }
                    if (clients.Count > 0)
                    {
                        clients = clients.OrderByDescending(v => v.DataTime).Where(v => v.DataTime > lastClientData).ToList();
                        Trace.TraceInformation(string.Format("Inserting clients count => {0}", clients.Count));
                        clients.ForEach((p) =>
                        {
                            clientsRep.Insert(p);
                        });
                    }
                }
                catch (Exception ex)
                {
                    Trace.TraceInformation(string.Format("Error:{0}", ex.Message));
                }
                Console.WriteLine("Waiting for 5 minutes");
                await Task.Delay(300000);
            }
        }
    }
}
