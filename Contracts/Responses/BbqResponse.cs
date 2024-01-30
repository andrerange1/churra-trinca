namespace Contracts
{
    public class BbqResponse
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public bool IsTrincasPaying { get; set; }
        public string Status { get; set; }
        public string MeatAmount { get; set; }
        public string VegetablesAmount { get; set; }
    }
}
