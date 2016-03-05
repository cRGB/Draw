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
using Microsoft.Win32;
using System.IO;


namespace Draw_08CXH_6
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        //声明两个对话框组件，一个是输出对话框，一个是输入对话框
        SaveFileDialog outputTxt = new SaveFileDialog();
        OpenFileDialog inputTxt = new OpenFileDialog();


        //输出到Txt按钮的Click事件
        private void OutputButton_Click(object sender, RoutedEventArgs e)
        {
            if (DrawBoard.Children.Count == 0)
            {
                MessageBox.Show("先创建几个几何体啦~！");
            }
            else
            {
                outputTxt.Filter = "文本文件 （*.txt）|*.txt|全部 （*.*）|*.*";
                //Filter的作用就是在对话框中让用户看到输出的文件类型，是TXT类型还是全部类型
                //文本文件 （*.txt）这段是用户看到的，竖线后面的*.txt是后台搜索的范围

                outputTxt.FileOk += SaveToTxt;
                //FileOK是一个事件，把事件对应的函数名映射到该事件上即可。函数在下面会有写

                outputTxt.ShowDialog();
                //打开对话框
            }
        }

        //从Txt输入按钮的Click事件
        private void InputFromTxtButton_Click(object sender, RoutedEventArgs e)
        {
            /*
             * 这里的注释与输出按钮的类似
             */


            if (DrawBoard.Children.Count != 0)
            {
                MessageBoxResult dr = MessageBox.Show(this, "是否清除当前创建的几何体（不保存）？", "警告", MessageBoxButton.YesNo);

                if (dr == MessageBoxResult.Yes)
                {
                    try
                    {
                        ACFuntion();

                        inputTxt.Filter = "文本文件 （*.txt）|*.txt|全部 （*.*）|*.*";

                        inputTxt.FileOk += InputFromTxt;

                        inputTxt.ShowDialog();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("导入异常！请检查文本文件。");
                    }
                }
                else 
                {
                    return;
                }
                return;
            }
            else
            {
                try
                {
                    ACFuntion();

                    inputTxt.Filter = "文本文件 （*.txt）|*.txt|全部 （*.*）|*.*";

                    inputTxt.FileOk += InputFromTxt;

                    inputTxt.ShowDialog();
                }
                catch (Exception)
                {
                    MessageBox.Show("导入异常！请检查文本文件。");
                }
            }
        }

        public void SaveToTxt(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                //声明一个数据流写入器 sw
                using (StreamWriter sw = new StreamWriter(outputTxt.FileName))
                {

                    foreach (Point_ p in pFeatures)
                    {
                        sw.Write(p.ToTxt());
                    }
                    foreach (Polyline_ pl in plFeatures)
                    {
                        sw.Write(pl.ToTxt());
                    }
                    foreach (Rectangle_ rc in rcFeatures)
                    {
                        sw.Write(rc.ToTxt());
                    }
                    foreach (Circle_ c in cFeatures)
                    {
                        sw.Write(c.ToTxt());
                    }
                    foreach (Polygon_ pg in pgFeatures)
                    {
                        sw.Write(pg.ToTxt());
                    }

                }

                MessageBox.Show("输出成功！");
            }
            catch (Exception)
            {
                MessageBox.Show("输出失败！");
            }

        }

        public void InputFromTxt(object sender, System.ComponentModel.CancelEventArgs e)
        {

            ACFuntion();

            using (StreamReader sr = new StreamReader(inputTxt.FileName))
            {
                string line = sr.ReadLine();
                while (line != null)
                {
                    string[] features = line.Split('@');

                    switch (features[0])
                    {
                        case "p":
                            ReadPoint(features[1]);
                            break;
                        case "pl":
                            ReadPoly(features);
                            break;
                        case "rc":
                            ReadRectangle(features[1]);
                            break;
                        case "c":
                            ReadCircle(features[1]);
                            break;
                        case "pg":
                            ReadPoly(features);
                            break;
                        default:
                            break;
                    }
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            DrawWhat.Content = "请选择需要绘制的几何体类型！";
        }

        /// <summary>
        /// 四个函数可以分别判断五种类型的几何体并输出
        /// </summary>
        /// <param name="features">传入每一行字符串的消息</param>
        #region 几何体判别输出函数集合
        private void ReadPoint(string features)
        {
            string[] cood = features.Split(',');
            double x = double.Parse(cood[0]);
            double y = double.Parse(cood[1]);
            CreatePoint_Fun(x, y);
        }
        private void ReadRectangle(string features)
        {
            string[] cood = features.Split('~');
            string[] cood2;

            cood2 = cood[0].Split(',');

            double x0 = double.Parse(cood2[0]);
            double y0 = double.Parse(cood2[1]);

            cood2 = cood[1].Split(',');
            double x1 = double.Parse(cood2[0]);
            double y1 = double.Parse(cood2[1]);
            CreateRectangle_Fun(x0, y0, x1, y1);

        }
        private void ReadCircle(string features)
        {
            string[] cood = features.Split('-');

            string[] cood2 = cood[0].Split(',');
            double x0 = double.Parse(cood2[0]);
            double y0 = double.Parse(cood2[1]);
            double r = double.Parse(cood[1]);
            CreateCircle_Fun(r, x0, y0);

        }
        public void ReadPoly(string[] features)
        {
            List<Point_> Nodes = new List<Point_>();

            switch (features[0])
            {
                case "pl":
                    Nodes.Clear();
                    string[] pts = features[1].Split('-');
                    string[] value;
                    for (int i = 0; i < pts.Length - 1; i++)
                    {
                        value = pts[i].Split(',');
                        Point_ pt = new Point_("开始画折线！", double.Parse(value[0]), double.Parse(value[1]));

                        Nodes.Add(pt);
                    }
                    CreatePolyline_Fun(Nodes);
                    break;
                case "pg":
                    Nodes.Clear();
                    pts = features[1].Split('-');
                    for (int i = 0; i < pts.Length - 1; i++)
                    {
                        value = pts[i].Split(',');
                        Point_ pt = new Point_("开始画多边形！", double.Parse(value[0]), double.Parse(value[1]));

                        Nodes.Add(pt);
                    }
                    CreatePolygon_Fun(Nodes);
                    break;
                default:

                    break;
            }
            Nodes.Clear();
            Nodes.Capacity = 0;

        }
        #endregion

        #region 标准文本文件说明
        /*
                     * 这里的逻辑是从特定格式的文本文件中读取
                     * 文本格式应为
                     * 
                     *
                     * p@0,0
                     * p@0,1
                     * p@53,6
                     * p@79,7
                     * x
                     * pl@0,1-2,2-7,8-9,10-8,65
                     * pl@0,1-2,2-7,8-9,10-8,65
                     * 
                     * rc@0,0~1,1
                     * rc@565,8~11,98
                     * 
                     * c@0,0-7
                     * c@56,9-15
                     * 
                     * pg@0,1-2,2-7,8-9,10-0,1
                     * 
                     * 
                     */

        #endregion
    }
}