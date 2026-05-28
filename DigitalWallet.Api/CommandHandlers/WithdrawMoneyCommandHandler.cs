using DigitalWallet.Api.Aggregats;
using DigitalWallet.Api.Commands;
using DigitalWallet.Api.Events;
using Marten;

namespace DigitalWallet.Api.CommandHandlers
{
    public sealed class WithdrawMoneyCommandHandler(IDocumentSession session) : ICommandHandler<WithdrawMoneyCommand, bool>
    {
        private readonly IDocumentSession _session = session;

        public async Task<bool> Handle(WithdrawMoneyCommand command)
        {
            var aggregate = await _session.Events.AggregateStreamAsync<WalletAggregate>(command.WalletId);

            if (aggregate is null)
            {
                throw new Exception("Wallet not found");
            }

            aggregate.Withdraw(command);

            _session.Events.Append(command.WalletId, new WithdrawMoneyEvent(command.WalletId, command.Amount, DateTime.UtcNow));

            await _session.SaveChangesAsync();

            return true;
        }
    }
}
