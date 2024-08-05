namespace LledgerApi.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public DateTime CreatedDate { get; set; }

        public ICollection<LedgersMember> LedgersMember { get; set; }
    }
}
