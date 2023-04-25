using E_Wallet;
using System.Collections.Generic;

string userName = string.Empty;
string password = string.Empty;
int accountNumber = 0;

GetData getData = new GetData();
AccountDetails details = new AccountDetails();
//details.details = new List<AccountDetails>();
getData.GetAccountData();

if (getData.response.Equals('b') || getData.response.Equals('B'))
{
    while (true)
    {
        getData.GetAccountDetails();
        Console.WriteLine(getData.accountId);

        if (getData.response.Equals('b') || getData.response.Equals('B'))
        {
            getData.GetAccountData();
            getData.isTrue = true;
        }
        else 
        {          
            Console.WriteLine("Hesabiniza giris etmek isteyirsinizmi? b/B(beli), x/X(xeyir)");
            details.response = char.Parse(Console.ReadLine());

            if (details.response.Equals('b') || details.response.Equals('B'))
            {
                AddAccountData();
                getData.CheckAccountAuthorization(userName, password, accountNumber);
            }
            else
            {
                return;
            }
        }
        getData.isTrue = false;
    }
}
else
{
    Console.WriteLine("Hesabiniza giris etmek isteyirsinizmi? b/B(beli), x/X(xeyir)");
    details.response = char.Parse(Console.ReadLine());

    if (details.response.Equals('b') || details.response.Equals('B'))
    {
        AddAccountData();
        getData.CheckAccountAuthorization(userName, password, accountNumber);
    }
}

void AddAccountData()
{
    Console.WriteLine("Giris ucun Istifadeci adinizi daxil edin:");
    userName = Console.ReadLine();
    Console.WriteLine("Giris ucun Sifrenizi daxil edin:");
    password = Console.ReadLine();
    Console.WriteLine("Giris ucun Hesab nomrenizi daxil edin:");
    accountNumber = int.Parse(Console.ReadLine());
}







