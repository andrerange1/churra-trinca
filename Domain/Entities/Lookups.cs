using Domain.Events;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities
{
    public class Lookups : AggregateRoot
    {
        //[JsonProperty("StreamId")]
        //public string Id { get; set; }


        //public const string Id = "08f6410a-58e9-464b-8d7a-1832bf5d7a27";
        public string GroupName { get; set; }
        public List<string> ModeratorIds { get; set; }
        public List<string> PeopleIds { get; set; }

        public Lookups()
        {
            ModeratorIds = new List<string>();
            PeopleIds = new List<string>();
        }

        public void When(NewLookupCreated @event)
        {
            GroupName = @event.GroupName;
            Id = @event.Id.ToString();
            ModeratorIds = @event.ModeratorIds;
            PeopleIds = @event.PeopleIds;
        }

        public void When(PersonWasAddedToLookup @event)
        {
            GroupName = @event.GroupName;
            Id = @event.Id.ToString();
            ModeratorIds = @event.ModeratorIds.Distinct().ToList();
            PeopleIds = @event.PeopleIds.Distinct().ToList();

            PeopleIds.Add(@event.NewPersonId);
            if (@event.IsCoOwner)
            {
                ModeratorIds.Add(@event.NewPersonId);
            } 

        }


    }
}
