using System;
using System.Collections.Generic;

namespace Domain.Events
{
    public class NewLookupCreated : IEvent
    {
        public NewLookupCreated(Guid id, string groupname, List<string> moderators, List<string> people)
        {
            Id = id;
            GroupName = groupname;
            ModeratorIds = moderators;
            PeopleIds = people;
        }

        public Guid Id { get; set; }

        //To create a new lookup must to be a moderator and the lookup will have only him
        public string GroupName { get; set; }
        public List<string> ModeratorIds { get; set; }
        public List<string> PeopleIds { get; set; }
    }
}
