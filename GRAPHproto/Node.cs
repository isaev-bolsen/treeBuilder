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
        private FrameworkElement NodeVisualObject = new Ellipse() {Width=15, Height=15, Margin=new Thickness(15), Fill=Brushes.Black};
        private StackPanel HorisontalPanel = new StackPanel() {Orientation=Orientation.Horizontal };

        private Canvas EdgeCanvas = new Canvas() {HorizontalAlignment=HorizontalAlignment.Center };
        private Binding EdgeBaseBinding = new Binding("ActualWidth");
        protected Line Edge;


        public void UpdateEdges(object sender, SizeChangedEventArgs e)
            {
            double Xpos=-this.HorisontalPanel.ActualWidth/2;
            foreach (Node node in this.HorisontalPanel.Children)
                {
                //this.NodeVisualObject.Margin = new Thickness(15,15,15,e.NewSize.Width *15/45);
                node.Edge.Y1 = -NodeVisualObject.Margin.Bottom - NodeVisualObject.Height / 2;
                node.Edge.Y2 = NodeVisualObject.Margin.Top + NodeVisualObject.Height / 2;
                Xpos += node.ActualWidth / 2;
                node.Edge.X2 = Xpos;
                Xpos += node.ActualWidth / 2;
                }
            }

        public void AddChild(object sender, MouseButtonEventArgs e)
            {
            switch (e.ChangedButton)
                {
                case MouseButton.Left:
                    Line edge = new Line() {X1 = 0, X2 = 0, Stroke = Brushes.Black};
                    EdgeCanvas.Children.Add(edge);
                    new Node(HorisontalPanel, edge);
                    break;
                case MouseButton.Right:
                    if (Edge!=null)
                        {
                        ParentPanel.Children.Remove(this);
                        ((Canvas)Edge.Parent).Children.Remove(Edge);
                        }
                    break;
                }
            }

        public Node(StackPanel parentPanel, Line edge=null)
            {
            NodeVisualObject.MouseDown += AddChild;
            ParentPanel = parentPanel;
            ParentPanel.Children.Add(this);
            this.Children.Add(NodeVisualObject);
            this.Children.Add(EdgeCanvas);
            this.Children.Add(HorisontalPanel);
            this.HorisontalPanel.AddHandler(FrameworkElement.SizeChangedEvent, new SizeChangedEventHandler(UpdateEdges), true);
            if (edge != null)
                {
                Edge = edge;
                } 
            }
        }
    }
