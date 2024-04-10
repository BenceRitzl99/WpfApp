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

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public double width=800;
        public double height=450;

        public int KattSzam = 0;
        public double OsszesIdo = 0;
        public DateTime Most;
        public MainWindow()
        {
            InitializeComponent();
            Canvas.SetLeft(Madar, 350);
            Canvas.SetTop(Madar, 160);

        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            /*MessageBox.Show("Rákattintottál!");
            double left = Canvas.GetLeft(Madar);

            Canvas.SetLeft(Madar, Canvas.GetLeft(Madar)+50);*/

            if (KattSzam == 0) Most= DateTime.Now;
            else
            {
                OsszesIdo += (DateTime.Now - Most).TotalMilliseconds;
                Most = DateTime.Now;
            }
            Random rnd = new Random();

            Canvas.SetLeft(Madar,rnd.Next(0,(int)width-100));
            Canvas.SetTop(Madar,rnd.Next(0,(int)height-100));
            KattSzam++;
            if (KattSzam == 10) {
                MessageBox.Show(OsszesIdo / 10 + "msec az átlagod!");
                KattSzam = 0;
                OsszesIdo = 0;
            }

        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            // MessageBox.Show("Átméreteztél!");
            width = e.NewSize.Width;
            height = e.NewSize.Height;
            lblMessage.Width = width;

            double mostLeft = Canvas.GetLeft(Madar);
            if (mostLeft > width - 130)
            {
                Canvas.SetLeft(Madar, width - 100);
            }

            double mostTop = Canvas.GetTop(Madar);
            if (mostTop > height - 130)
            {
                Canvas.SetTop(Madar, height - 100);

            }
        }
    }
}
