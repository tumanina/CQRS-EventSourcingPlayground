using DigitalWallet.Api.QueryHandlers;

namespace DigitalWallet.Api.Dispatchers
{
    public sealed class QueryDispatcher(IServiceProvider provider) : IQueryDispatcher
    {
        private readonly IServiceProvider _provider = provider;

        public async Task<TResult> Send<TQuery, TResult>(TQuery query)
        {
            var handler = _provider.GetRequiredService< IQueryHandler<TQuery, TResult>>();

            return await handler.Handle(query);
        }
    }
}
