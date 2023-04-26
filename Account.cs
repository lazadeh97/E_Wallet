using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet
{
    internal class Account
    {
        public int Id { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public char response { get; set; }
        public bool isTrue { get; set; }
        //public List<Account> accounts { get; set; }
        public List<AccountDetails> accountDetails { get; set; }

        public Account() 
        {
            accountDetails = new List<AccountDetails>();
        }       
    }
}
