using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DekstraAlgorythm
{
    // <summary>
    /// для печати графа
    /// </summary>
    static class PrintGraph
    {
        public static List<string> PrintAllPoints (DekstraAlg da)
        {
            List<string> retListOfPoints = new List<string>();
            float lastPath = 0;
            foreach(Point p in da.Points)
            {
                retListOfPoints.Add(string.Format("название точки={0}, значение точки={1}, предок={2}", p.Name, p.ValueMetka, p.PredPoint.Name ?? "нет предка"));
                lastPath = p.ValueMetka;
            }
            //string last = retListOfPoints.Last();
            //last += string.Format("\n\nЗначение кратчайшего маршрута данного графа: {0}", lastPath);
            //retListOfPoints.Remove(retListOfPoints.Last());
            //retListOfPoints.Add(last);
            return retListOfPoints;
        }
        public static List<string> PrintAllMinPaths (DekstraAlg da)
        {
            List<string> retListOfPontsAndPaths = new List<string>();
            foreach(Point p in da.Points)
            {
                if (p != da.BeginPoint)
                {
                    string s = string.Empty;
                    float n = 0;
                    foreach (Point p1 in da.MinPath(p))
                    {
                        s += string.Format("{0}-", p1.Name);
                    }
                    n += p.ValueMetka;
                    string[] result = s.Split('-');
                    Array.Reverse(result);
                    string res = "A";
                    for(int i=0; i < result.Count(); i++)
                    {
                        res += result[i].ToString();
                    }
                    retListOfPontsAndPaths.Add(string.Format("Точка = {0}, кратчайший путь от {1} : {2}, значение маршрута: {3}", p.Name, da.BeginPoint.Name, res, n));
                }
            }
            return retListOfPontsAndPaths;
        }
    }
}
