using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet
{
    internal class Authorization : GetData
    {
        public int accountSearchId { get; set; }
        public int accountDetailSearchId { get; set; }

        //Cheking Account Datas for Authorization
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
    }
}
