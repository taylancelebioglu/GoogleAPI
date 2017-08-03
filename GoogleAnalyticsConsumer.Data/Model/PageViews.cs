using System;
using System.ComponentModel.DataAnnotations;

namespace GoogleAnalyticsConsumer.Data
{
    public class PageViews : IPageViews
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public string PageTitle { get; set; }
        [MaxLength(100)]
        public string PagePathLevel { get; set; }
        [MaxLength(100)]
        public string PagePath { get; set; }
        [MaxLength(500)]
        public string Data { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime DataTime { get; set; }
        public DateTime Created { get; set; }
    }
}