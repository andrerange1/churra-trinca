namespace Contracts
{
    public partial class NewPersonRequest
    {
        public NewPersonRequest(string name, bool isCoOwner)
        {
            Name = name; 
            IsCoOwner = isCoOwner;
        }

        public string Name { get; set; }
        public bool IsCoOwner { get; set; }
    }
}
