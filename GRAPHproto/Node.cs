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


    class Node : StackPanel
        {

        private StackPanel ParentPanel;
        private UIElement NodeVisualObject = new Ellipse() {Width=15, Height=15, Margin=new Thickness(10), Fill=Brushes.Black};
        private StackPanel thisHorisontalPanel = new StackPanel() {Orientation=Orientation.Horizontal };

        public void AddChild(object sender, MouseButtonEventArgs e)
            {
            switch (e.ChangedButton)
                {
                case MouseButton.Left:
                        new Node(thisHorisontalPanel);
                        break;
                case MouseButton.Right:
                        ParentPanel.Children.Remove(this);
                    break;
                  
                }
            }

        public Node(StackPanel parentPanel)
            {
            //NodeVisualObject.AddHandler(UIElement.MouseDownEvent, AddChild);
            NodeVisualObject.MouseDown += AddChild;
            ParentPanel = parentPanel;
            ParentPanel.Children.Add(this);
            this.Children.Add(NodeVisualObject);
            this.Children.Add(thisHorisontalPanel);
            }
        }
    }
