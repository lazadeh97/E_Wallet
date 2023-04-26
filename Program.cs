using E_Wallet;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

//Use variables for login to E-Wallet
string userName = string.Empty;
string password = string.Empty;
int accountNumber = 0;

//auxiliary variables
double money = 0;
char signer = '\0';
string currentStatus=string.Empty;

//Get instances
Admin admin = new Admin();
DataControl dataControl = new DataControl();
Operations operations = new Operations();
AccountDetails details = new AccountDetails();

//Use Sign Details 
dataControl.GetAccountData();

if (dataControl.response.Equals('b') || dataControl.response.Equals('B'))
{
    while (dataControl.isTrue)
    {
        dataControl.GetAccountDetails();

        if (dataControl.response.Equals('b') || dataControl.response.Equals('B'))
        {
            dataControl.GetAccountData();
        }
        else
        {
            AskToLogin();
            dataControl.isTrue = false;
        }
    }
}
else
{
    AskToLogin();
}

void SignerType()
{
    Console.WriteLine("Hesaba baxis ucun kimliyinizi tesdiq edin: \n 1. Musteri \n 2. Admin");
    signer = char.Parse(Console.ReadLine());
    if (signer.Equals('1'))
    {
        AskToLogin();
    }
    else
    {
        AdminLogin();
    }
}

//Watch All Accounts
void AdminLogin()
{
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
            dataControl.ShowAccountDetails();
        }
        else
        {
            Console.WriteLine("Sifreniz ve ya istifadeci adiniz yanlisdir!");
        }
    }
    else
    {
        SignerType();
    }

}


void DoOperationViaAccount()
{
    Console.WriteLine("Hesab uzerinde aparilacaq emeliyyati secin: \n 1. Hesaba pul yatirt \n 2. Hesabdan pul cek \n " +
    "3. Hesab uzre prosesleri goster \n 4. Hesabi aktiv ve ya deaktiv edin \n 5. Esas menyuya geri don \n");

    Proses: Console.WriteLine("Emeliyyatin nomresi: ");
    operations.operationType = char.Parse(Console.ReadLine());
    switch (operations.operationType)
    {
        case '1':
            Console.WriteLine("Balansa elave edeceyiniz meblegi daxil edin:");
            money = double.Parse(Console.ReadLine());
            dataControl.balance = operations.AddingOperation(dataControl.balance, money);
            Console.WriteLine($"Cari balansiniz: {dataControl.balance}");
            goto Proses;
        case '2':
            Console.WriteLine("Balansdan cixaracaginiz meblegi daxil edin:");
            money = double.Parse(Console.ReadLine());
            dataControl.balance = operations.GetMoneyFromBalance(dataControl.balance, money);
            Console.WriteLine($"Cari balansiniz: {dataControl.balance}");
            goto Proses;
        case '3':
            Console.WriteLine("Hesab uzerinde olan prosesleri goster: ");
            foreach (var operations in operations.operations)
            {
                Console.WriteLine(operations);
            }
            goto Proses;
        case '4':
            Console.WriteLine("Hesabinizi aktivlesdirin ve ya dondurun (Aktiv etmek ucun - (a/A), Deaktiv etmek ucun d/(D) daxil edin):");
            currentStatus = Console.ReadLine();
            dataControl.currentStatus = operations.ChangeCurrentStatus(currentStatus);
            Console.WriteLine($"Cari hesab statusunuz: {dataControl.currentStatus}");
            goto Proses;
        case '5':
            DoOperationViaAccount();
            break;
        default:
            break;
    }
}

//Asking to Login
void AskToLogin()
{
    Console.WriteLine("Hesabiniza giris etmek isteyirsinizmi? b/B(beli), x/X(xeyir)");
    details.response = char.Parse(Console.ReadLine());

    if (details.response.Equals('b') || details.response.Equals('B'))
    {
        SignInToAccount();
        dataControl.CheckAccountAuthorization(userName, password, accountNumber);
        DoOperationViaAccount();
    }
    else
    {
        SignerType();
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







