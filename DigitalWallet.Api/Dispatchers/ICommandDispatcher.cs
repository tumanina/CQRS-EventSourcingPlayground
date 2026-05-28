namespace DigitalWallet.Api.Dispatchers
{
    public interface ICommandDispatcher
    {
        Task<TResult> Send<TCommand, TResult>(TCommand command);
    }
}
