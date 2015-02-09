using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeTraversal
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static public void DepthFirst(Node node)
        {
            Console.WriteLine(node.Id);

            if (node.Children.Count == 0)
            {
                return;
            }
            else
            {
                foreach (Node child in node.Children)
                {
                    DepthFirst(child);
                }
            }
        }

        static public void BreadthFirst(Node node)
        {
            Queue queue = new Queue(100);
            queue.Push(node);
            while (queue.CanPop())
            {
                Node tempNode = queue.Pop();
                Console.WriteLine(tempNode.Id);
                foreach (Node child in tempNode.Children)
                {
                    queue.Push(child);
                }
            }
        }
    }

    class Node
    {
        List<Node> children = new List<Node>();
        Node parent;
        int id;

        public List<Node> Children
        {
            get { return children; }
            set { children = value; }
        }

        public int Id
        {
            get { return id; }
        }

        #region Constructors
        public Node()
        { }

        public Node(int Id)
        {
            this.id = Id;
        }

        public Node(int Id, List<Node> Children)
        {
            this.id = Id;
            this.Children = children;
        }

        public Node(int Id, List<Node> Children, Node Parent)
        {
            this.id = Id;
            this.parent = Parent;
            this.children = Children;
        }
        #endregion

        public override string ToString()
        {
            string output = "Parent: " + parent.id + "\nChildren: ";
            foreach (Node child in children)
            {
                output += child.id.ToString() + " ";
            }
            return output;
        }
    }

    class Queue
    {
        #region Fields

        int head = 0;                               // first element in the queue - i.e will return this element when popped off
        int tail = 0;                               // first empty slot
        int noOfElements = 0;                       // total number of elements
        Node[] queueArray = new Node[10];           // array of all queue elements - default to size 10

        #endregion

        #region Constructors

        public Queue()
        {
        }

        public Queue(int queueSize)
        {
            queueArray = new Node[queueSize];
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns the first element in the queue
        /// </summary>
        /// <returns>The first element in the queue</returns>
        public Node Pop()
        {
            Node tempObj = queueArray[head];
            queueArray[head] = null;
            if (head + 1 > queueArray.Length - 1)
            {
                head = 0;
            }
            else
            {
                head += 1;
            }
            noOfElements -= 1;
            return tempObj;
        }

        public bool CanPop()
        {
            if (queueArray[head] != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Appends an item to the end of the queue
        /// </summary>
        /// <param name="queueObject">The object to append to the queue</param>
        public void Push(Node queueObject)
        {
            if (noOfElements == queueArray.Length)
            {
                throw new QueueFullException("Queue Full");
            }
            else
            {
                queueArray[tail] = queueObject;
                if (tail + 1 > queueArray.Length - 1)
                {
                    tail = 0;
                }
                else
                {
                    tail += 1;
                }
                noOfElements += 1;
            }
        }

        #endregion

        public override string ToString()
        {
            string temp = "";
            int count = head;

            for (int i = 0; i <= queueArray.Length - 1; i++)
            {
                temp += ("[" + count + ": " + queueArray[count] + "]");
                if (count + 1 > queueArray.Length - 1)
                {
                    count = 0;
                }
                else
                {
                    count += 1;
                }
            }
            return temp;
        }
    }

    class QueueFullException : Exception
    {
        public QueueFullException(string message)
            : base(message)
        {

        }
    }
}
