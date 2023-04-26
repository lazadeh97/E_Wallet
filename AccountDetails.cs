﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet
{
    internal class AccountDetails : Account
    {
        public int accountNo { get; set; }
        public double balance { get; set; }
        public string currency { get; set; }
        public string description { get; set; }
        public bool isActive { get; set; }
        //public List<AccountDetails> details { get; set; }

        public AccountDetails()
        {
            //details = new List<AccountDetails>();
        }        
    }
}
