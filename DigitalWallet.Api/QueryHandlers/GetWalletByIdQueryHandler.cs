using DigitalWallet.Api.Models;
using DigitalWallet.Api.Queries;
using Marten;

namespace DigitalWallet.Api.QueryHandlers
{
    public sealed class GetWalletByIdQueryHandler(IQuerySession session) : IQueryHandler<GetWalletByIdQuery, WalletView?>
    {
        private readonly IQuerySession _session = session;

        public async Task<WalletView?> Handle(GetWalletByIdQuery query)
        {
            return await _session.LoadAsync<WalletView>(query.WalletId);
        }
    }
}
