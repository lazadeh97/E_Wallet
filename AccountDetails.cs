﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet
{
    internal class AccountDetails : Account
    {
        private int accountNo { get; set; }
        public int AccountNo 
        {
            get { return accountNo; }
            set { accountNo = base.AccountId; } 
        }
        public double balance { get; set; }
        public string currency { get; set; }
        public string description { get; set; }
        public bool isActive { get; set; }
        public List<AccountDetails> details { get; set; }


        public AccountDetails()
        {
            details = new List<AccountDetails>();
        }

        public void GetAccountDetails()
        {
            Console.WriteLine("Hesab teyinati haqqinda aciqlama daxil edin:");
            description = Console.ReadLine();

            Console.WriteLine("Pul vahidini daxil edin:");
            currency = Console.ReadLine();

            Console.WriteLine("Balansi daxil edin:");
            balance = double.Parse(Console.ReadLine());

            details.Add(new AccountDetails() {accountNo = base.AccountId, balance = balance, currency=currency, description = description, isActive=isActive});

            Console.WriteLine("Hesabiniz ugurla yaradildi! Basqa hesabiniz varmi? b/B(Beli) ve ya x/X(xeyir)");

            response = char.Parse(Console.ReadLine());
        }
    }
}
