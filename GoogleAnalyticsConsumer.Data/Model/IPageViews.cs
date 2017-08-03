using System;

namespace GoogleAnalyticsConsumer.Data
{
    public interface IPageViews : IEntity
    {
        string PageTitle { get; set; }
        string PagePathLevel { get; set; }
        string PagePath { get; set; }
        string Data { get; set; }
        DateTime DataTime { get; set; }
        DateTime Created { get; set; }
    }
}