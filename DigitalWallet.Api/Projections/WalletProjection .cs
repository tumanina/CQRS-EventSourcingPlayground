using DigitalWallet.Api.Events;
using DigitalWallet.Api.Models;
using Marten.Events.Aggregation;

namespace DigitalWallet.Api.Projections
{
    public partial  class WalletProjection : SingleStreamProjection<WalletView, Guid>
    {
        public WalletView Create(WalletCreatedEvent e)
        {
            return new WalletView
            {
                Id = e.Id,
                UserId = e.UserId,
                Currency = e.Currency,
                Balance = 0
            };
        }

        public void Apply(DepositMoneyEvent e, WalletView view)
        {
            view.Balance += e.Amount;
        }

        public void Apply(WithdrawMoneyEvent e, WalletView view)
        {
            view.Balance -= e.Amount;
        }
    }
}
