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

        public static bool RegisterACC(string accountHolderName , string accountHolderType ,float currentBalance,string accountHolderPin)
        {
            BankAccount newBankAccount = new BankAccount(accountHolderName,accountHolderType,currentBalance,accountHolderPin);

            if (! BankAccounts.Contains(newBankAccount) )
            {
                BankAccounts.Add(newBankAccount);
                Console.WriteLine("Account has been registered !");
                return true;
            }
            Console.WriteLine(" - Account is already registered before");
            return false;
        }
        public static bool Login(string accountHolderName,string accountPin )
        {
            if (accountHolderName != null && accountPin != null)
            {
                bool found=BankAccount.BankAccounts.Any(BankAccounts  =>
                    BankAccounts.accountHolderName == accountHolderName && BankAccounts.accountHolderPin == accountPin);
                if (!found)
                    return false;
            }
            else
            {
                return false;
            }
            Console.WriteLine(" - Account has been logged in");
            return true;
        }

        public bool WithdrawMoney(float amount)
        {
            if (amount > 0)
            {
                this.currentBalance -= amount;
                Console.WriteLine($"{amount} SEK is withdrawn  successfully !");
                return true;
            }

            return false;
        }


        public bool DepositMoney(float amount)
        {
            if (amount>0)
            {
                this.currentBalance += amount;
                return true;
            }
            return false;
        }

        public float BalanceInquiry()
        {
            Console.WriteLine($"Your current Balance is {this.currentBalance}!");
            return currentBalance;
            
        }

        public string PrintAccDetails()
        {
            string details= "Holder name :" + this.accountHolderName +"\n" 
                + "Holder type :" + this.accountHolderType+"\n" 
                + "Current Balance :"+this.currentBalance;
            return details ;
        }
}