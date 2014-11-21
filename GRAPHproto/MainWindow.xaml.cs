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
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>

    
    public partial class MainWindow : Window
        {
        private Node root;

        public MainWindow()
            {
            InitializeComponent();
            root=new Node(RootPanel);
            Node Node1 = root.AddChild();
            Node Node2 = root.AddChild();
            Node Node3 = Node1.AddChild();
            Node Node4 = Node1.AddChild();
            Node Node5 = Node1.AddChild();
            Node Node6 = Node1.AddChild();
            }
        }
    }
