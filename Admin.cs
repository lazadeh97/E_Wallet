using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet
{
    internal class Admin
    {
        private static string userName { get; set; }
        public string UserName
        {
            get { return userName; }

            set 
            { 
                userName = value; 
                value = "admin"; 
            } 
        }
        private static string passWord { get; set; }
        public string PassWord
        {
            get { return passWord; }

            set
            {
                passWord = value;
                value = "admin";
            }
        }
    }
}
