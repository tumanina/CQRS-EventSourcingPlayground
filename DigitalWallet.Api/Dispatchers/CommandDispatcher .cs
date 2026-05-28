using DigitalWallet.Api.CommandHandlers;

namespace DigitalWallet.Api.Dispatchers
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _provider;

        public CommandDispatcher(IServiceProvider provider)
        {
            _provider = provider;
        }

        public async Task<TResult> Send<TCommand, TResult>(TCommand command)
        {
            var handler = _provider.GetRequiredService<ICommandHandler<TCommand, TResult>>();
            return await handler.Handle(command);
        }
    }
}
