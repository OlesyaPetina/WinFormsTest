using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WinFormsTest
{
    internal class Cards
    {
        public static List<string> CreateCardDeck(string name)
        {
            string[] suitCard = { "черви", "треф", "пики", "бубны" };
            string[] numberCard = { "двойка ", "тройка ", "четверка ", "пятерка ", "шестерка ", "семерка ", "восьмерка ", "девятка ", "десятка ", "валет ", "дама ", "король ", "туз " };
            List<string> cardDeck = new();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < numberCard.Length; j++)
                {
                    cardDeck.Add(numberCard[j] + suitCard[i]);
                }
            }
            string path = name + ".txt";
            File.AppendAllLines(path, cardDeck);
            return cardDeck;
        }
        public static List<string> DeckShaffing(string name)
        {
            List<string> deck = new();
            deck = ReadDeck(name);
            Random rand = new();
            for (int i = 0; i < deck.Count; i++)
            {
                int r = rand.Next(52);
                (deck[r], deck[i]) = (deck[i], deck[r]);
            }
            WriteDeck(deck, name);
            return deck;
        }

        public static void DeleteDeck(string name)
        {
            if (File.Exists(name))
                File.Delete(name);
            else
                MessageBox.Show("Данная колода отсутствует");
        }

        public static List<string> ReadDeck(string name)
        {
            List<string> cardDeck = new();
            using (StreamReader std = new(name + ".txt"))
            {
                while (!std.EndOfStream)
                {
                    cardDeck.Add(std.ReadLine());
                }
            }
            return cardDeck;
        }
        public static void WriteDeck(List<string> cardDeck, string name)
        {
            using StreamWriter str = new(name + ".txt");
            for (int i = 0; i < cardDeck.Count; i++)
                str.WriteLine(cardDeck[i]);
        }
        public static string[] GetDecks()
        {
            string[] decks;
            decks = Directory.GetFiles(@"..\net6.0-windows", "*.txt");
            for(int i = 0; i < decks.Length; i++)
            {
                decks[i] = decks[i].Substring(19, decks[i].Length - 20);
            }
            return decks;
        }

    }
}
