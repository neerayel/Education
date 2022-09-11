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

namespace Lab_7_1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Sum_CLK(object sender, RoutedEventArgs e)
        {
            double X = 0;
            double Y = 0;
            double Z = 0;

            double.TryParse(X1.Text, out X);
            double.TryParse(Y1.Text, out Y);
            double.TryParse(Z1.Text, out Z);
            Vector3 vector1 = new Vector3(X, Y, Z);

            double.TryParse(X2.Text, out X);
            double.TryParse(Y2.Text, out Y);
            double.TryParse(Z2.Text, out Z);
            Vector3 vector2 = new Vector3(X, Y, Z);

            Vector3 result = vector1 + vector2;
            XRes.Text = result.X.ToString();
            YRes.Text = result.Y.ToString();
            ZRes.Text = result.Z.ToString();
        }

        private void Mult_CLK(object sender, RoutedEventArgs e)
        {
            double X = 0;
            double Y = 0;
            double Z = 0;
            double n = 0;

            double.TryParse(X1.Text, out X);
            double.TryParse(Y1.Text, out Y);
            double.TryParse(Z1.Text, out Z);
            double.TryParse(N.Text, out n);

            Vector3 vector = new Vector3(X, Y, Z);

            Vector3 result = vector * n;
            XRes.Text = result.X.ToString();
            YRes.Text = result.Y.ToString();
            ZRes.Text = result.Z.ToString();
        }


        private void Length_CLK(object sender, RoutedEventArgs e)
        {
            double X = 0;
            double Y = 0;
            double Z = 0;
            string result;

            double.TryParse(X1.Text, out X);
            double.TryParse(Y1.Text, out Y);
            double.TryParse(Z1.Text, out Z);

            Vector3 vector = new Vector3(X, Y, Z);

            result = String.Format("{0:0.##}", vector.Length());

            V1Len.Text = result;
        }
    }
}
