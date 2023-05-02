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

class Program
{
    static void Main(string[] args)
    {
        LinkedList linkedList = new LinkedList();

        CompanyShares companyShares1 = new CompanyShares { Name = "Vivo", NumShares = 10, SharePrice = 150 };
        CompanyShares companyShares2 = new CompanyShares { Name = "RedHat", NumShares = 30, SharePrice = 206 };
        CompanyShares companyShares3 = new CompanyShares { Name = "Gucci", NumShares = 15, SharePrice = 310 };

        linkedList.Add(companyShares1);
        linkedList.Add(companyShares2);
        linkedList.Add(companyShares3);

        linkedList.Print();

        linkedList.Remove("Gucci");

        linkedList.Print();
    }
}