using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.Storage;

namespace RequestSimulator
{
    public class WorkerRole : RoleEntryPoint
    {
        private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private readonly ManualResetEvent runCompleteEvent = new ManualResetEvent(false);

        public override void Run()
        {
            Trace.TraceInformation("RequestSimulator is running");

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

            Trace.TraceInformation("RequestSimulator has been started");

            return result;
        }

        public override void OnStop()
        {
            Trace.TraceInformation("RequestSimulator is stopping");

            this.cancellationTokenSource.Cancel();
            this.runCompleteEvent.WaitOne();

            base.OnStop();

            Trace.TraceInformation("RequestSimulator has stopped");
        }

        private async Task RunAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                Random rnd = new Random();
                int waitingMinute = rnd.Next(1, 6);

                Trace.TraceInformation("Working");
                try
                {
                    Trace.TraceInformation("Sending request");
                    GoogleAnalyticsConsumer.Business.RequestSimulator sim = new GoogleAnalyticsConsumer.Business.RequestSimulator();
                    sim.ExcuteRequests();
                    Trace.TraceInformation(string.Format("Will wait for {0} minute", waitingMinute));
                }
                catch (Exception ex)
                {
                    Trace.TraceInformation(string.Format("Error:{0}", ex.Message));
                }
                await Task.Delay(waitingMinute * 60 * 1000);
            }
        }
    }
}