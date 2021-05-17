using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableDemo
{
    public class MyMapNode<K, V>
    {
        
        public readonly int size;
        public readonly LinkedList<keyValue<K, V>>[] items;

        public MyMapNode(int size)
        {
            this.size = size;
            this.items = new LinkedList<keyValue<K, V>>[size];
        }

        public struct keyValue<k, v>
        {
            public k key { get; set; }
            public v value { get; set; }
            public int Frequency { get; set; }
        }

        protected LinkedList<keyValue<K, V>> GetLinkedlist(int position)
        {
            
            LinkedList<keyValue<K, V>> linkedlist = items[position];
            if (linkedlist == null)
            {
                linkedlist = new LinkedList<keyValue<K, V>>();
                items[position] = linkedlist;
            }
            return linkedlist;
        }

        
        protected int GetArrayPosition(K key)
        {
            
            int position = key.GetHashCode() % size;
            return Math.Abs(position);
        }

        
        public V Get(K key)
        {
            int position = GetArrayPosition(key);

            LinkedList<keyValue<K, V>> linkedlist = GetLinkedlist(position);
            foreach (keyValue<K, V> item in linkedlist)
            {
                if (item.key.Equals(key))
                {
                    return item.value;
                }
            }
            return default;
        }

       
        public void Add(K key, V value)
        {
            int position = GetArrayPosition(key);
            LinkedList<keyValue<K, V>> linkedlist = GetLinkedlist(position);
            keyValue<K, V> item = new keyValue<K, V>() { key = key, value = value };
            linkedlist.AddLast(item);
            Console.WriteLine(item.value + " :- is Added at Index : " + item.key);
        }

        public void Remove(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<keyValue<K, V>> linkedlist = GetLinkedlist(position);

            bool itemFound = false;

            keyValue<K, V> foundItem = default(keyValue<K, V>);
            foreach (keyValue<K, V> item in linkedlist)
            {
                if (item.key.Equals(key))
                {
                    itemFound = true;
                    foundItem = item;
                }
            }
            if (itemFound)
            {
                linkedlist.Remove(foundItem);
            }
        }

        
        public int GetFrequency(V value)
        {
            int frequency = 0;
            foreach (LinkedList<keyValue<K, V>> list in items)
            {
                if (list == null)
                {
                    continue;
                }
                foreach (keyValue<K, V> obj in list)
                {
                    if (obj.Equals(null))
                    {
                        continue;
                    }
                    if (obj.value.Equals(value))
                    {
                        frequency++;
                    }
                }
            }
            Console.WriteLine(" ");
            Console.WriteLine("Word '{0}' appears {1} times", value, frequency);
            return frequency;
        }
    }
}