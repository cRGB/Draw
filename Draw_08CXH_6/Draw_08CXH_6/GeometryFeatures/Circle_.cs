using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;

namespace Draw_08CXH_6
{
    class Circle_ : Geometry
    {
        double _r;
        double _x0;
        double _y0;

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

        string msg;
        public Circle_()
        {

        }

        public Circle_(double r, double x, double y)
        {
            _r = r;
            _x0 = x;
            _y0 = y;
            i++;
        }
        public override string ToString()
        {
            msg = "【圆" + i.ToString() + "】 " + Environment.NewLine +
                "[圆心]  " + _x0.ToString() + "," + _y0.ToString() + Environment.NewLine
                + "[半径]  " + _r.ToString() + Environment.NewLine
                + "[周长]  " + (Math.PI * 2 * _r).ToString() + Environment.NewLine
                + "[面积]  " + (Math.PI * _r * _r).ToString() + Environment.NewLine;
            return msg;
        }

        public  string ToString(int I)
        {
            msg = "【圆" + I.ToString() + "】 " + Environment.NewLine
                + "[圆心]  " + _x0.ToString() + "," + _y0.ToString() + Environment.NewLine
                + "[半径]  " + _r.ToString() + Environment.NewLine
                + "[周长]  " + (Math.PI * 2 * _r).ToString() + Environment.NewLine
                + "[面积]  " + (Math.PI * _r * _r).ToString() + Environment.NewLine;

            return msg;
        }
        public string ToTxt()
        {
            msg = "c@" + _x0.ToString() +
                ',' +
                _y0.ToString() +
                '-' +
                _r.ToString() +
                Environment.NewLine;
            return msg;
        }

        public override void DrawToCanvas(Canvas board)
        {
            Ellipse c = new Ellipse();

            c.Fill = new SolidColorBrush(Colors.SandyBrown);

            c.Stroke = new SolidColorBrush(Colors.Black);

            c.Width = _r * 2;
            c.Height = _r * 2;


            //左边和上面的距离要把握好，画板左上角才是坐标原点
            Canvas.SetTop(c, _y0 - _r);
            Canvas.SetLeft(c, _x0 - _r);

            board.Children.Add(c);
        }
    }
}
