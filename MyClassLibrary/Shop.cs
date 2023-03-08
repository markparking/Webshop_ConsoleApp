using System;
using System.Collections.Generic;
using MyClassLibrary;

namespace MyClassLibrary
{
    public class Shop
    {
        private User _currentUser;
        private ShoppingCart _cart;
        private List<Receipt> _receipts;
        private List<User> _users;


        public Shop()
        {
            _users = new List<User>();
            _cart = new ShoppingCart();
            _receipts = new List<Receipt>();
        }

        public void Login2()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();

            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            _currentUser = _users.Find(u => u.Username == username && u.Password == password);

            if (_currentUser == null)
            {
                Console.WriteLine("Invalid username or password.");
                return;
            }

            Console.WriteLine($"Welcome, {_currentUser.Username}!");
        }

        public void CreateUser()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();

            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            _users.Add(new User(username, password));

            Console.WriteLine($"User {username} created.");
        }

        public void MainMenu()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Please select an option:");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Create User");
                Console.WriteLine("3. Exit");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Login2();
                        break;
                    case 2:
                        CreateUser();
                        break;
                    case 3:
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

                if (_currentUser != null)
                {
                    break;
                }
            }

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Please select an option:");
                Console.WriteLine("1. Browse Products");
                Console.WriteLine("2. View Cart");
                Console.WriteLine("3. Checkout");
                Console.WriteLine("4. View Receipts");
                Console.WriteLine("5. Exit");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        BrowseProducts();
                        break;
                    case 2:
                        ViewCart();
                        break;
                    case 3:
                        Checkout();
                        break;
                    case 4:
                        ViewReceipts();
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        private void BrowseProducts()
        {
            Console.WriteLine("Products:");
            Console.WriteLine("1. Apple - $1");
            Console.WriteLine("2. Banana - $2");
            Console.WriteLine("3. Orange - $3");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input.");
                return;
            }

            switch (choice)
            {
                case 1:
                    AddToCart("Apple", 1);
                    break;
                case 2:
                    AddToCart("Banana", 2);
                    break;
                case 3:
                    AddToCart("Orange", 3);
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        private void AddToCart(string item, int price)
        {
            Console.Write($"Enter quantity of {item}s: ");
            int quantity;
            if (!int.TryParse(Console.ReadLine(), out quantity))
            {
                Console.WriteLine("Invalid quantity.");
                return;
            }

            _cart.AddItem(new CartItem(item, price, quantity));
            Console.WriteLine($"{quantity} {item}(s) added to cart.");
        }



        private void ViewCart()
        {
            if (_cart.IsEmpty())
            {
                Console.WriteLine("Cart is empty.");
            }
            else
            {
                Console.WriteLine("Cart:");
                Console.WriteLine(_cart.ToString());
            }
        }

        private void Checkout()
        {
            if (_cart.IsEmpty())
            {
                Console.WriteLine("Cart is empty.");
                return;
            }

            Console.WriteLine("Checking out...");

            // Create new receipt and add to list of receipts
            Receipt receipt = new Receipt(_currentUser.Username, _cart);
            _receipts.Add(receipt);

            // Print receipt
            Console.WriteLine(receipt.ToString());

            // Clear cart
            _cart.Clear();
        }

        private void ViewReceipts()
        {
            if (_receipts.Count == 0)
            {
                Console.WriteLine("No receipts found.");
            }
            else
            {
                Console.WriteLine("Receipts:");
                foreach (Receipt receipt in _receipts)
                {
                    Console.WriteLine(receipt.ToString());
                }
            }
        }
    }
}
