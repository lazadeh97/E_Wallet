using E_Wallet;
using System.Collections.Generic;

//Use variables for login to E-Wallet
string userName = string.Empty;
string password = string.Empty;
int accountNumber = 0;

double money = 0;

//Get instances
Admin admin = new Admin();
GetData getData = new GetData();
Operations operations = new Operations();
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

//Watch All Accounts
Console.WriteLine("Butun hesablara baxmaq isteyirsinizmi? b/B(beli), x/X(xeyir)");
details.response = char.Parse(Console.ReadLine());
if (details.response.Equals('b') || details.response.Equals('B'))
{
    Console.WriteLine("Admin istifadeci adinizi  daxil edin:");
    userName = Console.ReadLine();
    Console.WriteLine("Admin sifrenizi  daxil edin:");
    password = Console.ReadLine();

    if (userName.Equals(admin.UserName) && password.Equals(admin.PassWord))
    {
        getData.ShowAccountDetails();
    }
}
else
{
    AskToLogin();
}

Console.WriteLine("Hesab uzerinde aparilacaq emeliyyati secin: \n 1. Hesaba pul yatirt \n 2. Hesabdan pul cek \n " +
    "3. Hesab uzre prosesleri goster \n 4. Hesabi aktiv ve ya deaktiv edin \n 5. Esas menyuya geri don");
operations.operationType = char.Parse(Console.ReadLine());
if (operations.operationType.Equals("1"))
{
    money = double.Parse(Console.ReadLine());
    getData.balance = operations.AddingOperation(money, getData.balance);
    Console.WriteLine($"Cari balansiniz: {getData.balance}");
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







