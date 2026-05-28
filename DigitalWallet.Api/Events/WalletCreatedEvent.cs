namespace DigitalWallet.Api.Events
{
    public sealed record WalletCreatedEvent(Guid Id, Guid UserId, string Currency, DateTime CreatedAtUtc);
}
