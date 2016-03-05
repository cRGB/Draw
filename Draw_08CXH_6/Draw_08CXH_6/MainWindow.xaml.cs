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

    /*
     * 本程序逻辑
     * 先选择创建什么几何体，通过按下五个按钮实现。
     * 按下按钮后，会改变左下角Tips文本框的文本内容
     * 在画布上点击，会触发MouseDown事件
     *      swtich开始第一层判断，先判断Tips文本框里显示什么内容，从而决定创建什么几何体
     *      若是点，直接创建点
     *      若是圆或矩形，第二层判断，是第一次点还是第二次点？
     *          第一次，用临时变量ptemp暂时保存。
     *          第二次，将ptemp和第二个点的X和Y值一起传送到Create几何体_Fun函数，创建矩形或者圆
     *      若是折线和多边形，第二层判断clickCount次数
     *          若是单击，把得到的点存到PolyNodes里暂存
     *          若是双击，代表此创建结束，把PolyNodes和最后一个点传送到Ceate几何体_Fun函数里，完成创建折线或多边形
     *      对每个Create_Fun函数，里面要输出计数器，也要输出画布上的图案（画图的那个函数，本例为DrawToCanvas()）
     *  构造函数的逻辑也要清楚，对于不是纯点的点（矩形的、圆心、折线的顶点等）计数器不能自加，需要另一个构造函数
     *  折线和多边形的对象内，需要一个容器（本程序用泛型List类保存）保存一系列的点。折线最好还能标识起始点和终结点
     * 
     * 
     *  对于ShowAll函数，需要遍历容器内的元素，调用五种不同几何对象的ToString，特定的字符串输出到文本框即可。
     *  对于AC(AllClean)函数，需要清除容器，要清除当前状态，需要清除画板，需要清除计数器，需要清楚输出的文本框。
     * 
     *  对于最下面的两个文本框，暂时不做其他处理，已经被锁定成只读，不能修改。
     * 
     */

    public partial class MainWindow : Window
    {
        //初始化函数，初始化窗口并打开窗口
        public MainWindow()
        {
            InitializeComponent();
        }

        //以下是泛型容器，不固定长度，只限定类型
        //其中PolyNodes是存放折线或者多边形的点用的
        //后来想想这个PolyNodes是可以删除的，在Polyline_和Polygon_类里对类里头的点容器加一个添加的函数即可，不深究。

        List<Point_> PolyNodes = new List<Point_>();

        List<Point_> pFeatures = new List<Point_>();
        List<Circle_> cFeatures = new List<Circle_>();
        List<Rectangle_> rcFeatures = new List<Rectangle_>();
        List<Polyline_> plFeatures = new List<Polyline_>();
        List<Polygon_> pgFeatures = new List<Polygon_>();


        enum ClickTimes { Once, Twice };
        ClickTimes clickTimes = ClickTimes.Once;
        //ClickTimes枚举类型变量clickTimes，用来标记在Grid单击时第几次创建了点

        enum DrawStatement { None, Point, Polyline, Rectangle, Circle, Polygon };
        DrawStatement statement = DrawStatement.None;

        static int featureCount = 1; //用于Result文本框的输出计数器（点1、点2、点3……）


        Point_ ptemp;






        //存圆心、折线或多边形顶点、矩形第一个点用。
    }
}
