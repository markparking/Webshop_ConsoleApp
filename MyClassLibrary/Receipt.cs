using System;
using System.Collections.Generic;

namespace MyClassLibrary
{
    public class Receipt
    {
        private string _user;
        public List<CartItem> _items;
        private double _total;

        public Receipt(string user, ShoppingCart cart)
        {
            _user = user;
            _items = new List<CartItem>(cart.GetItems());
            _total = cart.GetTotal();
        }

        public override string ToString()
        {
            string output = $"User: {_user}\n";
            output += "Items:\n";
            foreach (CartItem item in _items)
            {
                output += $"- {item.Quantity} x {item.Product.Name} @ ${item.Price}\n";
            }
            output += $"Total: ${_total:F2}\n";
            return output;
        }

    }
}
