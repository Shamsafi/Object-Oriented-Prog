using System;

public class DeckOfCards
{
    static void Main(string[] args)
    {
        string[] suits = { "Clubs", "Diamonds", "Hearts", "Spades" };
        string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
        string[] deck = new string[52];

        for (int i = 0; i < ranks.Length; i++)
        {
            for (int j = 0; j < suits.Length; j++)
            {
                deck[suits.Length * i + j] = ranks[i] + " of " + suits[j];
            }
        }

        Random rand = new Random();
        for (int i = 0; i < deck.Length; i++)
        {
            int r = rand.Next(i, deck.Length);
            string temp = deck[r];
            deck[r] = deck[i];
            deck[i] = temp;
        }

        string[,] players = new string[4, 9];
        int index = 0;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                players[i, j] = deck[index];
                index++;
            }
        }

        for (int i = 0; i < 4; i++)
        {
            Console.Write("Player " + (i + 1) + ": ");
            for (int j = 0; j < 9; j++)
            {
                Console.Write(players[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}
