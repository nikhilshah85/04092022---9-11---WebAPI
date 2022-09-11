using System;
using System.Collections.Generic;

namespace bankingAPI.Models.EF
{
    public partial class BranchInfo
    {
        public BranchInfo()
        {
            AccountsInfos = new HashSet<AccountsInfo>();
            TransactionInfos = new HashSet<TransactionInfo>();
        }

        public int BranchId { get; set; }
        public string? BranchName { get; set; }
        public string? BranchCity { get; set; }

        public virtual ICollection<AccountsInfo> AccountsInfos { get; set; }
        public virtual ICollection<TransactionInfo> TransactionInfos { get; set; }
    }
}
