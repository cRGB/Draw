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

namespace Draw_08CXH_6
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        #region Click事件
        //以下的Create事件函数会改变绘制的状态，并在Tips文本框输出提示
        private void CreatePoint_Click(object sender, RoutedEventArgs e)
        {
            statement = DrawStatement.Point;
            DrawWhat.Content = "开始画点！";
        }
        private void CreateRectangle_Click(object sender, RoutedEventArgs e)
        {
            statement = DrawStatement.Rectangle;
            DrawWhat.Content = "开始画矩形！";
            clickTimes = ClickTimes.Once;
        }
        private void CreateCircle_Click(object sender, RoutedEventArgs e)
        {
            statement = DrawStatement.Circle;
            DrawWhat.Content = "开始画圆！";
            clickTimes = ClickTimes.Once;
        }
        private void CreatePolyline_Click(object sender, RoutedEventArgs e)
        {
            statement = DrawStatement.Polyline;
            DrawWhat.Content = "开始画折线！";
            PolyNodes.Clear();
        }
        private void CreatePolygon_Click(object sender, RoutedEventArgs e)
        {
            statement = DrawStatement.Polygon;
            DrawWhat.Content = "开始画多边形！";
            PolyNodes.Clear();
        }
        //以下俩方法就是调用函数而已
        private void PrintAllFeatures_Click(object sender, RoutedEventArgs e)
        {
            if (DrawBoard.Children.Count == 0)
            {
                MessageBox.Show("没有东东，先创建啦！");
            }
            else
            {
                PrintEveryFeatures();
            }
        }
        public void AC_Click(object sender, RoutedEventArgs e)
        {
            if (DrawBoard.Children.Count == 0)
            {
                MessageBox.Show("都没东西你清理个蛋蛋");
            }
            else
            {
                MessageBoxResult dr = MessageBox.Show(this, "是否清除所有已存在的几何体？", "警告", MessageBoxButton.YesNo);

                if (dr == MessageBoxResult.Yes)
                {
                    ACFuntion();
                }
                return;
            }
        }
        #endregion
    }
}