using System;

class Stock
{
    public string Name { get; set; }
    public int NumShares { get; set; }
    public double SharePrice { get; set; }

    public double GetValue()
    {
        return NumShares * SharePrice;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter the number of stocks: ");
        int n = int.Parse(Console.ReadLine());

        Stock[] stocks = new Stock[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter the name of stock {0}: ", i + 1);
            string name = Console.ReadLine();

            Console.Write("Enter the number of shares of stock {0}: ", i + 1);
            int numShares = int.Parse(Console.ReadLine());

            Console.Write("Enter the share price of stock {0}: ", i + 1);
            double sharePrice = double.Parse(Console.ReadLine());

            stocks[i] = new Stock { Name = name, NumShares = numShares, SharePrice = sharePrice };
        }

        Console.WriteLine("\nStock Report\n");

        double totalValue = 0;

        foreach (Stock stock in stocks)
        {
            double value = stock.GetValue();
            totalValue += value;

            Console.WriteLine("{0}: {1} shares at {2:C} each = {3:C}", stock.Name, stock.NumShares, stock.SharePrice, value);
        }

        Console.WriteLine("\nTotal value of all stocks: {0:C}", totalValue);
    }
}
