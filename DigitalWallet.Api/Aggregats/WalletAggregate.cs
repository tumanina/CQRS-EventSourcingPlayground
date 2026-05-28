using DigitalWallet.Api.Commands;
using DigitalWallet.Api.Events;

namespace DigitalWallet.Api.Aggregats
{
    public sealed class WalletAggregate
    {
        public Guid Id { get; private set; }

        public Guid UserId { get; private set; }

        public string Currency { get; private set; } = default!;

        public decimal Balance { get; private set; }

        public bool IsCreated { get; private set; }

        public static WalletAggregate Create(CreateWalletCommand command)
        {
            if (command.Id == Guid.Empty)
            {
                throw new ArgumentException("Id is empty");
            }

            if (command.UserId == Guid.Empty)
            {
                throw new ArgumentException("UserId is empty");
            }

            if (string.IsNullOrWhiteSpace(command.Currency))
            {
                throw new ArgumentException("Currency is required");
            }

            var aggregate = new WalletAggregate();

            var @event = new WalletCreatedEvent(command.Id, command.UserId, command.Currency, DateTime.UtcNow);

            aggregate.Apply(@event);

            return aggregate;
        }

        public void Deposit(DepositMoneyCommand command)
        {
            if (command.Amount <= 0)
            {
                throw new InvalidOperationException("Amount must be positive");
            }

            var @event = new DepositMoneyEvent(Id, command.Amount, DateTime.UtcNow);
            Apply(@event);
        }

        public void Withdraw(WithdrawMoneyCommand command)
        {
            if (command.Amount <= 0)
            {
                throw new InvalidOperationException("Amount must be positive");
            }

            if (Balance < command.Amount)
            {
                throw new InvalidOperationException("Insufficient funds");
            }

            var @event = new WithdrawMoneyEvent(Id, command.Amount, DateTime.UtcNow);
            Apply(@event);
        }

        public void Apply(WalletCreatedEvent @event)
        {
            Id = @event.Id;
            UserId = @event.UserId;
            Currency = @event.Currency;
            Balance = 0;
            IsCreated = true;
        }

        public void Apply(DepositMoneyEvent @event)
        {
            Balance += @event.Amount;
        }

        public void Apply(WithdrawMoneyEvent @event)
        {
            Balance -= @event.Amount;
        }
    }
}
