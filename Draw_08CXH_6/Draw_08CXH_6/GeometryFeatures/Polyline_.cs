using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Shapes;

using System.Windows.Media;

namespace Draw_08CXH_6
{
    class Polyline_ : Geometry
    {
        List<Point_> _pl = new List<Point_>();

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


        public Polyline_()
        {

        }
        public Polyline_(List<Point_> PolyNodes)
        {
            foreach (Point_ t in PolyNodes)
            {
                _pl.Add(t);//把PolyNodes里的点全部取出传入Polyline_类对象内部的容器
            }
            i++;
        }


        public override string ToString(int I)
        {
            string msg = "【折线" + I.ToString() + "】： " + Environment.NewLine;

            for (int j = 0; j < _pl.Count; j++)
            {
                if (j != _pl.Count - 1)
                    msg += '(' + _pl[j].X0.ToString() + ',' + _pl[j].Y0.ToString() + ')' + '-';
                else
                    msg += '(' + _pl[j].X0.ToString() + ',' + _pl[j].Y0.ToString() + ')';
            }
            msg += Environment.NewLine;

            return msg;
        }
        public override string ToString()
        {

            string msg = "【折线" + i.ToString() + "】： " + Environment.NewLine;

            for (int j = 0; j < _pl.Count; j++)
            {
                if (j != _pl.Count - 1)
                    msg += '(' + _pl[j].X0.ToString() + ',' + _pl[j].Y0.ToString() + ')' + '-';
                else
                    msg += '(' + _pl[j].X0.ToString() + ',' + _pl[j].Y0.ToString() + ')';
            }

            msg += Environment.NewLine;
            return msg;
        }

        public string ToTxt()
        {
            string msg = "pl@";
            for (int i = 0; i < _pl.Count; i++)
            {
                if (i != _pl.Count - 1)
                    msg += _pl[i].X0.ToString() + ',' + _pl[i].Y0.ToString() + '-';
                else
                    msg += _pl[i].X0.ToString() + ',' + _pl[i].Y0.ToString();
            }
            msg += Environment.NewLine;

            return msg;
        }


        public override void DrawToCanvas(Canvas board)
        {

            for (int i = 0; i < _pl.Count; i++)
            {
                Line l = new Line();
                l.Stroke = new SolidColorBrush(Colors.Black);
                int j = i + 1;
                if (j != _pl.Count)
                {
                    l.X1 = _pl[i].X0;
                    l.Y1 = _pl[i].Y0;
                    l.X2 = _pl[j].X0;
                    l.Y2 = _pl[j].Y0;
                    board.Children.Add(l);
                }
            }
        }
    }
}
