using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LledgerApi.Models
{
    [Table("Ledgers")]
    public class Ledger
    {
        public int Id { get; set; }
        public string LedgerName { get; set; }
        public DateTime CreatedDate { get; set; }
        [JsonIgnore]
        public ICollection<LedgersMember>? LedgersMember { get; set; }
    }
}
