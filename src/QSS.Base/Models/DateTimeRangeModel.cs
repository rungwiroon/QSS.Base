using System;

namespace Qss.Base.Models
{
    public class DateTimeRangeModel
    {
        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public DateTimeRangeModel()
        {
        }

        public DateTimeRangeModel(DateTime startDateTime, DateTime endDateTime)
        {
            Start = startDateTime;
            End = endDateTime;
        }
    }
}