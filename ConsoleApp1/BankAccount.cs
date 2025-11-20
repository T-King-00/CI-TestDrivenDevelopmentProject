namespace ConsoleApp1;

public class BankAccount
{
    private string accountHolderName;
    private Guid accountHolderNumber;
    private string accountHolderPin;
    private string accountHolderPhoneNumber;
    private string accountHolderType;
    private float currentBalance;

    public string AccountHolderName => accountHolderName;

    public Guid AccountHolderNumber => accountHolderNumber;

    public string AccountHolderPin => accountHolderPin;

    public string AccountHolderPhoneNumber => accountHolderPhoneNumber;

    public string AccountHolderType => accountHolderType;

    public float CurrentBalance => currentBalance;
    public static List<BankAccount> BankAccounts = new List<BankAccount>();

    public static void Intiate()
    {
        BankAccount acc1 = new BankAccount("mike", "free", 100, "1234");
        BankAccount acc2 = new BankAccount("jake", "free", 100, "1234");
        BankAccount acc3 = new BankAccount("micheal", "free", 100, "1234");

        BankAccounts.Add(acc1);
        BankAccounts.Add(acc2);
        BankAccounts.Add(acc3);
    }
    public BankAccount(string accountHolderName , string accountHolderType ,float currentBalance,string accountHolderPin)
    {
        this.accountHolderName = accountHolderName;
        this.accountHolderNumber =Guid.NewGuid();
        this.accountHolderType = accountHolderType;
        this.currentBalance = currentBalance;
        this.accountHolderPin = accountHolderPin;
        try
        {
            if (accountHolderName != null && currentBalance != null)
            {
                    
            }
            else
            {
                throw  new Exception("Account Holder Name and Balance are required");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw e.GetBaseException();
        }
        
    }


    public bool DepositMoney(float amountOfMoneyToDeposit)
    {
        throw new NotImplementedException();
    }

    public float BalanceInquiry()
    {
        throw new NotImplementedException();
    }

    public static bool Login(string peter, string validPin)
    {
        throw new NotImplementedException();
    }

    public void WithdrawMoney(float amountOfMoneyToWithdraw)
    {
        throw new NotImplementedException();
    }

    public object PrintAccDetails()
    {
        throw new NotImplementedException();
    }
}