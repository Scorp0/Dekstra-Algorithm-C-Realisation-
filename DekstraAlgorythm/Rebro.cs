using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DekstraAlgorythm
{
    /// <summary>
    /// Класс, реализующий ребро
    /// </summary>
    class Rebro
    {
        public Point FirstPoint { get; set; }
        public Point SecondPoint { get; set; }
        public float Weight { get; set; }
        public Rebro(Point first, Point second, float valueOfWeight)
        {
            FirstPoint = first;
            SecondPoint = second;
            Weight = valueOfWeight;
        }
    }
}
