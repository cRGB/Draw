using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Shapes;

using System.Windows.Media;

namespace Draw_08CXH_6
{
    class Polygon_ : Geometry
    {
        List<Point_> _pg = new List<Point_>();

        static int i = 0;
        public int I
        {
            set
            {
                i = value;
            }
            get
            {
                return i;
            }
        }

        public Polygon_()
        {

        }
        public Polygon_(List<Point_> PolyNodes)
        {
            foreach (Point_ t in PolyNodes)
            {
                _pg.Add(t);//把polynodes里的点全部取出传入Polygon_类对象内部的容器

            }

            Point_ endNodes = new Point_();

            endNodes = PolyNodes[0];//把起始点信息作为终结点，并传入_pg容器，产生多边形

            _pg.Add(endNodes);

            i++;
        }

        public string ToTxt()
        {

            string msg = "pg@";
            for (int i = 0; i < _pg.Count; i++)
            {
                if (i != _pg.Count - 1)
                    msg += _pg[i].X0.ToString() + ',' + _pg[i].Y0.ToString() + '-';
                else
                    msg += _pg[i].X0.ToString() + ',' + _pg[i].Y0.ToString();
            }
            msg += Environment.NewLine;

            return msg;
        }

        public override string ToString()
        {

            string msg = "【多边形" + i.ToString() + "】： " + Environment.NewLine;

            for (int j = 0; j < _pg.Count; j++)
            {
                if (i != _pg.Count - 1)
                    msg += '(' + _pg[i].X0.ToString() + ',' + _pg[i].Y0.ToString() + ')' + '-';
                else
                    msg += '(' + _pg[i].X0.ToString() + ',' + _pg[i].Y0.ToString() + ')';
            }
            msg += Environment.NewLine;
            return msg;
        }
        public override string ToString(int I)
        {

            string msg = "【多边形" + I.ToString() + "】： " + Environment.NewLine;

            for (int i = 0; i < _pg.Count; i++)
            {
                if (i != _pg.Count - 1)
                    msg += '(' + _pg[i].X0.ToString() + ',' + _pg[i].Y0.ToString() + ')' + '-';
                else
                    msg += '(' + _pg[i].X0.ToString() + ',' + _pg[i].Y0.ToString() + ')';
            }
            msg += Environment.NewLine;

            return msg;
        }

        public override void DrawToCanvas(Canvas board)
        {
            for (int i = 0; i < _pg.Count; i++)
            {
                Line l = new Line();
                l.Stroke = new SolidColorBrush(Colors.BlueViolet);
                int j = i + 1;


                if (j != _pg.Count)
                {
                    l.X1 = _pg[i].X0;
                    l.Y1 = _pg[i].Y0;
                    l.X2 = _pg[j].X0;
                    l.Y2 = _pg[j].Y0;
                    board.Children.Add(l);
                }
                else
                {
                    l.X1 = _pg[i].X0;
                    l.Y1 = _pg[i].Y0;
                    l.X2 = _pg[0].X0;
                    l.Y2 = _pg[0].Y0;
                    board.Children.Add(l);
                }
            }
        }
    }
}
