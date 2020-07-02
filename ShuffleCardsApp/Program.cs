using System;
using System.Collections.Generic;
using System.Linq;

namespace ShuffleCardsApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            var startingDeck = (from s in Suits()
                               from r in Ranks()
                               select new { Suit = s, Rank = r })
                               .LogQuery("Starting Deck")
                               .ToArray();

            foreach (var c in startingDeck)
            {
                Console.WriteLine(c);
            }
            //var top = startingDeck.Take(26);
            //var bottom = startingDeck.Skip(26);
            //var shuffle = top.InterleaveSequenceWith(bottom);
            //foreach (var c in shuffle)
            //{
            //    Console.WriteLine(c);
            //}

            Console.WriteLine();
            var times = 0;
            // We can re-use the shuffle variable from earlier, or you can make a new one
            var shuffle = startingDeck;

            do
            {
                // Out shuffle

                //shuffle = shuffle.Take(26)
                //.LogQuery("Top Half")
                //.InterleaveSequenceWith(shuffle.Skip(26)
                //.LogQuery("Bottom Half"))
                //.LogQuery("Shuffle")
                //.ToArray();


                // In shuffle
                shuffle = shuffle.Skip(26).LogQuery("Bottom Half")
                .InterleaveSequenceWith(shuffle.Take(26).LogQuery("Top Half"))
                .LogQuery("Shuffle")
                .ToArray();

                foreach (var c in shuffle)
                {
                    Console.WriteLine(c);
                }

                times++;
                Console.WriteLine(times);

            } while (!startingDeck.SequenceEquals(shuffle));

            Console.WriteLine(times);
        }

        static IEnumerable<string> Suits()
        {
            yield return "clubs";
            yield return "diamonds";
            yield return "hearts";
            yield return "spades";
        }
        static IEnumerable<string> Ranks()
        {
            yield return "two";
            yield return "three";
            yield return "four";
            yield return "five";
            yield return "six";
            yield return "seven";
            yield return "eight";
            yield return "nine";
            yield return "ten";
            yield return "jack";
            yield return "queen";
            yield return "king";
            yield return "ace";
        }
    }
}
