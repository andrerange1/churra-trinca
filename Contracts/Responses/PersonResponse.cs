
namespace Contracts
{
    public class PersonResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool IsCoOwner { get; set; }
        public List<InviteResponse> Invites { get; set; }

    }
}
