using DigitalWallet.Api.Aggregats;
using DigitalWallet.Api.Commands;
using DigitalWallet.Api.Events;
using Marten;

namespace DigitalWallet.Api.CommandHandlers
{
    public sealed class CreateWalletCommandHandler(IDocumentSession session) : ICommandHandler<CreateWalletCommand, Guid>
    {
        private readonly IDocumentSession _session = session;

        public async Task<Guid> Handle(CreateWalletCommand command)
        {
            var aggregate = WalletAggregate.Create(command);

            var @event = new WalletCreatedEvent(aggregate.Id, aggregate.UserId, aggregate.Currency, DateTime.UtcNow);

            _session.Events.StartStream<WalletAggregate>(aggregate.Id, @event);
            await _session.SaveChangesAsync();

            return aggregate.Id;
        }
    }
}
