namespace DigitalWallet.Api.Events
{
    public record DepositMoneyEvent(Guid WalletId, decimal Amount, DateTime CreatedAtUtc);
}
