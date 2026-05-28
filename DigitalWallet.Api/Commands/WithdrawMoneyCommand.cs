namespace DigitalWallet.Api.Commands
{
    public sealed record WithdrawMoneyCommand(Guid WalletId, decimal Amount);
}
