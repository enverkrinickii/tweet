using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tweets
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "sandwich.txt";
            string path1 = "sentiments.csv";
            string path2 = "states.json";
            Reading read = new Reading();
            List<string> allTweets = new List<string>();
            allTweets = read.ReadFromFile(path);
            Dictionary<string, double> coast = new Dictionary<string, double>();
            coast = read.ReadValues(path1);
            //foreach (var lines in coast)
            //{
            //    Console.WriteLine(lines);
            //}

            Parsing pars = new Parsing();

            List<Tweets> readyTweets = new List<Tweets>();
            readyTweets = pars.TweetParse(allTweets);
            //foreach (Tweets tw in readyTweets)
            //{
            //    Console.WriteLine(tw);
            //}

            //foreach (string line in allTweets)
            //{
            //    Console.WriteLine(line);
            //}
            Dictionary<string, List<Poligons>> states = new Dictionary<string, List<Poligons>>();
            states = read.GetStates(path2);
            //foreach (var stateName in states.Keys)
            //{
            //    Console.WriteLine(stateName);
            //    foreach (var poligon in states[stateName])
            //    {
            //        foreach (var point in poligon.ListOfPoints)
            //            Console.WriteLine(point.x + " " + point.y);
            //    }
            //}     
            Results res = new Results();
            List<Results> ListOfStateTweets = res.BelongsToState(readyTweets, states);
            //foreach (var line in ListOfStateTweets)
            //{
            //    Console.WriteLine(line.StateName);
            //    foreach (var tweet in line.ListOFStateTweets)
            //        Console.WriteLine(tweet);
            //}

            Dictionary<string, double> endResult = res.EndResult(coast, ListOfStateTweets);
            foreach (var line in endResult)
            {
                Console.WriteLine(line);
            }
            Console.ReadKey();
        }
    }
}
