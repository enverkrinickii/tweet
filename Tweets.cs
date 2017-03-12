using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tweets
{
    class Tweets
    {
        public Points point;
        public string tweetText;

        public Tweets(Points point, string tweetText)
        {
            this.point = point;
            this.tweetText = tweetText;
        }

        public override string ToString()
        {
            return this.point.x.ToString() + "\t" + this.point.y.ToString() + "\t" + this.tweetText;
        }
        
    }
}
