namespace MyClassLibrary
{
    public class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public double Price { get { return Product.Price * Quantity; } }

        public CartItem(string itemName, int itemPrice, int quantity)
        {
            Product = new Product(itemName, itemPrice);
            Quantity = quantity;
        }

        public override string ToString()
        {
            return $"{Product.Name} x {Quantity} - ${Price}";
        }

    }
}