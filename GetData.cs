using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet
{
    internal class GetData : AccountDetails
    {
        public int accountSearchId { get; set; }
        public int accountDetailSearchId { get; set; }
        public List<Account> accounts { get; set; }

        public GetData()
        {
            accounts = new List<Account>();
            Console.WriteLine("Zehmet olmasa Elektron kassa yaradin:");
        }
        public void GetAccountData()
        {
            Console.WriteLine("Istifadeci adinizi daxil edin: ");
            userName = Console.ReadLine();
            Console.WriteLine("Sifrenizi daxil edin: ");
            password = Console.ReadLine();

            Id = new Random().Next(00000001, 99999999);
            accounts.Add(new Account() { Id = Id, userName = userName, password = password });

            Console.WriteLine("Elektron kassaniz ugurla yaradildi! Davam etmek isteyirsinizmi? b/B(Beli) ve ya x/X(xeyir)");
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

            accountDetails.Add(new AccountDetails() { accountNo = base.Id, balance = balance, currency = currency, description = description, isActive = isActive });

            Console.WriteLine("Hesabiniz ugurla yaradildi! Basqa hesabiniz varmi? b/B(Beli) ve ya x/X(xeyir)");

            response = char.Parse(Console.ReadLine());
        }

        public void ShowAccountDetails()
        {
            foreach (var itemDetails in accountDetails.ToArray())
            {
                Console.WriteLine($"Hesab No: {itemDetails.accountNo}   " +
                             $"Balans: {itemDetails.balance}    " +
                             $"Pul Vahidi Balans: {itemDetails.currency}    " +
                             $"Aciqlama: {itemDetails.description}  " +
                             $"Cari Veziyyet:  {itemDetails.isActive}");
            }
        }
        public void ShowAccountDetails(int accountNumberForSearch)
        {
            foreach (var itemDetails in accountDetails.Where(y => y.accountNo == accountNumberForSearch).ToList())
            {
                Console.WriteLine($"Hesab No: {itemDetails.accountNo}   " +
                             $"Balans: {itemDetails.balance}    " +
                             $"Pul Vahidi Balans: {itemDetails.currency}    " +
                             $"Aciqlama: {itemDetails.description}  " +
                             $"Cari Veziyyet:  {itemDetails.isActive}");
            }
        }
        public void CheckAccountAuthorization(string _userName, string _password, int _accountNumber)
        {
            accountSearchId = accounts.Where(i => i.Id == _accountNumber).First().Id;
            accountDetailSearchId = accountDetails.Where(x => x.accountNo == _accountNumber).First().accountNo;

            if (accounts.Any(p=>p.userName == _userName) && accounts.Any(l=>l.password == _password) && accountSearchId == accountDetailSearchId)
            {
                //if (accountSearchId == accountDetailSearchId)
                //{
                    ShowAccountDetails(accountDetailSearchId);
                //}
            }
           
        }
    }
}
