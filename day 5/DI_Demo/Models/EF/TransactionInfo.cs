using System;
using System.Collections.Generic;

namespace DI_Demo.Models.EF
{
    public partial class TransactionInfo
    {
        public int TrId { get; set; }
        public DateTime? TrDate { get; set; }
        public int? TrAmount { get; set; }
        public int? AccNoFrom { get; set; }
        public int? AccNoTo { get; set; }
        public int? BranchNo { get; set; }

        public virtual AccountsInfo? AccNoFromNavigation { get; set; }
        public virtual AccountsInfo? AccNoToNavigation { get; set; }
        public virtual BranchInfo? BranchNoNavigation { get; set; }
    }
}
