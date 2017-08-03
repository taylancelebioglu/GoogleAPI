using System;

namespace GoogleAnalyticsConsumer.Data
{
    public interface IPageViews : IEntity
    {
        string PageTitle { get; set; }
        string PagePathLevel { get; set; }
        string PagePath { get; set; }
    }
}