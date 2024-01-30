using System;

namespace Domain.Events
{
    public class ThereIsSomeoneElseInTheMood : IEvent
    {
        public ThereIsSomeoneElseInTheMood(Guid id, DateTime date, string reason, bool isTrincasPaying)
        {
            Id = id;
            Date = date;
            Reason = reason;
            IsTrincasPaying = isTrincasPaying;
            MeatAmount = 0;
            VegetablesAmount = 0;
        }

        public Guid Id { get; set; }
        public string Reason { get; set; }
        public bool IsTrincasPaying { get; set; }
        public DateTime Date { get; set; }
        public double MeatAmount { get; set; }
        public double VegetablesAmount { get; set; }
    }
}
