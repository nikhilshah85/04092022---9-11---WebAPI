namespace bankingAPI.Models.EF
{
    public class AccountsTransactionBranch
    {

        public int accountNo { get; set; }
        public string accName { get; set; } = "";
        public string accType { get; set; } = "";
        public int accBalance { get; set; } = 0;
         public int branchNo { get; set; }
        public string branchName { get; set; } = "";
        public string branchCity { get; set; } = "";


        public List<AccountsTransactionBranch> GetAccountDetails()
        {
            bankingDBAPIContext db = new bankingDBAPIContext();
            var accInfo = (from a in db.AccountsInfos
                          join b in db.BranchInfos
                          on a.AccBranch equals b.BranchId
                          select new AccountsTransactionBranch()
                          {
                              accountNo = a.AccNo,
                              accName = a.AccName, 
                              accType = a.AccType,
                              accBalance = (int)a.AccBalance,
                              branchNo =(int)a.AccBranch,
                              branchName = b.BranchName,
                              branchCity = b.BranchCity
                          });

            return accInfo.ToList();
        }



    }
}
