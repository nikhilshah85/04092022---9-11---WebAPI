using System;
using System.Collections.Generic;

namespace shoppingWebAPI_EF.Models.EF
{
    public partial class Customer
    {
        public int CId { get; set; }
        public string? CName { get; set; }
        public string? CCategory { get; set; }
        public string? CLocation { get; set; }
        public int? CWallet { get; set; }
        public bool? CIsActive { get; set; }
    }
}
