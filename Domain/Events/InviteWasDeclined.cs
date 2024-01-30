using Domain.Entities;

namespace Domain.Events
{
    public class InviteWasDeclined : IEvent
    {
        public InviteWasDeclined(string inviteId, string personId, bool isVeg)
        {
            InviteId = inviteId;
            PersonId = personId;
            IsVeg = isVeg;
        }
        public string InviteId { get; set; }
        public string PersonId { get; set; }
        public bool IsVeg { get; set; }
    }
}
