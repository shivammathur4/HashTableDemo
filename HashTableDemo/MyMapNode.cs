using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableDemo
{
    class MyMapNode<K, V>
    {
        //Properties of MyMapNode
        private readonly int size;
        private readonly LinkedList<KeyValue<K, V>>[] items;
        //Constructor to initialize array of given size
        public MyMapNode(int size)
        {
            this.size = size;
            this.items = new LinkedList<KeyValue<K, V>>[size];
        }
        //To get LinkedList at the particular index
        protected LinkedList<KeyValue<K, V>> GetLinkedList(int position)
        {
            LinkedList<KeyValue<K, V>> linkedList = items[position];
            if (linkedList == null)
            {
                linkedList = new LinkedList<KeyValue<K, V>>();
                items[position] = linkedList;
            }
            return linkedList;
        }
        //To get the index value with the help of key
        protected int GetArrayPosition(K key)
        {
            int position = key.GetHashCode() % size;
            return Math.Abs(position);
        }
        //To get the value with the help of key
        public V Get(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            foreach (KeyValue<K, V> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    return item.Value;
                }
            }
            return default(V);
        }
        public void Add(K key, V value)
        {
            int position = GetArrayPosition(key);  // |-5| =5 |3|=3 |-3|=3
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            KeyValue<K, V> item = new KeyValue<K, V>() { Key = key, Value = value };
            linkedList.AddLast(item);
        }
        public void Remove(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            bool itemFound = false;
            KeyValue<K, V> foundItem = default(KeyValue<K, V>);
            foreach (KeyValue<K, V> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    itemFound = true;
                    foundItem = item;
                }
            }
            if (itemFound)
            {
                linkedList.Remove(foundItem);
            }
        }
        public int GetFrequency(V value)
        {
            int frequency = 0;
            foreach (LinkedList<KeyValue<K, V>> list in items)
            {
                if (list == null)
                    continue;
                foreach (KeyValue<K, V> obj in list)
                {
                    if (obj.Equals(null))
                        continue;
                    if (obj.Value.Equals(value))
                        frequency++;
                }
            }
            Console.WriteLine("Value: {0} \t Frequency: {1}", value, frequency);
            return frequency;
        }
        public void DisplayFrequency()
        {
            foreach (LinkedList<KeyValue<K, V>> list in items)
            {
                if (list == null)
                    continue;
                foreach (KeyValue<K, V> obj in list)
                {
                    if (obj.Equals(null))
                        continue;
                    else
                        obj.frequency = GetFrequency(obj.Value);
                }
            }
        }
        public void RemoveValue(V value)
        {
            foreach (LinkedList<KeyValue<K, V>> list in items)
            {
                if (list == null)
                    continue;
                foreach (KeyValue<K, V> obj in list)
                {
                    if (obj.Equals(null))
                        continue;
                    if (obj.Value.Equals(value))
                    {
                        Remove(obj.Key);
                        break;
                    }
                }
            }
        }
    }
    public class KeyValue<K, V>
    {
        public K Key { get; set; }
        public V Value { get; set; }
        public int frequency { get; set; }
    }
}