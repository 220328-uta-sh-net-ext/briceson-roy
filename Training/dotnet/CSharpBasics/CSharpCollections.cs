using System.Collections;
using System.Text;
using System.Collections.Generic;
namespace CSharpBasics
{
    public class CsharpCollections{
        public static void NonGenerics(){
            // ArrayList employees =new ArrayList();
            // employees.Add("Marcelle");
            // employees.Add("Fred");
            // employees.Add(123);
            // employees.Add(111.44);

            var employees = new ArrayList(){410, 912, 213, 713, 854,}; //{"Marcelle, Fred, Abacus"};
            Console.WriteLine($"Count of employees - {employees.Count}" );
            employees.Sort();
            foreach(var e in employees){
                Console.WriteLine(e + " ");
            }
            employees.Remove("Fred");
            Console.WriteLine($"Count of employees - {employees.Count}" );
        }

        public static void GenericsList(){
            List<int> scores = new List<int>(){54, 46, 65, 12, 76};
            List<object> potluck = new List<object>() {54, "upstairs", 6.7, "Horseshoes", -6, "Turtle"};
            List<string> employees = new List<string>();
            employees.Add("Marcelle");
            employees.Add("Misty");
            employees.Add("Brock");
            // employees.Add(444);
            employees.Insert(2, "Surge");

            Console.WriteLine($"Count of employees -  {employees.Count}");
            Console.WriteLine(employees[1]);
            // employees.Sort();
            employees.Reverse();
            employees.Remove("Brock"); 
            //or
            employees.RemoveAt(3);
             foreach(var e in employees){
                Console.WriteLine(e + " ");
            }
        } 

        public static void GenericsStack(){
            Stack<string> calls = new Stack<string>();
            calls.Push("588437473874");
            calls.Push("859859489848");
            calls.Push("859859489848");
            calls.Push("859859489848");
            calls.Push("859859489848");
            calls.Push("859859489848");

            calls.Pop();

            calls.Peek();
            foreach(var message in calls){
                Console.WriteLine(message);
            }
        }

        public static void GenericsDictionary(){
            Dictionary<int, string> employees = new Dictionary<int, string>();
            //you can't have two of the same key values
            employees.Add(001, "Brock");
            employees.Add(002, "Bugsy");
            employees.Add(003, "Surge");
            employees.Add(004, "Erika");
            employees.Add(005, "Janine");
            employees.Add(006, "Sabrina");


            foreach(var e in employees.Keys){
                Console.WriteLine($"{e} - {employees[e]}");
            }
        }

        public static void GenericsQueue(){
            Queue<int> orders = new Queue<int>();
            //Add new queues with the enqueue command
            orders.Enqueue(56);
            orders.Enqueue(23);
            orders.Enqueue(77);
            orders.Enqueue(49);
            orders.Enqueue(77);

            foreach (var o in orders){
                Console.WriteLine(o);
            }
            //Dequeueing Command
            Console.WriteLine("\nNow serving '{0}' ", orders.Dequeue());
            Console.WriteLine("The next number to serve is '{0}'  ", orders.Peek());
            Console.WriteLine("\nNow serving '{0}' ", orders.Dequeue());

            //creating copies of a queue
            Queue<int> orderCopy = new Queue<int>(orders.ToArray());

            Console.WriteLine("\nContents of the previous order line");
             foreach (var o in orderCopy){
                Console.WriteLine(o);
             }
        }

        public static void GenericsLinkedList(){
            //Creating the Linked List
            LinkedList<int> list =new LinkedList<int>();
            list.AddLast(24);
            list.AddLast(46);
            list.AddLast(54);
            list.AddBefore(list.First,108);
            list.Remove(list.First);
            Console.WriteLine(list.First.Value);
            Console.WriteLine(list.Last.Value);

            foreach(var l in list){
                Console.WriteLine(l);
            }
        }
    }
}