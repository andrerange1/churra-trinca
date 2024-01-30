using System.Collections.Generic;
using System;

namespace Domain.Events
{
    public class PersonWasAddedToLookup : IEvent
    {
        public Guid Id { get; set; }

        //To create a new lookup must to be a moderator and the lookup will have only him
        public string GroupName { get; set; }
        public List<string> ModeratorIds { get; set; }
        public List<string> PeopleIds { get; set; }
        public string NewPersonId { get; set; }
        public bool IsCoOwner { get; set; }
    }
}
