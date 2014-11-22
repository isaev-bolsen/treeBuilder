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
        private FrameworkElement NodeVisualObject = new Ellipse() {Width=25, Height=25, Margin=new Thickness(30), Fill=Brushes.Black};
        private StackPanel HorisontalPanel = new StackPanel() {Orientation=Orientation.Horizontal };
        protected Canvas EdgeCanvas = new Canvas() { HorizontalAlignment = HorizontalAlignment.Center };
        protected Line Edge;
        protected TextBox EdgeCaption = new TextBox();

       public void SetTextBoxBrushRecursive(Brush brush)
            {
           //it must be the better way to do that
            EdgeCaption.BorderBrush = brush;
            foreach (Node node in HorisontalPanel.Children) node.SetTextBoxBrushRecursive(brush);
            }


        public void UpdateEdges(object sender, SizeChangedEventArgs e)
            {
            double Xpos=-this.HorisontalPanel.ActualWidth/2;
            foreach (Node node in this.HorisontalPanel.Children)
                {
                this.NodeVisualObject.Margin = new Thickness(30, 30, 30, Math.Sqrt(e.NewSize.Width / 45) * 20);
                node.Edge.Y1 = -NodeVisualObject.Margin.Bottom - NodeVisualObject.Height / 2;
                node.Edge.Y2 = NodeVisualObject.Margin.Top + NodeVisualObject.Height / 2;
                Xpos += node.ActualWidth / 2;
                node.Edge.X2 = Xpos;
                double corner =  Math.Atan2(node.Edge.Y1 - node.Edge.Y2,node.Edge.X1 - node.Edge.X2)*180/Math.PI;
                if (corner < -90)
                    {
                    corner = 180 + corner;
                    node.EdgeCaption.RenderTransformOrigin = new Point(0, 0);
                    node.EdgeCaption.RenderTransform = new RotateTransform(corner);
                    Canvas.SetLeft(node.EdgeCaption, Xpos);
                    Canvas.SetTop(node.EdgeCaption, -20);
                    }
                else
                    {
                    node.EdgeCaption.RenderTransformOrigin = new Point(0, 1);
                    node.EdgeCaption.RenderTransform = new RotateTransform(corner);
                    Canvas.SetLeft(node.EdgeCaption, Xpos - 10);
                    Canvas.SetTop(node.EdgeCaption, 0);
                    }
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
                    TextBox edgeCaption = new TextBox() {Background = null, SelectionBrush = null, BorderBrush=Brushes.Gray};
                    Canvas.SetLeft(edgeCaption,  -5);
                    EdgeCanvas.Children.Add(edgeCaption);
                    new Node(HorisontalPanel, edge, edgeCaption);
                    break;
                case MouseButton.Right:
                    if (Edge!=null)
                        {
                        ParentPanel.Children.Remove(this);
                        ((Canvas)Edge.Parent).Children.Remove(Edge);
                        ((Canvas)EdgeCaption.Parent).Children.Remove(EdgeCaption);
                        }
                    break;
                }
            }

        public Node(StackPanel parentPanel, Line edge=null, TextBox edgeCaption=null)
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
                EdgeCaption = edgeCaption;
                } 
            }
        }
    }
