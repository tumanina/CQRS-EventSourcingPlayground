namespace DigitalWallet.Api.Commands
{
    public sealed record DepositMoneyCommand(Guid WalletId, decimal Amount);
}
