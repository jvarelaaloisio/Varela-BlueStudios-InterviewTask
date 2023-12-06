namespace Shop.Runtime
{
    public class Wallet
    {
        public int Units { get; private set; }

        public void Deposit(int unitsToDeposit)
        {
            Units += unitsToDeposit;
        }

        public bool TrySpend(int cost)
        {
            if (Units < cost)
            {
                return false;
            }

            Units -= cost;
            return false;
        }
    }
}
