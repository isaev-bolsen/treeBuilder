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
        private bool isRoot;
        private StackPanel ParentPanel;
        private FrameworkElement NodeVisualObject = new Ellipse() {Width=15, Height=15, Margin=new Thickness(15), Fill=Brushes.Black};
        private StackPanel thisHorisontalPanel = new StackPanel() {Orientation=Orientation.Horizontal };

        public void AddChild(object sender, MouseButtonEventArgs e)
            {
            switch (e.ChangedButton)
                {
                case MouseButton.Left:
                        new Node(thisHorisontalPanel);
                        //this.NodeVisualObject.Margin = new Thickness(
                        //    this.NodeVisualObject.Margin.Left,
                        //    this.NodeVisualObject.Margin.Top,
                        //    this.NodeVisualObject.Margin.Right,
                        //    this.NodeVisualObject.Margin.Bottom + 5
                        //    );
                    break;
                case MouseButton.Right:
                    if (!isRoot)
                    { 
                        ParentPanel.Children.Remove(this); 
                        }
                    break;
                }
            }

        public Node(StackPanel parentPanel, bool isroot=false)
            {
            isRoot = isroot;
            NodeVisualObject.MouseDown += AddChild;
            ParentPanel = parentPanel;
            ParentPanel.Children.Add(this);
            this.Children.Add(NodeVisualObject);
            this.Children.Add(thisHorisontalPanel);
            }
        }
    }
