namespace DigitalWallet.Api.CommandHandlers
{
    public interface ICommandHandler<TCommand, TResult>
    {
        Task<TResult> Handle(TCommand command);
    }
}
