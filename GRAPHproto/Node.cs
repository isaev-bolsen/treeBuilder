using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GRAPHproto
    {
    class Node
        {
        private StackPanel ParentPanel;
        private StackPanel thisVerticalPanel=new StackPanel();
        private UIElement NodeVisualObject = new Ellipse() {Width=15, Height=15, Margin=new Thickness(10), Fill=Brushes.Black};
        private StackPanel thisHorisontalPanel = new StackPanel() {Orientation=Orientation.Horizontal };

        public Node AddChild()
            {
            return new Node(thisHorisontalPanel); 
            }

        public Node(StackPanel parentPanel)
            {
            ParentPanel = parentPanel;
            ParentPanel.Children.Add(thisVerticalPanel);
            thisVerticalPanel.Children.Add(NodeVisualObject);
            thisVerticalPanel.Children.Add(thisHorisontalPanel);
            }
        }
    }
