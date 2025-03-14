namespace TheBanks.Models
{
    public class SavingsAccount : Account
    {
        public SavingsAccount(string number, Person owner) : base(number, owner)
        {
        }
        
        public override double CalculateInterests() 
        {
            return Balance * 0.045; 
        }

        
        public double CalculateBalance()
        {
            return Balance;
        }

        public async Task Transfer(SavingsAccount account2, int amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Le montant doit être supérieur à zéro.", nameof(amount));
            }

            
             Withdraw(amount);
            
             account2.Deposit(amount); 
        }
        
    }
}   