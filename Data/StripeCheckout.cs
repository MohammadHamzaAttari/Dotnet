

namespace Backend.Data
{
    public class StripeCheckout : Base
    {
        public string? SessionId { get; set; }
        public string? PubKey { get; set; }
    }
}
