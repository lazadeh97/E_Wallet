﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet
{
    internal class DataControl : AccountDetails
    {
        public int accountSearchId { get; set; }
        public int accountDetailSearchId { get; set; }
        public List<Account> accounts { get; set; }

        public DataControl()
        {
            accounts = new List<Account>();
            Console.WriteLine("Zehmet olmasa Elektron kassa yaradin:");
        }
        #region InPuts and Additions
        public void GetAccountData()
        {
            Console.WriteLine("Istifadeci adinizi daxil edin: ");
            userName = Console.ReadLine();
            Console.WriteLine("Sifrenizi daxil edin: ");
            password = Console.ReadLine();

            //add random AccounNumber 
            Id = new Random().Next(10000000, 99999999);
            // 

            accounts.Add(new Account() { Id = Id, userName = userName, password = password });

            Console.WriteLine($"Elektron kassaniz ugurla yaradildi! Hesab nomreniz: {Id} \n Davam etmek isteyirsinizmi? b/B(Beli) ve ya x/X(xeyir)");
            response = char.Parse(Console.ReadLine());
        }
        public void GetAccountDetails()
        {
            Console.WriteLine("Hesab teyinati haqqinda aciqlama daxil edin:");
            description = Console.ReadLine();

            Console.WriteLine("Pul vahidini daxil edin: (AZN,USD,TRY,EUR)");
            currency = Console.ReadLine();

            Console.WriteLine("Balansi daxil edin:");
            balance = double.Parse(Console.ReadLine());

            Console.WriteLine("Hesabin statusunu daxil edin (Aktiv/Deaktiv):");
            currentStatus = Console.ReadLine();

            accountDetails.Add(new AccountDetails() { accountNo = base.Id, balance = balance, currency = currency, description = description, currentStatus = currentStatus });

            Console.WriteLine("Hesabiniz ugurla yaradildi! Basqa hesabiniz varmi? b/B(Beli) ve ya x/X(xeyir)");

            response = char.Parse(Console.ReadLine());
        }
        #endregion

        #region ShowingAccountDetails
        public void ShowAccountDetails()
        {
            if (accountDetails.Count>0)
            {
                foreach (var itemDetails in accountDetails.ToArray())
                {
                    Console.WriteLine($"Hesab No: {itemDetails.accountNo}   " +
                                 $"Balans: {itemDetails.balance}    " +
                                 $"Pul Vahidi Balans: {itemDetails.currency}    " +
                                 $"Aciqlama: {itemDetails.description}  " +
                                 $"Cari Veziyyet:  {itemDetails.currentStatus}");
                }
            }
            else
            {
                Console.WriteLine("Sistemde her hansisa bir hesab movcud deyil!");
                return;
            }
            
        }
        public void ShowAccountDetails(int accountNumberForSearch)
        {
            if (accountDetails.Count > 0)
            {
                foreach (var itemDetails in accountDetails.Where(y => y.accountNo == accountNumberForSearch).ToList())
                {
                    Console.WriteLine($"Hesab No: {itemDetails.accountNo}   " +
                                 $"Balans: {itemDetails.balance}    " +
                                 $"Pul Vahidi Balans: {itemDetails.currency}    " +
                                 $"Aciqlama: {itemDetails.description}  " +
                                 $"Cari Veziyyet:  {itemDetails.currentStatus}");
                }
            }
            else
            {
                Console.WriteLine("Sistemde her hansisa bir hesab movcud deyil!");
                return;
            }
            
        }
        #endregion

        #region Cheking Account Datas for Authorization
        public void CheckAccountAuthorization(string _userName, string _password, int _accountNumber)
        {
            if (accounts.Count > 0)
            {
                if (accountDetails.Count > 0)
                {
                    accountSearchId = accounts.Where(i => i.Id == _accountNumber).First().Id;
                    accountDetailSearchId = accountDetails.Where(x => x.accountNo == _accountNumber).First().accountNo;

                    if (accounts.Any(p => p.userName == _userName) && accounts.Any(l => l.password == _password) && accountSearchId == accountDetailSearchId)
                    {
                        ShowAccountDetails(accountDetailSearchId);
                    }
                    else
                    {
                        Console.WriteLine("Daxil edilen melumatlar yanlisdir!");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Sizin elektron kassaniz bosdur zehmet olmasa Hesab yaradin!");
                    GetAccountDetails();
                }
            }
            else
            {
                Console.WriteLine("Sistemde hec bir Elektron Kassa movcud deyildir!");
                return;
            }
        }
        #endregion
    }
}
