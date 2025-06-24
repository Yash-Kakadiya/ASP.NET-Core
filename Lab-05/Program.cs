using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lab05
{
    class Program
    {
        static void printHashTable(Hashtable hashtable)
        {
            foreach (dynamic entry in hashtable)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }
        }

        static void printDictionary(Dictionary<int, string> dictionary)
        {
            foreach (var kv in dictionary)
            {
                Console.WriteLine($"{kv.Key}: {kv.Value}");
            }
        }

        static void Main(string[] args)
        {
            /*1. Create an ArrayList for StudentName and perform following operations: 
                a.Add() - To Add new student in list
                b.Remove() - To Remove Student with specified index
                c.RemoveRange() - To Remove student with specified range.
                d.Clear() - To clear all the student from the list
            */
            ArrayList StudentNames = new ArrayList();

            StudentNames.Add("Yash");
            StudentNames.Add("Dhaval");
            StudentNames.Add("Jevin");
            StudentNames.Add("Mihir");
            StudentNames.Add("Thirth");
            StudentNames.Add("Niv");
            Console.WriteLine("Students after adding: " + string.Join(", ", StudentNames.ToArray()));

            StudentNames.RemoveAt(2);
            Console.WriteLine("Students after removing index 1: " + string.Join(", ", StudentNames.ToArray()));

            StudentNames.RemoveRange(2, 2);
            Console.WriteLine("Students after removing range(0,2): " + string.Join(", ", StudentNames.ToArray()));

            StudentNames.Clear();
            Console.WriteLine("Students after clearing: " + string.Join(", ", StudentNames.ToArray()));



            /*2. Create a List for StudentName and perform following operations: 
                a.Add() - To Add new student in list
                b.Remove() - To Remove Student with specified index
                c.RemoveRange() - To Remove student with specified range.
                d.Clear() - To clear all the student from the list
            */
            List<string> studentList = new List<string>();
            studentList.Add("Yash");
            studentList.Add("Dhaval");
            studentList.Add("Mihir");
            studentList.Add("Jevin");
            Console.WriteLine("Students after adding: " + string.Join(", ", studentList));

            studentList.RemoveAt(0);
            Console.WriteLine("Students after removing index 0: " + string.Join(", ", studentList));

            studentList.RemoveRange(0, 1);
            Console.WriteLine("Students after removing range: " + string.Join(", ", studentList));

            studentList.Clear();
            Console.WriteLine("Students after clearing: " + string.Join(", ", studentList));

            /*3. Create a Stack which takes integer values and perform following operations: 
                a. Push() - To Add new item in stack 
                b. Pop() - To Remove item from the stack 
                c. Peek() – To Return the top item from the stack. 
                d. Contains() - To Checks whether an item exists in the stack or not. 
                e. Clear() - To clear items from stack
            */
            Stack<int> stack = new Stack<int>();
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);
            Console.WriteLine("Stack after pushing: " + string.Join(", ", stack));

            stack.Pop();
            Console.WriteLine("Stack after popping: " + string.Join(", ", stack));

            Console.WriteLine("Top item in stack: " + stack.Peek());

            Console.WriteLine("Does stack contain 20? =>" + stack.Contains(20));

            stack.Clear();
            Console.WriteLine("Stack after clearing: " + string.Join(", ", stack));


            /*4. Create a Queue which takes integer values and perform following operations: 
                a.Enqueue() - To Add new item in queue 
                b.Dequeue() - To Remove item from the queue 
                c.Peek() – To Return the front item from the queue. 
                d.Contains() - To Checks whether an item exists in the queue or not. 
                e.Clear() - To clear items from queue
            */
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);
            Console.WriteLine("Queue after enqueueing: " + string.Join(", ", queue));

            queue.Dequeue();
            Console.WriteLine("Queue after dequeueing: " + string.Join(", ", queue));

            Console.WriteLine("Front item in queue: " + queue.Peek());

            Console.WriteLine("Does queue contain 20? " + queue.Contains(20));

            queue.Clear();
            Console.WriteLine("Queue after clearing: " + string.Join(", ", queue));
            /*5. Create a Dictionary collection class object and preform following operations:
                a. Add: Adds a key-value pair.
                b. Remove: Removes a key-value pair by key.
                c. ContainsKey: Checks if a key exists in the hashtable.
                d. ContainsValue: Checks if a value exists in the hashtable.
                e. Clear: Removes all key-value pairs.*/

            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            dictionary.Add(1, "Jevin");
            dictionary.Add(2, "Dhaval");
            dictionary.Add(3, "Yash");
            Console.WriteLine("Dictionary after adding:");
            printDictionary(dictionary);
            dictionary.Remove(2);
            Console.WriteLine("\nDictionary after removing key 2:");
            printDictionary(dictionary);
            Console.WriteLine("\nDoes dictionary contain key 1? " + dictionary.ContainsKey(1));
            Console.WriteLine("Does dictionary contain value 'Yash'? " + dictionary.ContainsValue("Yash"));
            dictionary.Clear();
            Console.WriteLine("\nDictionary after clearing:");
            printDictionary(dictionary);

            /*6. Create a Hashtable collection class object and preform following operations:
                a. Add: Adds a key-value pair.
                b. Remove: Removes a key-value pair by key.
                c. ContainsKey: Checks if a key exists in the hashtable.
                d. ContainsValue: Checks if a value exists in the hashtable.
                e. Clear: Removes all key-value pairs.*/
            Hashtable hashtable = new Hashtable();
            hashtable.Add("Name", "Yash");
            hashtable.Add("Age", 20);
            hashtable.Add("City", "Rajkot");
            Console.WriteLine("Hashtable after adding:");
            printHashTable(hashtable);
            hashtable.Remove("Age");
            Console.WriteLine("\nHashtable after removing key 'Age':");
            printHashTable(hashtable);
            Console.WriteLine("\nDoes hashtable contain key 'Name'? " + hashtable.ContainsKey("Name"));
            Console.WriteLine("Does hashtable contain value 'Ahmedabad'? " + hashtable.ContainsValue("Ahmedabad"));
            hashtable.Clear();
            Console.WriteLine("\nHashtable after clearing:");
            printHashTable(hashtable);

        }
    }
}
