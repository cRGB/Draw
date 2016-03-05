using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Shapes;

using System.Windows.Media;

namespace Draw_08CXH_6
{
    class Rectangle_ : Geometry
    {
        double _x0, _x1, _y0, _y1;

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


        #region 构造函数

        public Rectangle_()
        {

        }
        public Rectangle_(double x0, double y0, double x1, double y1)
        {
            _x0 = x0;
            _x1 = x1;
            _y0 = y0;
            _y1 = y1;
            i++;
        }
        public double GetAver(double a, double b)
        {
            return (a + b) / 2;
        }

        #endregion

        public override string ToString(int I)
        {
            string msg = "【矩形" + I.ToString() + "】： " + Environment.NewLine
                + "[中心]  " + GetAver(_x0, _x1).ToString() + "," + GetAver(_y0, _y1).ToString() + Environment.NewLine
                + "[周长]  " + ((Math.Abs(_x0 - _x1) + Math.Abs(_y0 - _y1)) * 2).ToString() + Environment.NewLine
                + "[面积]  " + ((Math.Abs(_x0 - _x1)) * (Math.Abs(_y0 - _y1))).ToString() + Environment.NewLine;

            return msg;
        }
        public override string ToString()
        {
            string msg = "【矩形" + i.ToString() + "】： " + Environment.NewLine
                + "[中心]  " + GetAver(_x0, _x1).ToString() + "," + GetAver(_y0, _y1).ToString() + Environment.NewLine
                + "[周长]  " + ((Math.Abs(_x0 - _x1) + Math.Abs(_y0 - _y1)) * 2).ToString() + Environment.NewLine
                + "[面积]  " + ((Math.Abs(_x0 - _x1)) * (Math.Abs(_y0 - _y1))).ToString() + Environment.NewLine;

            return msg;
        }
        public string ToTxt()
        {
            string msg = "rc@" +
                _x0.ToString() + ',' + _y0.ToString() +
                '~' +
                _x1.ToString() + ',' + _y1.ToString() + Environment.NewLine;
            return msg;
        }


        public override void DrawToCanvas(Canvas board)
        {
            Rectangle rc = new Rectangle();

            rc.Fill = new SolidColorBrush(Colors.LemonChiffon);

            rc.Stroke = new SolidColorBrush(Colors.Black);

            rc.Width = Math.Abs(_x1 - _x0);
            rc.Height = Math.Abs(_y1 - _y0);

            //调用Min函数是因为第二个点的顺序问题，一般第二个点在第一个点的右下方，如果不是在右下方就必须判断最小值。
            Canvas.SetTop(rc, Math.Min(_y1, _y0));
            Canvas.SetLeft(rc, Math.Min(_x1, _x0));

            board.Children.Add(rc);

        }
    }
}
