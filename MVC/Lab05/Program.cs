using System.Collections;

namespace Lab05
{
    class Program
    {


        static void PrintArrayList(ArrayList arrayList)
        {
            foreach (var item in arrayList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("---------------------------------------");
        }
        static void PrintList(List<string> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("---------------------------------------");
        }

        static void PrintStack(Stack<int> stack)
        {
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("---------------------------------------");
        }
        static void PrintQueue(Queue<int> queue)
        {
            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("---------------------------------------");
        }

        static void PrintDictionary(Dictionary<int, string> dictionary)
        {
            foreach (var kv in dictionary)
            {
                Console.WriteLine($"{kv.Key}: {kv.Value}");
            }
            Console.WriteLine("---------------------------------------");
        }

        static void PrintHashTable(Hashtable hashtable)
        {
            foreach (dynamic entry in hashtable)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }
            Console.WriteLine("---------------------------------------");
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
            Console.WriteLine("Students after adding: ");
            PrintArrayList(StudentNames);

            StudentNames.RemoveAt(2);
            Console.WriteLine("Students after removing index 1: ");
            PrintArrayList(StudentNames);

            StudentNames.RemoveRange(2, 2);
            Console.WriteLine("Students after removing range(0,2): ");
            PrintArrayList(StudentNames);

            StudentNames.Clear();
            Console.WriteLine("Students after clearing: ");
            PrintArrayList(StudentNames);



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
            Console.WriteLine("Students after adding: ");
            PrintList(studentList);


            studentList.RemoveAt(0);
            Console.WriteLine("Students after removing index 0: ");
            PrintList(studentList);

            studentList.RemoveRange(0, 1);
            Console.WriteLine("Students after removing range: ");
            PrintList(studentList);

            studentList.Clear();
            Console.WriteLine("Students after clearing: ");
            PrintList(studentList);

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
            Console.WriteLine("Stack after pushing: ");
            PrintStack(stack);

            stack.Pop();
            Console.WriteLine("Stack after popping: ");

            Console.WriteLine("Top item in stack: " + stack.Peek());

            Console.WriteLine("Does stack contain 20? =>" + stack.Contains(20));

            stack.Clear();
            Console.WriteLine("Stack after clearing: ");
            PrintStack(stack);


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
            Console.WriteLine("Queue after enqueueing: ");
            PrintQueue(queue);

            queue.Dequeue();
            Console.WriteLine("Queue after dequeueing: ");
            PrintQueue(queue);

            Console.WriteLine("Front item in queue: " + queue.Peek());

            Console.WriteLine("Does queue contain 20? " + queue.Contains(20));

            queue.Clear();
            Console.WriteLine("Queue after clearing: ");
            PrintQueue(queue);

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
            PrintDictionary(dictionary);

            dictionary.Remove(2);
            Console.WriteLine("\nDictionary after removing key 2:");
            PrintDictionary(dictionary);

            Console.WriteLine("\nDoes dictionary contain key 1? " + dictionary.ContainsKey(1));
            Console.WriteLine("Does dictionary contain value 'Yash'? " + dictionary.ContainsValue("Yash"));

            dictionary.Clear();
            Console.WriteLine("\nDictionary after clearing:");
            PrintDictionary(dictionary);

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
            PrintHashTable(hashtable);

            hashtable.Remove("Age");
            Console.WriteLine("\nHashtable after removing key 'Age':");
            PrintHashTable(hashtable);

            Console.WriteLine("\nDoes hashtable contain key 'Name'? " + hashtable.ContainsKey("Name"));
            Console.WriteLine("Does hashtable contain value 'Ahmedabad'? " + hashtable.ContainsValue("Ahmedabad"));

            hashtable.Clear();
            Console.WriteLine("\nHashtable after clearing:");
            PrintHashTable(hashtable);

        }
    }
}
