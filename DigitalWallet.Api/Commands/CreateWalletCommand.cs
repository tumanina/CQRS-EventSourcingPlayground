namespace DigitalWallet.Api.Commands
{
    public sealed record CreateWalletCommand(Guid Id, Guid UserId, string Currency);
}
