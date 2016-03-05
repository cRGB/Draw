using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;

namespace Draw_08CXH_6
{
    class Point_ : Geometry
    {
        static int fid = 0;//所有点的数量
        public int Fid //Fid的访问器
        {
            set
            {
                fid = value;
            }
            get
            {
                return fid;
            }
        }


        double _x0;
        double _y0;//点的俩坐标
        public double X0
        {
            get
            {
                return _x0;
            }
        }
        public double Y0
        {
            get
            {
                return _y0;
            }
        }

        static int polyNodes = 0;//折线或多边形计数器


        #region 构造函数
        public Point_()//空构造函数
        {

        }
        public Point_(double x, double y)//传入点构造函数
        {
            _x0 = x;
            _y0 = y;

            fid++;
        }
        public Point_(string S, double x, double y)//字符串参数S来标示是什么类型的点，由TextBox-Tips的content值确定
        //这个构造函数用于保存折线点或者圆心点、矩形第一个点
        {
            switch (S)
            {
                case "开始画矩形！":
                    {
                        _x0 = x;
                        _y0 = y;
                    }
                    break;
                case "开始画圆！":
                    {
                        _x0 = x;
                        _y0 = y;
                    }
                    break;
                case "开始画折线！":
                    {
                        _x0 = x;
                        _y0 = y;
                        polyNodes++;
                    }
                    break;
                case "开始画多边形！":
                    {
                        _x0 = x;
                        _y0 = y;
                        polyNodes++;
                    }
                    break;
            }


        }
        #endregion



        public override string ToString()
        {

            string msg = "【点" + fid.ToString() + "】： " + _x0.ToString() + "," + _y0.ToString();
            return msg;
        }
        public override string ToString(int I)
        {
            string msg = "【点" + I.ToString() + "】： " + _x0.ToString() + "," + _y0.ToString() + Environment.NewLine;

            return msg;
        }

        public string ToTxt()//这个函数用于输出标准txt文件用
        {
            string msg = "p@" + X0.ToString() +
                ',' +
                Y0.ToString() + Environment.NewLine;
            return msg;
        }

        public override void DrawToCanvas(Canvas board)//顾名思义，画到画板上
        {
            //定义两条小线段，确定每条线段的位置及长度，颜色，形成一个十字交叉点的样子，然后添加到board画板中。
            Line x = new Line();
            Line y = new Line();

            //下面对x和y线段的颜色进行设置
            x.Stroke = new SolidColorBrush(Colors.Black);
            y.Stroke = new SolidColorBrush(Colors.Black);


            //下面对x横向和y纵向的两条小线段进行设置参数，主要是长度信息
            x.X1 = _x0 - 3;
            x.Y1 = _y0;
            x.X2 = _x0 + 3;
            x.Y2 = _y0;


            y.Y1 = _y0 + 3;
            y.X1 = _x0;
            y.Y2 = _y0 - 3;
            y.X2 = _x0;

            //添加到画板。
            board.Children.Add(x);
            board.Children.Add(y);
        }
        public void DrawToCanvas(Canvas board, string msg)//画圆心的点
        {
            if (msg == "画圆")
            {

                Line x = new Line();
                Line y = new Line();

                x.Stroke = new SolidColorBrush(Colors.Red);
                y.Stroke = new SolidColorBrush(Colors.Red);


                x.X1 = _x0 - 5;
                x.Y1 = _y0;
                x.X2 = _x0 + 5;
                x.Y2 = _y0;


                y.Y1 = _y0 + 5;
                y.X1 = _x0;
                y.Y2 = _y0 - 5;
                y.X2 = _x0;

                board.Children.Add(x);
                board.Children.Add(y);

            }
        }
    }
}
