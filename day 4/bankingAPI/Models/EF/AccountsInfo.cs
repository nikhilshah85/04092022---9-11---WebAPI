using System;
using System.Collections.Generic;

namespace bankingAPI.Models.EF
{
    public partial class AccountsInfo
    {
        public AccountsInfo()
        {
            TransactionInfoAccNoFromNavigations = new HashSet<TransactionInfo>();
            TransactionInfoAccNoToNavigations = new HashSet<TransactionInfo>();
        }

        public int AccNo { get; set; }
        public string? AccName { get; set; }
        public string? AccType { get; set; }
        public int? AccBalance { get; set; }
        public int? AccBranch { get; set; }

        public virtual BranchInfo? AccBranchNavigation { get; set; }
        public virtual ICollection<TransactionInfo> TransactionInfoAccNoFromNavigations { get; set; }
        public virtual ICollection<TransactionInfo> TransactionInfoAccNoToNavigations { get; set; }
    }
}
