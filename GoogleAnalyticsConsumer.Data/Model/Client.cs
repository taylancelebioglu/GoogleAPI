using System;
using System.ComponentModel.DataAnnotations;

namespace GoogleAnalyticsConsumer.Data
{
    public class Client : IEntity
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Browser { get; set; }
        [MaxLength(100)]
        public string OperatingSystem { get; set; }
        [MaxLength(100)]
        public string DeviceCategory { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        [MaxLength(500)]
        public string Data { get; set; }
        public DateTime DataTime { get; set; }
        public DateTime Created { get; set; }
    }
}