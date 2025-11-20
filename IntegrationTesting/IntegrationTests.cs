namespace IntegrationTest;

using NUnit.Framework.Constraints;
using NUnit.Framework;
using ConsoleApp1;

// Integration tests 
[TestFixture]
public class IntegrationTests
{

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        BankAccount.Intiate();
        Console.WriteLine("onetime setup");
    }


    /* integration test case 1 :
    Description : Test create account and logining in modules*/

    [Test]
    [Category("IntegrationTest")]
    public static void Register_Login_ReturnsTrue()
    {

        string accountHolderName = "Andrew";
        string accountHolderType = "Free";
        float balance = 100f;
        string validPin = "12346789";

        //register
        BankAccount newBankAccount = new BankAccount(accountHolderName, accountHolderType, balance, validPin);
        Boolean result0 = BankAccount.RegisterACC(accountHolderName, accountHolderType, balance, validPin);
        Assert.That(result0);
        //login
        bool result1 = BankAccount.Login(accountHolderName, validPin);

        //ASSERT
        Assert.That(result1);

    }

    /*integration test case 2 :
     Description : Test logging in and depositing money */
    [Test]
    [Category("IntegrationTest")]
    public void Login_DepositM_ReturnsTrue()
    {
        string accountHolderName = "mike";
        string accountHolderType = "Free";
        float balance = 1020f;
        string validPin = "1234";
        //login
        BankAccount bankAcc_testObj = new BankAccount(accountHolderName, accountHolderType, balance, validPin);
        bool result = BankAccount.Login(accountHolderName, validPin);
        Assert.That(result);

        //deposit amount of money.
        float depositAmount = 1000;
        bankAcc_testObj.DepositMoney(depositAmount);
        float actualBalance = bankAcc_testObj.BalanceInquiry();
        Assert.That(actualBalance, Is.EqualTo(balance + depositAmount));

    }
}




