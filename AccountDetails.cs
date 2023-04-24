using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet
{
    internal class AccountDetails:Account
    {
        private int accountNo { get; set; }
        public int AccountNo
        {
            get { return accountNo; }
            set { accountNo = AccountId; }
        }

        public double balance { get; set; }
        public string currency { get; set; }
        public string description { get; set; }
        public bool isActive { get; set; }
    }
}
