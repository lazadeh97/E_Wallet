using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet
{
    internal class GetData : AccountDetails
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int AccountNumber { get; set; }

        public GetData()
        {
            Console.WriteLine("Zehmet olmasa Elektron kassa yaradin:");
        }
        public void GetAccountData()
        {
            Console.WriteLine("Istifadeci adinizi daxil edin: ");
            userName = Console.ReadLine();
            Console.WriteLine("Sifrenizi daxil edin: ");
            password = Console.ReadLine();

            accountId = new Random().Next(00000001, 99999999);
            accounts.Add(new Account() { accountId = accountId, userName = userName, password = password });

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

            details.Add(new AccountDetails() { accountNo = base.accountId, balance = balance, currency = currency, description = description, isActive = isActive });

            Console.WriteLine("Hesabiniz ugurla yaradildi! Basqa hesabiniz varmi? b/B(Beli) ve ya x/X(xeyir)");

            response = char.Parse(Console.ReadLine());
        }

        public void ShowAccountDetails()
        {
            foreach (var itemDetails in details.ToArray())
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
            this.UserName = _userName;
            this.Password = _password;
            this.AccountNumber = _accountNumber;

            Console.WriteLine(details.FirstOrDefault(x => x.accountId == AccountNumber));



            if (UserName.Equals(userName) && Password.Equals(password) && accountNo.Equals(details.FirstOrDefault(x => x.accountId == AccountNumber)));
            {
                ShowAccountDetails();
            }
        }
        //foreach (var item in getData.accounts.ToArray())
        //{
        //    Console.WriteLine(item.accountId + " " + item.userName + " " + item.password);
        //}
    }
}
