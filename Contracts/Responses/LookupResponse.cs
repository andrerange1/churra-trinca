namespace Contracts
{
    public class LookupResponse
    {
        public string Id { get; set; }
        public string GroupName { get; set; }
        public List<string> ModeratorIds { get; set; }
        public List<string> PeopleIds { get; set; }
    }
}
