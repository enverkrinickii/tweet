using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tweets
{
    class Parsing
    {


        public List<Tweets> TweetParse(List<string> allTweets)
        {
            List<Tweets> readyTweets = new List<Tweets>();
            foreach (string line in allTweets)
            {
                string[] temp = line.Split('\t');
                char[] separator = {'[' , ',', ']'};
                string[] coord = temp[0].Split(separator);
                Tweets tweet = new Tweets(new Points(Convert.ToDouble(coord[2].Replace(".", ",")), Convert.ToDouble(coord[1].Replace(".", ","))), temp[3]);
                readyTweets.Add(tweet);
            }

            return readyTweets;
        }
        
    }
}
