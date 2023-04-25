using E_Wallet;
using System.Collections.Generic;

Console.WriteLine("Zehmet olmasa Elektron kassa yaradin:");

AccountDetails details = new AccountDetails();
details.details = new List<AccountDetails>();
details.GetAccountData();

if (details.response.Equals('b') || details.response.Equals('B'))
{
    while (true)
    {
        details.GetAccountDetails();

        if (details.response.Equals('b') || details.response.Equals('B'))
        {
            details.GetAccountData();
            details.isTrue = true;
        }
        else { break; }
    }

    foreach (var item in details.accounts.ToArray())
    {
        Console.WriteLine(item.AccountId + " " + item.userName + " " + item.password);
    }
    foreach (var itemDetails in details.details.ToArray())
    {
        Console.WriteLine($"Hesab No: {itemDetails.AccountNo}   " +
                          $"Balans: {itemDetails.balance}    " +
                          $"Pul Vahidi Balans : {itemDetails.currency}    " +
                          $"Aciqlama:  {itemDetails.description}  " +
                          $"Cari V:  {itemDetails.isActive}");
    }
}
else
{
    details.isTrue = false;
}







