namespace DigitalWallet.Api.Dispatchers
{
    public interface IQueryDispatcher
    {
        Task<TResult> Send<TQuery, TResult>(TQuery query);
    }
}
