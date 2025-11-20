namespace UnitTesting;
using ConsoleApp1;
using NUnit.Framework.Constraints;
using NUnit.Framework;

public class UnitTests
{
    const string  accountHolderName= "Peter";
    const string accountHolderType = "Free";
    const float defaultBalance  = 1000f;
    const string validPin = "1234";
    BankAccount testObjBankAccount;
    
    
    [SetUp]
    public void Setup()
    {
        testObjBankAccount=new BankAccount(accountHolderName, accountHolderType,defaultBalance, validPin);
        //arrange
    }

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        BankAccount.Intiate();
        Console.WriteLine("onetime setup");
        testObjBankAccount=new BankAccount(accountHolderName, accountHolderType,defaultBalance, validPin);

        BankAccount.BankAccounts.Add(testObjBankAccount);

    }

     [TearDown]
    public void Teardown()
    {
        testObjBankAccount = null;
    }
    

    [Test]
    [Category("authentication")]
    public void  VerifyUser_ValidPinCode_ReturnsTrue()
    {
        //arrange
        //act
        bool result = BankAccount.Login(accountHolderName, validPin);
        //assert
        Assert.That(result);
        
    }

    [Test]
    [Category("methods")]
    public void WithdrawSpecificAmount_WithinBalanceLimit_returnsT()
    {
        float amountOfMoneyToWithdraw = 100;
        float expectedValue = defaultBalance - amountOfMoneyToWithdraw;
        float actualValue = 0;
        
        testObjBankAccount.WithdrawMoney(amountOfMoneyToWithdraw);
        actualValue = testObjBankAccount.BalanceInquiry();
        Assert.That(expectedValue, Is.EqualTo(actualValue)," Widthdarw process failed  ! ");
        
       
    }
    

    [Test]
    [Category("methods")]
  
    public void Deposit_WithinAllowedLimits_ReturnT()
    {   //arange 
        float amountOfMoneyToDeposit = 100;
        //act
        bool result = testObjBankAccount.DepositMoney(amountOfMoneyToDeposit);
        //assert
        Assert.That(result);
        Assert.That(testObjBankAccount.BalanceInquiry(), Is.EqualTo(defaultBalance + amountOfMoneyToDeposit));
        

    }
    

    [Test]
    [Category("print")]
    public void BalanceInquiry_ReturnsBalance()
    {
        float result = testObjBankAccount.BalanceInquiry();
        //arange 
        //act
        //assert
        

    }
    
    [Test]
    [Category("print")]
    public void AccountDetails_ReturnsDetails()
    {
        //arrange
        float expectedBalance =0 ;
        string details = "Holder name :" + testObjBankAccount.AccountHolderName + "\n"
                         + "Holder type :" + testObjBankAccount.AccountHolderType + "\n"
                         + "Current Balance :" + testObjBankAccount.CurrentBalance.ToString() ;
        
        //act
        float actualBalance = testObjBankAccount.BalanceInquiry();
        //assert
        Assert.That(testObjBankAccount.PrintAccDetails(),Is.EqualTo(details),"There is an Error");
    }

    
}