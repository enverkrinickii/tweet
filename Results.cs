using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tweets
{
    class Results
    {
        public string StateName;
        public List<string> ListOFStateTweets = new List<string>();
        double result;

        public Results(string StateName, List<string> ListOFStateTweets)
        {
            this.StateName = StateName;
            this.ListOFStateTweets = ListOFStateTweets;
        
        }

        public Results()
        { }

        public List<Results> BelongsToState(List<Tweets> allTweets, Dictionary<string, List<Poligons>> dataAboutStates)
        {
            List<Results> StateTweets = new List<Results>();
            States state = new States(dataAboutStates);
            
            foreach (var stateName in dataAboutStates.Keys)
            {
                List<string> StateTweetText = new List<string>();
                foreach (var Tweet in allTweets)
                {
                    if (States.IsPointInPolygon4(dataAboutStates[stateName], Tweet.point))
                        StateTweetText.Add(Tweet.tweetText);
                        //StateTweets.Add(new States(stateName, Tweet.tweetText));
                }
                StateTweets.Add(new Results(stateName, StateTweetText));
            }
            
            return StateTweets;
        }

        public Dictionary<string, double> EndResult(Dictionary<string, double> coast, List<Results> StateTweets)
        {
            Dictionary<string, double> endResultes = new Dictionary<string, double>();
            foreach (var line in StateTweets)
            {
                double sum = 0;
                foreach (var tweet in line.ListOFStateTweets)
                {
                    double sum1 = 0;
                    char[] separator = { '[', ',', ']', '.', '!', '#' , '?', ':', '{' , '}', '(', ')', ';', '-', '*', '+', '&', '/', '\\', '"', '@', '$'};
                    //tweet.Trim(separator);
                    string[] words = tweet.Split(separator);
                    int count = 0;
                    foreach (var word in words)
                    {
                        if (coast.ContainsKey(word))
                        {
                            count++;
                            sum1 += coast[word];
                        }
                        
                    }
                    if (count != 0)
                    {
                        sum1 /= count;
                        sum += sum1;
                    }
                }
                if (line.ListOFStateTweets.Count != 0)
                {
                    endResultes.Add(line.StateName, sum / line.ListOFStateTweets.Count);
                }
                else { endResultes.Add(line.StateName, 0); }

            }

            return endResultes;
        }
    }
}
