using E_Wallet;
using System.Collections.Generic;

//Use variables for login to E-Wallet
string userName = string.Empty;
string password = string.Empty;
int accountNumber = 0;

//Get instances
GetData getData = new GetData();
AccountDetails details = new AccountDetails();

//Use Sign Details 
getData.GetAccountData();

if (getData.response.Equals('b') || getData.response.Equals('B'))
{
    while (getData.isTrue)
    {
        getData.GetAccountDetails();

        if (getData.response.Equals('b') || getData.response.Equals('B'))
        {
            getData.GetAccountData();
        }
        else 
        {
            AskToLogin();
            getData.isTrue = false;
        }
    }
}
else
{
    AskToLogin();
}

//Asking to Login
void AskToLogin()
{
    Console.WriteLine("Hesabiniza giris etmek isteyirsinizmi? b/B(beli), x/X(xeyir)");
    details.response = char.Parse(Console.ReadLine());

    if (details.response.Equals('b') || details.response.Equals('B'))
    {
        SignInToAccount();
        getData.CheckAccountAuthorization(userName, password, accountNumber);
    }
    else
    {
        return;
    }
}

//Get Sign In data
void SignInToAccount()
{
    Console.WriteLine("Giris ucun Istifadeci adinizi daxil edin:");
    userName = Console.ReadLine();
    Console.WriteLine("Giris ucun Sifrenizi daxil edin:");
    password = Console.ReadLine();
    Console.WriteLine("Giris ucun Hesab nomrenizi daxil edin:");
    accountNumber = int.Parse(Console.ReadLine());
}







