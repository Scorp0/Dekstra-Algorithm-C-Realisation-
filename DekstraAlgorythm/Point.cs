using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DekstraAlgorythm
{
    /// <summary>
    /// Класс, реализующий вершину графа
    /// </summary>
    class Point
    {
        public float ValueMetka { get; set; }
        public string Name { get; set; }
        public bool IsChecked { get; set; }
        public Point PredPoint { get; set; }

        public Point (int value, bool ischecked) 
        {
            ValueMetka = value;
            IsChecked = ischecked;
            PredPoint = new Point();
        }
        public Point (int value, bool ischecked, string name)
        {
            ValueMetka = value;
            IsChecked = ischecked;
            Name = name;
            PredPoint = new Point();
        }
        public Point() { }
    }
}
