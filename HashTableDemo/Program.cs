using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Welcome to HashTable!");
            MyMapNode<string, string> hash = new MyMapNode<string, string>(5);
            hash.Add("0", "To");
            hash.Add("1", "be");
            hash.Add("2", "or");
            hash.Add("3", "not");
            hash.Add("4", "To");
            hash.Add("5", "be");
            hash.GetFrequency("To");
            string hash5 = hash.Get("5");
            Console.WriteLine("5th index value: " + hash5);
            Console.ReadKey();
        }
    }
}
