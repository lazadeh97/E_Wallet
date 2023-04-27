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
        public List<double> operations { get; set; }
        public Operations() 
        { 
            operations = new List<double>();    
        }

        public double AddingOperation(double balance, double money) 
        {
            balance += money;
            operations.Add(+money);
            return balance;
        }

        public double GetMoneyFromBalance(double balance, double money) 
        {
            if (balance == 0 || money > balance) { Console.WriteLine("Balansinizda kifayet qeder pul yoxdur!"); }
            else 
            {
                balance -= money;
            }
            operations.Add(-money);
            return balance;
        }

        public string ChangeCurrentStatus(string currentStatus) 
        {
            if (currentStatus.Equals("a")||currentStatus.Equals("A"))
            {
                currentStatus = "Aktiv";
            }
            else
            {
                currentStatus = "Deaktiv";
            }
            return currentStatus;
        }
    }
}
