namespace DigitalWallet.Api.Events
{
    public record WithdrawMoneyEvent(Guid WalletId, decimal Amount, DateTime CreatedAtUtc);
}
