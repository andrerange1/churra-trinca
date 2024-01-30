using System;
using System.Collections.Generic;

namespace Domain.Events
{
    public class BbqIsModeratedAsNotHappen : IEvent
    {
        public string BbqId {  get; set; }
        public string Status { get; set; }
        public double MeatAmount { get; set; }
        public double VegetablesAmount { get; set; }
        public IList<string> PeopleId { get; set; }
        
    }
}
