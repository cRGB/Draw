using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections;

namespace Draw_08CXH_6
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        public void ACFuntion()//AC=All Clean，多功能计算器上常见的按钮
        {
            //文本框清空
            Result.Text = string.Empty;
            DrawWhat.Content = "请选择绘制的类型！";


            //状态归位
            statement = DrawStatement.None;
            clickTimes = ClickTimes.Once;

            //画板清空
            DrawBoard.Children.Clear();

            //计数器归零
            PointCount.Content = "0";
            RectangleCount.Content = "0";
            CircleCount.Content = "0";
            PolylineCount.Content = "0";
            PolygonCount.Content = "0";

            //静态计数归零
            Point_ p = new Point_();
            p.Fid = 0;
            Circle_ c = new Circle_();
            c.I = 0;
            Rectangle_ rc = new Rectangle_();
            rc.I = 0;
            Polyline_ pl = new Polyline_();
            pl.I = 0;
            Polygon_ pg = new Polygon_();
            pg.I = 0;


            //容器清空
            pFeatures.Clear();
            pFeatures.Capacity = 0;

            cFeatures.Clear();
            cFeatures.Capacity = 0;

            rcFeatures.Clear();
            rcFeatures.Capacity = 0;

            plFeatures.Clear();
            plFeatures.Capacity = 0;

            pgFeatures.Clear();
            pgFeatures.Capacity = 0;

            PolyNodes.Clear();
            PolyNodes.Capacity = 0;

            
        }

        private void PrintEveryFeatures()
        {
            Result.Text = string.Empty;
            foreach (Point_ t in pFeatures)
            {
                Result.Text += t.ToString(featureCount);
                featureCount++;
            }
            featureCount = 1;
            Result.Text += Environment.NewLine;
            foreach (Circle_ t in cFeatures)
            {
                Result.Text += t.ToString(featureCount);
                featureCount++;
            }
            featureCount = 1;
            Result.Text += Environment.NewLine;
            foreach (Rectangle_ t in rcFeatures)
            {
                Result.Text += t.ToString(featureCount);
                featureCount++;
            }
            featureCount = 1;
            Result.Text += Environment.NewLine;
            foreach (Polyline_ t in plFeatures)
            {
                Result.Text += t.ToString(featureCount);
                featureCount++;
            }
            featureCount = 1;
            Result.Text += Environment.NewLine;
            foreach (Polygon_ t in pgFeatures)
            {
                Result.Text += t.ToString(featureCount);
                featureCount++;
            }
            Result.ScrollToEnd();
        }
        
        private void DrawBoard_MouseDown(object sender, MouseButtonEventArgs e)//此为Grid总鼠标按下时会发生的逻辑
        {
            Point temp = e.GetPosition((IInputElement)sender);//借用系统的点类，定义暂存点

            switch (statement)
            {

                case DrawStatement.Point:
                    CreatePoint_Fun(temp.X, (int)temp.Y);
                    break;
                case DrawStatement.Rectangle:

                    switch (clickTimes)
                    {
                        case ClickTimes.Once://若是第一个点，就生成第一个点，clickTimes自加1
                            ptemp = new Point_((string)DrawWhat.Content, temp.X, (int)temp.Y);
                            clickTimes = ClickTimes.Twice;
                            break;
                        case ClickTimes.Twice://若是第二个点，就生成矩形对象,clickTimes归1
                            CreateRectangle_Fun(ptemp.X0, ptemp.Y0, temp.X, (int)temp.Y);

                            clickTimes = ClickTimes.Once;
                            break;
                        default://什么都不做
                            break;
                    }
                    break;
                case DrawStatement.Circle:
                    switch (clickTimes)
                    {
                        case ClickTimes.Once://若是第一个点，就生成圆心，clickTimes自加1
                            ptemp = new Point_((string)DrawWhat.Content, temp.X, (int)temp.Y);
                            clickTimes = ClickTimes.Twice;
                            break;

                        case ClickTimes.Twice://若是第二个点，就生成圆对象，需要局部定义半径r
                            double r = Math.Sqrt((ptemp.X0 - temp.X) * (ptemp.X0 - temp.X) + ((int)ptemp.Y0 - (int)temp.Y) * ((int)ptemp.Y0 - (int)temp.Y));

                            CreateCircle_Fun(r, ptemp.X0, (int)ptemp.Y0);

                            clickTimes = ClickTimes.Once;
                            break;
                        default://什么都不做
                            break;
                    }
                    break;
                case DrawStatement.Polyline:
                    switch (e.ClickCount)//判断是双击还是单击
                    {
                        case 1://单击，暂存点到容器内
                            ptemp = new Point_((string)DrawWhat.Content, temp.X, (int)temp.Y);
                            PolyNodes.Add(ptemp);//多边形计数器需要自加1，在点类中进行
                            break;
                        case 2://双击，调用折线构造函数
                            CreatePolyline_Fun(PolyNodes);
                            break;
                        default://什么都不干
                            break;
                    }
                    break;
                case DrawStatement.Polygon:
                    switch (e.ClickCount)//判断是双击还是单击
                    {
                        case 1://单击，暂存点到容器内
                            ptemp = new Point_((string)DrawWhat.Content, temp.X, (int)temp.Y);
                            PolyNodes.Add(ptemp);//多边形计数器需要自加1，在点类中进行
                            break;
                        case 2://双击，调用多边形构造函数
                            CreatePolygon_Fun(PolyNodes);
                            break;
                        default://什么都不干
                            break;
                    }
                    break;
                default://什么都不干
                    break;
            }

        }

        private void DrawBoard_MouseMove(object sender, MouseEventArgs e)
        {
            Point state = e.GetPosition((IInputElement)sender);

            Cood.Content = (state.X.ToString() + "," + ((int)state.Y).ToString()).ToString();
        }
        
        
        #region 功能函数

        private void CreateRectangle_Fun(double x0, double y0, double x1, double y1)//第二次点击时要调用的构造函数
        {
            Rectangle_ rc = new Rectangle_(x0, y0, x1, y1);
            //接下来要进行计算和输出，并把圆加入到容器中。
            //调用重载的ToString方法输出周长、面积、矩形中心
            rc.DrawToCanvas(DrawBoard);
            rcFeatures.Add(rc);
            DrawWhat.Content = "开始画矩形！";
            RectangleCount.Content = rc.I.ToString();
        }
        private void CreateCircle_Fun(double r, double x, double y)//第二次点击时要调用的构造函数
        {
            Circle_ c = new Circle_(r, x, y);
            //接下来要进行计算和输出，并把圆加入到ArrayList中。
            //调用重载的ToString方法输出周长、面积、圆心
            cFeatures.Add(c);
            //绘制到画布上
            c.DrawToCanvas(DrawBoard);
            Point_ p = new Point_("开始画圆！", x, y);
            p.DrawToCanvas(DrawBoard, "画圆");
            DrawWhat.Content = "开始画圆！";
            CircleCount.Content = c.I.ToString();
        }
        private void CreatePoint_Fun(double x, double y)//第二次点击时要调用的构造函数
        {
            //构造点p
            Point_ p = new Point_(x, y);
            //绘制到画布上
            p.DrawToCanvas(DrawBoard);
            //加入到容器中
            pFeatures.Add(p);
            //输出到下面的textbox
            DrawWhat.Content = "开始画点！";
            //计数器更新
            PointCount.Content = p.Fid.ToString();

        }

        //注意，以下两个方法，传入的arr用于构造折线或多边形，外部的PolyNodes集合是不会改变的，是值传递，为了避免数据出错，最好创建完一个折边的对象就清除一次

        private void CreatePolyline_Fun(List<Point_> arr)//双击时要调用的构造函数
        {
            Polyline_ pl = new Polyline_(arr);
            //应传入容器类，并遍历容器的点以生成折线
            PolyNodes.Clear();//创建完成后清除最高级的暂存容器，以防创建第二个折线或其他多边形时混淆。
            pl.DrawToCanvas(DrawBoard);
            plFeatures.Add(pl);
            DrawWhat.Content = "开始画折线！";
            PolylineCount.Content = pl.I.ToString();
        }
        private void CreatePolygon_Fun(List<Point_> arr)//双击时要调用的构造函数
        {
            Polygon_ pg = new Polygon_(arr);
            //应传入容器类，并遍历容器的点以生成多边形
            PolyNodes.Clear();//创建完成后清除最高级的暂存容器，以防创建第二个折线或其他多边形时混淆。

            pg.DrawToCanvas(DrawBoard);
            pgFeatures.Add(pg);
            DrawWhat.Content = "开始画多边形！";
            PolygonCount.Content = pg.I.ToString();
        }

        #endregion
    }
}