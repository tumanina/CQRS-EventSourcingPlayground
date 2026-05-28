namespace DigitalWallet.Api.Models
{
    public sealed class WalletView
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string Currency { get; set; } = default!;

        public decimal Balance { get; set; }
    }
}
