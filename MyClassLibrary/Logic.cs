using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLibrary
{
    public static class Logic
    {
        // Add a new static field to hold a dictionary of receipts, keyed by user name
        private static Dictionary<string, List<string>> receipts = new Dictionary<string, List<string>>();

        // Add a new static method to add a receipt for a given user
        public static void AddReceipt(string username, List<string> items)
        {
            if (receipts.ContainsKey(username))
            {
                receipts[username].AddRange(items);
            }
            else
            {
                receipts[username] = new List<string>(items);
            }
        }

        // Add a new static method to retrieve all receipts for a given user
        public static List<string> GetReceipts(string username)
        {
            if (receipts.ContainsKey(username))
            {
                return receipts[username];
            }
            else
            {
                return new List<string>();
            }
        }
    }
}

