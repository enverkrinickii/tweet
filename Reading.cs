using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace tweets
{
    class Reading
    {
        public List<string> ReadFromFile(string path)
        {
            StreamReader St = new StreamReader(path);

            List<string> allTweets = new List<string>();
            while (!St.EndOfStream)
            {
                allTweets.Add(St.ReadLine());
            }

            return allTweets;
        }

        public Dictionary<string, double> ReadValues(string path)
        {
            Dictionary<string, double> coast = new Dictionary<string, double>();
            StreamReader st = new StreamReader(path);
            while (!st.EndOfStream)
            {
                string str = st.ReadLine();
                string[] values = str.Split(',');
                coast.Add(values[0], Convert.ToDouble(values[1].Replace(".", ",")));
                str = string.Empty;
            }
            return coast;
        }

        public Dictionary<string, List<Poligons>> GetStates(string path)
        {
            Dictionary<string, List<Poligons>> states = new Dictionary<string, List<Poligons>>();
            StreamReader st = new StreamReader(path);
            string text = st.ReadToEnd();
            JObject root = JObject.Parse(text);
            foreach (var state in root)
            {
                List<Poligons> poligon = new List<Poligons>();
                foreach (var pol in state.Value)
                {
                    List<Points> PointsList = new List<Points>();
                    foreach (var pointArray in pol)
                    {
                        JArray point;
                        if (((JArray)state.Value).Count != 1)
                        {
                            point = (JArray)((JArray)pointArray)[0];
                        }
                        else { point = (JArray)pointArray; }
                        PointsList.Add(new Points((double)point[0], (double)point[1]));
                    }
                    poligon.Add(new Poligons(PointsList));
                }
                states.Add(state.Key, poligon);
            }

            return states;
        }

    }
}
