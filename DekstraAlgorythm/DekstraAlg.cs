using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DekstraAlgorythm
{
    // <summary>
    /// Реализация алгоритма Дейкстры. Содержит матрицу смежности в виде массивов вершин и ребер
    /// </summary>
    class DekstraAlg
    {
        public Point[] Points { get; private set; }
        public Rebro[] Rebra { get; private set; }
        public Point BeginPoint { get; private set; }
        public DekstraAlg(Point[] pointsOfGraph, Rebro[] rebraOfGraph)
        {
            Points = pointsOfGraph;
            Rebra = rebraOfGraph;
        }
        /// <summary>
        /// Запуск алгоритма расчета
        /// </summary>
        /// <param name="beginp"></param>
        public void AlgorythmRun(Point beginp)
        {
            if (this.Points.Count() == 0 || this.Rebra.Count() == 0)
            {
                throw new DekstraException("Массив вершин или ребер не задан!");
            }
            else
            {
                BeginPoint = beginp;
                OneStep(beginp);
                foreach (Point point in Points)
                {
                    Point anotherP = GetAnotherUncheckedPoint();
                    if (anotherP != null)
                    {
                        OneStep(anotherP);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
        /// <summary>
        /// Метод, делающий один шаг алгоритма. Принимает на вход вершину
        /// </summary>
        /// <param name="beginpoint"></param>
        public void OneStep(Point beginpoint)
        {
            foreach (Point nextp in Pred(beginpoint))
            {
                if (nextp.IsChecked == false) //не отмечена
                {
                    float newmetka = beginpoint.ValueMetka + GetMyrRebro(nextp, beginpoint).Weight;
                    if (nextp.ValueMetka > newmetka)
                    {
                        nextp.ValueMetka = newmetka;
                        nextp.PredPoint = beginpoint;
                    }
                    else { }
                }
            }
            beginpoint.IsChecked = true; //вычеркиваем
        }
        /// <summary>
        /// Поиск соседей для вершины. Для неориентированного графа ищутся все соседи.
        /// </summary>
        /// <param name="currpoint"></param>
        /// <returns></returns>
        private IEnumerable<Point> Pred(Point currpoint)
        {
            IEnumerable<Point> firstpoints = from ff in Rebra where ff.FirstPoint == currpoint select ff.SecondPoint;
            IEnumerable<Point> secondpoints = from sp in Rebra where sp.SecondPoint == currpoint select sp.FirstPoint;
            IEnumerable<Point> totalpoints = firstpoints.Concat<Point>(secondpoints);
            return totalpoints;
        }
        /// <summary>
        /// Получаем ребро, соединяющее 2 входные точки
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private Rebro GetMyrRebro(Point a, Point b)
        {
            IEnumerable<Rebro> myr = from reb in Rebra where (reb.FirstPoint == a & reb.SecondPoint == b) || (reb.SecondPoint == a & reb.FirstPoint == b) select reb;
            if (myr.Count() > 1 || myr.Count() == 0)
            {
                throw new DekstraException("Не найдено ребро между соседями!");
            }
            else
            {
                return myr.First();
            }
        }
        /// <summary>
        /// Получаем очередную неотмеченную вершину, "ближайшую" к заданной.
        /// </summary>
        /// <returns></returns>
        private Point GetAnotherUncheckedPoint()
        {
            IEnumerable<Point> pointsuncheck = from p in Points where p.IsChecked == false select p;
            if (pointsuncheck.Count() != 0)
            {
                float minVal = pointsuncheck.First().ValueMetka;
                Point minPoint = pointsuncheck.First();
                foreach (Point p in pointsuncheck)
                {
                    if (p.ValueMetka < minVal)
                    {
                        minVal = p.ValueMetka;
                        minPoint = p;
                    }
                }
                return minPoint;
            }
            else
            {
                return null;
            }
        }
        public List<Point> MinPath(Point end)
        {
            List<Point> listOfPoints = new List<Point>();
            Point tempp = end;
            while (tempp != this.BeginPoint)
            {
                listOfPoints.Add(tempp);
                tempp = tempp.PredPoint;
            }
            return listOfPoints;
        }
    }
}
