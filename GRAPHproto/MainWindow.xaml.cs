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
using System.IO;

namespace GRAPHproto
    {
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
        {
        private Node root;
        private Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog() { DefaultExt = ".png", Filter = "Png Images (.png)|*.png" };

        public MainWindow()
            {
            InitializeComponent();
            root=new Node(RootPanel);
            }

        private void CopyImg(object sender, RoutedEventArgs e)
            {
            root.SetTextBoxBrushRecursive(null);
            bool? result=dlg.ShowDialog();
            if (result==true)
                {
                RenderTargetBitmap Bitmap = new RenderTargetBitmap((int)RootPanel.ActualWidth*4, (int)RootPanel.ActualHeight*4, 386, 386, PixelFormats.Pbgra32);
                Bitmap.Render(RootPanel);
                PngBitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Interlace = PngInterlaceOption.On;
                encoder.Frames.Add(BitmapFrame.Create(Bitmap));
                var stream = new FileStream(dlg.FileName, FileMode.Create);
                encoder.Save(stream);
                stream.Close();
                }
            root.SetTextBoxBrushRecursive(Brushes.Gray);
            }
        }
    }
