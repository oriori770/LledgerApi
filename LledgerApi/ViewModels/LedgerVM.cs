using LledgerApi.Models;

namespace LledgerApi.ViewModels
{
    public class LedgerVM
    {
        public string LedgerName { get; set; }
        public DateTime CreatedDate { get; set; }
        public Ledger Toledger(LedgerVM ledgerVM) 
        {
            return new Ledger { CreatedDate = ledgerVM.CreatedDate, LedgerName = ledgerVM.LedgerName };
        }
    }
}
