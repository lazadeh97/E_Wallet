﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet
{
    internal class Account
    {
        private int accountId { get; set; }
        public  int AccountId 
        {
            get { return accountId; }   
            set { accountId = new Random().Next(00000001, 99999999); }
        }

        public string userName { get; set; }
        public string password { get; set; }
        public char response { get; set; }
        public bool isTrue { get; set; }
        public List<Account> accounts { get; set; }

        public Account() 
        {
            //accountId = new Random().Next(00000001, 99999999);
            accounts = new List<Account>();
        }
        //public Account(int accountID)
        //{
        //    accountID = new Random().Next(00000001, 99999999);
        //    accountId = accountID;
        //}

        public void GetAccountData()
        {
            Console.WriteLine("Istifadeci adinizi daxil edin: ");
            userName = Console.ReadLine();
            Console.WriteLine("Sifrenizi daxil edin: ");
            password = Console.ReadLine();
           
            accounts.Add(new Account() {AccountId = AccountId, userName = userName, password = password });
                  
            Console.WriteLine("Elektron kassaniz ugurla yaradildi! Davam etmek isteyirsinizmi? b/B(Beli) ve ya x/X(xeyir)");
            response = char.Parse(Console.ReadLine());
        }
    }
}
