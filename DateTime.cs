using System;

class CompanyShares
{
    public string Name { get; set; }
    public int NumShares { get; set; }
    public double SharePrice { get; set; }
    public CompanyShares Next { get; set; }

    public double GetValue()
    {
        return NumShares * SharePrice;
    }
}

class LinkedList
{
    private CompanyShares head;

    public void Add(CompanyShares companyShares)
    {
        if (head == null)
        {
            head = companyShares;
        }
        else
        {
            CompanyShares current = head;

            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = companyShares;
        }
    }

    public void Remove(string name)
    {
        if (head == null)
        {
            return;
        }

        if (head.Name == name)
        {
            head = head.Next;
            return;
        }

        CompanyShares current = head;

        while (current.Next != null)
        {
            if (current.Next.Name == name)
            {
                current.Next = current.Next.Next;
                return;
            }

            current = current.Next;
        }
    }

    public void Print()
    {
        Console.WriteLine("\nCompany Shares List\n");

        CompanyShares current = head;

        while (current != null)
        {
            double value = current.GetValue();

            Console.WriteLine("{0}: {1} shares at {2:C} each = {3:C}", current.Name, current.NumShares, current.SharePrice, value);

            current = current.Next;
        }
    }
}

class Stack
{
    private class Node
    {
        public string Symbol { get; set; }
        public Node Next { get; set; }
    }

    private Node top;

    public void Push(string symbol)
    {
        Node node = new Node { Symbol = symbol, Next = top };
        top = node;
    }

    public string Pop()
    {
        if (top == null)
        {
            return null;
        }

        string symbol = top.Symbol;
        top = top.Next;

        return symbol;
    }

    public void Print()
    {
        Console.WriteLine("\nTransaction History\n");

        Node current = top;

        while (current != null)
        {
            Console.WriteLine(current.Symbol);

            current = current.Next;
        }
    }
}

class Queue
{
    private class Node
    {
        public DateTime DateTime { get; set; }
        public Node Next { get; set; }
    }

    private Node front;
    private Node rear;

    public void Enqueue(DateTime dateTime)
    {
        Node node = new Node { DateTime = dateTime, Next = null };

        if (rear == null)
        {
            front = node;
            rear = node;
        }
        else
        {
            rear.Next = node;
            rear = node;
        }
    }

    public DateTime Dequeue()
    {
        if (front == null)
        {
            return DateTime.MinValue;
        }

        DateTime dateTime = front.DateTime;
        front = front.Next;

        if (front == null)
        {
            rear = null;
        }

        return dateTime;
    }

    public void Print()
    {
        Console.WriteLine("\nTransaction Dates\n");

        Node current = front;

        while (current != null)
        {
            Console.WriteLine(current.DateTime);

            current = current.Next;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        LinkedList linkedList = new LinkedList();
        Stack stack = new Stack();
        Queue queue = new Queue();

        CompanyShares companyShares1 = new CompanyShares { Name = "Vivo", NumShares = 10, SharePrice = 150 };
        CompanyShares companyShares2 = new CompanyShares { Name = "RedHat", NumShares = 30, SharePrice = 206 };
        CompanyShares companyShares3 = new CompanyShares { Name = "Gucci", NumShares = 15, SharePrice = 310 };

        linkedList.Add(companyShares1);
        linkedList.Add(companyShares2);
        linkedList.Add(companyShares3);


        linkedList.Print();

        stack.Push("VIV");
        stack.Push("RH");
        stack.Push("GUC");

        stack.Print();

        queue.Enqueue(DateTime.Now);
        queue.Enqueue(DateTime.Now.AddDays(-1));
        queue.Enqueue(DateTime.Now.AddDays(-2));

        queue.Print();

        queue.Dequeue();

        queue.Print();
    }
}
