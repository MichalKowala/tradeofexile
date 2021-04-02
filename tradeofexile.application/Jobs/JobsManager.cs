using Hangfire;
using System;
using System.Collections.Generic;
using System.Text;
using tradeofexile.application.Abstraction;
using tradeofexile.application.Contracts.Persistence;
using tradeofexile.application.Interfaces;
using tradeofexile.models.EntityItems;

namespace tradeofexile.application
{
    public class JobsManager : IJobsManager
    {
        private readonly IPoeApiIResponseHandler _responseHandler;
        public JobsManager(IPoeApiIResponseHandler responseHandler)
        {
            _responseHandler = responseHandler;
        }
        public void EnqueueAllJobs()
        {
            RecurringJob.AddOrUpdate("apiCaller",() => _responseHandler.GetAndProcessPoeApiResponse(), Cron.Minutely);
        }
    }
}
