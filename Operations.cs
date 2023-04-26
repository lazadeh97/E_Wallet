using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet
{
    internal class Operations 
    {
        public char operationType { get; set; }

        public double AddingOperation(double money, double balance) 
        {
            balance += money;
            return balance;
        }

        public double GetMoneyFromBalance(double money, double balance) 
        {
            if (balance < 0 || money > balance) { Console.WriteLine("Balansinizda kifayet qeder pul yoxdur!"); }
            else 
            {
                balance -= money;
            }
            return balance;
        }

        public void ChangeCurrentStatus(string currentStatus, bool isActive) 
        {
            if (isActive)
            {
                currentStatus = "Aktiv";
            }
            else
            {
                currentStatus = "Deaktiv";
            }
        }
    }
}
