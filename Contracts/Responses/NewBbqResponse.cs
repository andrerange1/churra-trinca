namespace Contracts
{
    public class NewBbqResponse
    {
        public string Id { get; set; }
        public string Reason { get; set; }
        public DateTime Date { get; set; }
        public bool IsTrincasPaying { get; set; }
        public string Status { get; set; }
    }
}
