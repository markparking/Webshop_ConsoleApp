
using MyClassLibrary;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;

namespace WebshopConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to our shop!");

            // Create an instance of the Shop class
            var shop = new Shop();

            // Call the Login method on the shop object, passing in the user's name
            shop.Login2();

            // Call the MainMenu method on the shop object
            shop.MainMenu();

            Console.WriteLine("Thank you for shopping with us!");
        }
    }
}