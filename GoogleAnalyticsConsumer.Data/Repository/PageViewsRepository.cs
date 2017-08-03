using System;
using System.Linq;

namespace GoogleAnalyticsConsumer.Data
{
    public class PageViewsRepository: RepositoryBase<PageViews>
    {
        public DateTime GetLast()
        {
            var last = base.GetAll().OrderByDescending(e => e.DataTime).Take(1).FirstOrDefault();
            if (last != null)
            {
                return last.DataTime;
            }
            return DateTime.Now;
        }
    }
}