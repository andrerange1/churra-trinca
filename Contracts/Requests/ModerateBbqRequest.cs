namespace Contracts
{
    public partial class RunModerateBbq
    {
        public class ModerateBbqRequest
        {
            public bool GonnaHappen { get; set; }
            public bool TrincaWillPay { get; set; }
            public string LookupId { get; set; }
        }
    }
}
