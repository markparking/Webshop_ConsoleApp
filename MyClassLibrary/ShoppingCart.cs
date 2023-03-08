using System.Collections.Generic;

namespace MyClassLibrary
{
    public class ShoppingCart
    {
        private List<CartItem> _items;

        public ShoppingCart()
        {
            _items = new List<CartItem>();
        }

        public void AddItem(CartItem item)
        {
            _items.Add(item);
        }

        public void RemoveItem(CartItem item)
        {
            _items.Remove(item);
        }

        public void Clear()
        {
            _items.Clear();
        }

        public List<CartItem> GetItems()
        {
            return _items;
        }

        public double GetTotal()
        {
            double total = 0;
            foreach (CartItem item in _items)
            {
                total += item.Price * item.Quantity;
            }
            return total;
        }

        public bool IsEmpty()
        {
            return _items.Count == 0;
        }
    }

}
