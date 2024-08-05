using System.ComponentModel.DataAnnotations.Schema;

namespace LledgerApi.Models
{
    [Table("LedgersMembers")]
    public class LedgersMember
    {
        public int ID { get; set; }
        public int GroupID { get; set; }
        public int UserID { get; set; }



        public Group Group { get; set; }
        public User User { get; set; }
    }
}
