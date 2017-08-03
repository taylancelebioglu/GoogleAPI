using System;
namespace GoogleAnalyticsConsumer.Data
{
    public interface IEntity
    {
        Int32 Id { get; set; }
        string Data { get; set; }
        string Country { get; set; }
        string City { get; set; }
        DateTime DataTime { get; set; }
        DateTime Created { get; set; }
    }
}