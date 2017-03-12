using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tweets
{
    class States
    {
        Dictionary<string, List<Poligons>> states;
        

        public States(Dictionary<string, List<Poligons>> states)
        {
            this.states = states;
        }


        public static bool IsPointInPolygon4(List<Poligons> ListOfPolygon, Points point)
        {
            foreach (var polygon in ListOfPolygon)
            {
                bool result = false;
                int j = polygon.ListOfPoints.Count() - 1;
                for (int i = 0; i < polygon.ListOfPoints.Count(); i++)
                {

                    if (polygon.ListOfPoints[i].y < point.y && polygon.ListOfPoints[j].y >= point.y || polygon.ListOfPoints[j].y < point.y && polygon.ListOfPoints[i].y >= point.y)
                    {
                        if (polygon.ListOfPoints[i].x + (point.y - polygon.ListOfPoints[i].y) / (polygon.ListOfPoints[j].y - polygon.ListOfPoints[i].y) * (polygon.ListOfPoints[j].x - polygon.ListOfPoints[i].x) < point.x)
                        {
                            result = !result;
                        }
                    }
                    j = i;

                }
                if(result)
                    return result;
            }
            return false;
            
        }
    }
}
