using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DekstraAlgorythm
{
    
    class Program
    {
        static void Main()
        {
            Point pointA = new Point(0, false, "A");
            Point pointB = new Point(9999, false, "B");
            Point pointC = new Point(9999, false, "C");
            Point pointD = new Point(9999, false, "D");
            Point pointE = new Point(9999, false, "E");
            Point pointF = new Point(9999, false, "F");
            List<Point> points = new List<Point>
            {
                pointA,
                pointB,
                pointC,
                pointD,
                pointE,
                pointF
            };

            List<Rebro> rebra = new List<Rebro>
            {
                new Rebro(pointA, pointB, 3),
                new Rebro(pointA, pointC, 5),
                new Rebro(pointA, pointD, 9),
                new Rebro(pointB, pointC, 3),
                new Rebro(pointB, pointE, 7),
                new Rebro(pointB, pointD, 4),
                new Rebro(pointC, pointD, 2),
                new Rebro(pointC, pointE, 6),
                new Rebro(pointC, pointF, 8),
                new Rebro(pointD, pointF, 2),
                new Rebro(pointD, pointE, 2),
                new Rebro(pointE, pointF, 5)
            };

            DekstraAlg alg = new DekstraAlg(points.ToArray(), rebra.ToArray());
            alg.AlgorythmRun(pointA);

            List<string> result = PrintGraph.PrintAllPoints(alg);
            for(int i=0; i < result.Count(); i++)
            {
                Console.WriteLine(result[i].ToString());
            }

            Console.WriteLine("\nКратчайшие пути:");
            List<string> resultPaths = PrintGraph.PrintAllMinPaths(alg);
            for (int i = 0; i < resultPaths.Count(); i++)
            {
                Console.WriteLine(resultPaths[i].ToString());
            }
            Console.Read();
        }
    }
}
