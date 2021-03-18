using Hangfire;
using System;
using System.Collections.Generic;
using System.Text;
using tradeofexile.application.Abstraction;
using tradeofexile.application.Contracts.Persistence;
using tradeofexile.application.Interfaces;
using tradeofexile.models.Items;

namespace tradeofexile.application
{
    public class JobsManager : IJobsManager
    {
        private readonly IResponseHandler _responseHandler;
        public JobsManager(IResponseHandler responseHandler)
        {
            _responseHandler = responseHandler;
        }
        public void EnqueueAllJobs()
        {
            RecurringJob.AddOrUpdate("apiCaller",() => _responseHandler.GetAndProcessPoeApiResponse(), Cron.Minutely);
        }
    }
}
