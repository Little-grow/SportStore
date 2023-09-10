using SportsStore.Infrastructure;
using System.Text.Json.Serialization;

namespace SportsStore.Models
{
    public class SessionCart : Cart
    { 
        [JsonIgnore]
        public ISession? Session { get; private set; }

        public static Cart GetCart(IServiceProvider services)
        {
            // get the currnet session from the provided services.
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()
                .HttpContext?.Session;

            //try to get a cart from the session, or create a new one 
            SessionCart cart = session?.GetJson<SessionCart>("cart") ?? new SessionCart();
       
            cart.Session = session;

            return cart;
        }

        public override void AddItem(Product product, int quantity)
        {
            base.AddItem(product, quantity);
            Session?.SetJson("cart", this);
        }

        public override void RemoveLine(Product product)
        {
            base.RemoveLine(product);
            Session?.SetJson("cart", this);
        }

        public override void Clear()
        {
            base.Clear();
            Session?.Remove("cart");
        }
    }
}
    