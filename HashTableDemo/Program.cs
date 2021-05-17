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
            MyMapNode<string, string> hash = new MyMapNode<string, string>(20);
            String sentence = "Paranoids are not paranoid because they are paranoid but because they keep putting themselves deliberately into paranoid avoidable situations";
            string[] paragraphSentence = sentence.Split(' ');
            int SLength = paragraphSentence.Length;
            for (int i = 0; i < SLength; i++)
            {
                hash.Add(Convert.ToString(i), paragraphSentence[i]);
            }
            foreach (string word in paragraphSentence)
            {
                hash.GetFrequency(word);
            }
            Console.ReadLine();
        }
    }
}