﻿#pragma checksum "..\..\..\MainWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "C4AD9CA6CD6BE7084B8C7408973DD195"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.1
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Draw_08CXH_6 {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\MainWindow.xaml"
        internal System.Windows.Controls.Grid Top;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\MainWindow.xaml"
        internal System.Windows.Controls.Menu menu1;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\MainWindow.xaml"
        internal System.Windows.Controls.ToolBar toolBar1;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\MainWindow.xaml"
        internal System.Windows.Controls.Canvas DrawBoard;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\MainWindow.xaml"
        internal System.Windows.Controls.GridSplitter gridSplitter1;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\MainWindow.xaml"
        internal System.Windows.Controls.TextBox Result;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\MainWindow.xaml"
        internal System.Windows.Controls.Primitives.StatusBar statusBar1;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\MainWindow.xaml"
        internal System.Windows.Controls.Primitives.StatusBarItem NowState;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\MainWindow.xaml"
        internal System.Windows.Controls.Primitives.StatusBarItem XY;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\MainWindow.xaml"
        internal System.Windows.Controls.Primitives.StatusBarItem Cood;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\MainWindow.xaml"
        internal System.Windows.Controls.Primitives.StatusBarItem DrawWhat;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\MainWindow.xaml"
        internal System.Windows.Controls.Primitives.StatusBarItem PointCount;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\MainWindow.xaml"
        internal System.Windows.Controls.Primitives.StatusBarItem PolylineCount;
        
        #line default
        #line hidden
        
        
        #line 77 "..\..\..\MainWindow.xaml"
        internal System.Windows.Controls.Primitives.StatusBarItem RectangleCount;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\MainWindow.xaml"
        internal System.Windows.Controls.Primitives.StatusBarItem CircleCount;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\MainWindow.xaml"
        internal System.Windows.Controls.Primitives.StatusBarItem PolygonCount;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Draw_08CXH_6;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Top = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.menu1 = ((System.Windows.Controls.Menu)(target));
            return;
            case 3:
            
            #line 22 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.InputFromTxtButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 23 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.OutputButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 26 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.CreatePoint_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 27 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.CreatePolyline_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 28 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.CreateRectangle_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 29 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.CreateCircle_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 30 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.CreatePolygon_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 34 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.PrintAllFeatures_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 35 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.AC_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.toolBar1 = ((System.Windows.Controls.ToolBar)(target));
            return;
            case 13:
            
            #line 39 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CreatePoint_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 40 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CreatePolyline_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            
            #line 41 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CreateRectangle_Click);
            
            #line default
            #line hidden
            return;
            case 16:
            
            #line 42 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CreateCircle_Click);
            
            #line default
            #line hidden
            return;
            case 17:
            
            #line 43 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CreatePolygon_Click);
            
            #line default
            #line hidden
            return;
            case 18:
            this.DrawBoard = ((System.Windows.Controls.Canvas)(target));
            
            #line 54 "..\..\..\MainWindow.xaml"
            this.DrawBoard.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.DrawBoard_MouseDown);
            
            #line default
            #line hidden
            
            #line 54 "..\..\..\MainWindow.xaml"
            this.DrawBoard.MouseMove += new System.Windows.Input.MouseEventHandler(this.DrawBoard_MouseMove);
            
            #line default
            #line hidden
            return;
            case 19:
            this.gridSplitter1 = ((System.Windows.Controls.GridSplitter)(target));
            return;
            case 20:
            this.Result = ((System.Windows.Controls.TextBox)(target));
            return;
            case 21:
            this.statusBar1 = ((System.Windows.Controls.Primitives.StatusBar)(target));
            return;
            case 22:
            this.NowState = ((System.Windows.Controls.Primitives.StatusBarItem)(target));
            return;
            case 23:
            this.XY = ((System.Windows.Controls.Primitives.StatusBarItem)(target));
            return;
            case 24:
            this.Cood = ((System.Windows.Controls.Primitives.StatusBarItem)(target));
            return;
            case 25:
            this.DrawWhat = ((System.Windows.Controls.Primitives.StatusBarItem)(target));
            return;
            case 26:
            this.PointCount = ((System.Windows.Controls.Primitives.StatusBarItem)(target));
            return;
            case 27:
            this.PolylineCount = ((System.Windows.Controls.Primitives.StatusBarItem)(target));
            return;
            case 28:
            this.RectangleCount = ((System.Windows.Controls.Primitives.StatusBarItem)(target));
            return;
            case 29:
            this.CircleCount = ((System.Windows.Controls.Primitives.StatusBarItem)(target));
            return;
            case 30:
            this.PolygonCount = ((System.Windows.Controls.Primitives.StatusBarItem)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
