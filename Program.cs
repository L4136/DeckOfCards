using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeckOfCards
{
    class Program
    {
        public class Card
        {
            private string face;
            private string suit;

            public Card(string cardFace, string cardSuit)
            {
                face = cardFace;
                suit = cardSuit;
            }
            public override string ToString()
            {
                return face + " of " + suit;
            }
        }

        public class Deck
        {
            private Card[] deck;
            private int currentCard;
            private const int NUM_OF_CARDS = 52;
            private Random rnd;

            public Deck()
            {
                string[] faces = { "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };
                string[] suits = {"Hearts", "Clubs", "Diamonds", "Spades"};
                deck = new Card[NUM_OF_CARDS];
                currentCard = 0;
                rnd = new Random();
                for (int count = 0; count < deck.Length; count++)
                    deck[count] = new Card(faces[count % 13], suits[count / 13]);
            }

            public void Shuffle()
            {
                currentCard = 0;
                for (int first = 0; first < deck.Length; first++)
                {
                    int second = rnd.Next( NUM_OF_CARDS);
                    Card temp = deck[first];
                    deck[first] = deck[second];
                    deck[second] = temp;
                }
                
            }
            public Card DealCard()
            {
                
                if (currentCard < deck.Length)
                {
                    return deck[currentCard++];
                }

                else
                    return null;
            }
           
        }


        static void Main(string[] args)
        {
            Deck deck1 = new Deck();
            int j = 1;
            for (int i = 0; i<52; i++)
            {

                Console.WriteLine(j + ". card is {0}", deck1.DealCard()); j++;
            }
            Console.WriteLine("\nYour deck has been shuffled. \n");
            deck1.Shuffle();
            int k = 1;
            for (int i = 0; i < 52; i++)
            {
                
                Console.WriteLine(k + ". card is {0}", deck1.DealCard()); k++;
            }

        }
    }
}
