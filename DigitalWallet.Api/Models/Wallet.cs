namespace DigitalWallet.Api.Models
{
    public class Wallet
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string Currency { get; set; }
    }
}
