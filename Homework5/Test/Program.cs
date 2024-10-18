using Cspro.Collection;
using System.Collections.Generic;

namespace Homework5
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            TestList();
            Console.WriteLine();

            TestBinaryTree();
            Console.WriteLine();

            TestLinkedList();
            Console.WriteLine();

            TestDoublyLinkedList();
            Console.WriteLine();

            TestQueue();
            Console.WriteLine();

            TestStack();
            Console.WriteLine();
        }

        static void TestList()
        {
            var list = new List();

            Console.WriteLine("TestList Add(1)");
            list.Add(1);
            Console.WriteLine("TestList Add(2)");
            list.Add(2);
            Console.WriteLine("TestList Add(3)");
            list.Add(3);
            Console.WriteLine("TestList Add(4)");
            list.Add(4);
            Console.WriteLine("TestList Add(5)");
            list.Add(5);
            Console.WriteLine("TestList Insert(3, 3.5)");
            list.Insert(3, 3.5);
            Console.WriteLine("TestList Insert(4, 4.5)");
            list.Insert(4, 4.5);
            Console.WriteLine("TestList Remove(3.5)");
            list.Remove(3.5);
            Console.WriteLine("TestList RemoveAt(2)");
            list.RemoveAt(2);
            Console.WriteLine("TestList Reverse");
            list.Reverse();

            Console.WriteLine("TestList ToArray:");

            foreach (var item in list.ToArray())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("TestList Clear");
            list.Clear();
        }

        static void TestBinaryTree()
        {
            var btree = new BinaryTree();

            Console.WriteLine("TestBinaryTree Add(9)");
            btree.Add(9);
            Console.WriteLine("TestBinaryTree Add(8)");
            btree.Add(8);
            Console.WriteLine("TestBinaryTree Add(7)");
            btree.Add(7);
            Console.WriteLine("TestBinaryTree Add(2)");
            btree.Add(2);
            Console.WriteLine("TestBinaryTree Add(4)");
            btree.Add(4);
            Console.WriteLine("TestBinaryTree Add(5)");
            btree.Add(5);
            Console.WriteLine("TestBinaryTree Add(1)");
            btree.Add(1);

            Console.WriteLine("TestBinaryTree Contains 8: " + btree.Contains(8));
            Console.WriteLine("TestBinaryTree Contains 0: " + btree.Contains(0));

            Console.WriteLine("TestBinaryTree ToArray:");
            foreach (var item in btree.ToArray())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("TestBinaryTree Clear");
            btree.Clear();
        }

        static void TestQueue()
        {
            var que = new Queue();

            Console.WriteLine("TestQueue Enqueue(10)");
            que.Enqueue(10);

            Console.WriteLine("TestQueue Peek: " + que.Peek());

            Console.WriteLine("TestQueue Dequeue(10): " + que.Dequeue());

            Console.WriteLine("TestQueue Count: " + que.Count);

            Console.WriteLine("TestQueue ToArray:");
            foreach (var item in que.ToArray())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("TestQueue Clear");
            que.Clear();
        }

        static void TestStack()
        {
            var stack = new Stack();

            Console.WriteLine("TestStack Push(1)");
            stack.Push(1);
            Console.WriteLine("TestStack Push(2)");
            stack.Push(2);
            Console.WriteLine("TestStack Push(3)");
            stack.Push(3);

            Console.WriteLine("TestStack Peek: " + stack.Peek());
            Console.WriteLine("TestStack Pop: " + stack.Pop());

            Console.WriteLine("Stack ToArray:");
            foreach (var item in stack.ToArray())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("TestStack Clear");
            stack.Clear();
        }

        static void TestLinkedList()
        {
            var linklist = new LinkedList();

            Console.WriteLine("TestLinkedList Add(\"One\")");
            linklist.Add("One");
            Console.WriteLine("TestLinkedList Add(\"Two\")");
            linklist.Add("Two");
            Console.WriteLine("TestLinkedList Add(\"Three\")");
            linklist.Add("Three");
            Console.WriteLine("TestLinkedList Add(\"Four\")");
            linklist.Add("Four");

            Console.WriteLine("TestLinkedList Add(\"Last\")");
            linklist.AddLast("Last");

            Console.WriteLine("TestLinkedList Add(\"First\")");
            linklist.AddFirst("First");

            Console.WriteLine("TestLinkedList ToArray:");
            foreach (var item in linklist.ToArray())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("TestLinkedList Clear");
            linklist.Clear();
        }

        static void TestDoublyLinkedList()
        { 
            var dlist = new DoublyLinkedList();

            Console.WriteLine("TestDoublyLinkedList Add(\"One\")");
            dlist.Add("One");
            Console.WriteLine("TestDoublyLinkedList Add(\"Two\")");
            dlist.Add("Two");
            Console.WriteLine("TestDoublyLinkedList Add(\"Three\")");
            dlist.Add("Three");
            Console.WriteLine("TestDoublyLinkedList Add(\"Four\")");
            dlist.Add("Four");

            Console.WriteLine("TestDoublyLinkedList ToArray:");
            foreach (var item in dlist.ToArray())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("TestDoublyLinkedList Clear");
            dlist.Clear();
        }
    }
}