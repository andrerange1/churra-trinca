using ChurrasTrinca.Domain.Enums;

namespace ChurrasTrinca.Domain
{
    public class Invite
    {
        public string Id { get; set; }
        public string Bbq { get; set; }
        public InviteStatusEnum Status { get; set; }
        public DateTime Date { get; set; }
    }
}
