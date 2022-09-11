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

namespace Lab_8
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private double[,] TestArray1Fill()
        {
            double[,] testData = new double[3, 3];
            double.TryParse(InpArray1_1.Text, out testData[0, 0]);
            double.TryParse(InpArray1_2.Text, out testData[0, 1]);
            double.TryParse(InpArray1_3.Text, out testData[0, 2]);
            double.TryParse(InpArray1_4.Text, out testData[1, 0]);
            double.TryParse(InpArray1_5.Text, out testData[1, 1]);
            double.TryParse(InpArray1_6.Text, out testData[1, 2]);
            double.TryParse(InpArray1_7.Text, out testData[2, 0]);
            double.TryParse(InpArray1_8.Text, out testData[2, 1]);
            double.TryParse(InpArray1_9.Text, out testData[2, 2]);
            return testData;
        }

        private double[,] TestArray2Fill()
        {
            double[,] testData = new double[3, 3];
            double.TryParse(InpArray2_1.Text, out testData[0, 0]);
            double.TryParse(InpArray2_2.Text, out testData[0, 1]);
            double.TryParse(InpArray2_3.Text, out testData[0, 2]);
            double.TryParse(InpArray2_4.Text, out testData[1, 0]);
            double.TryParse(InpArray2_5.Text, out testData[1, 1]);
            double.TryParse(InpArray2_6.Text, out testData[1, 2]);
            double.TryParse(InpArray2_7.Text, out testData[2, 0]);
            double.TryParse(InpArray2_8.Text, out testData[2, 1]);
            double.TryParse(InpArray2_9.Text, out testData[2, 2]);
            return testData;
        }

        private void PrintResult(double[,] resData)
        {
            Result_1.Text = resData[0, 0].ToString();
            Result_2.Text = resData[0, 1].ToString();
            Result_3.Text = resData[0, 2].ToString();
            Result_4.Text = resData[1, 0].ToString();
            Result_5.Text = resData[1, 1].ToString();
            Result_6.Text = resData[1, 2].ToString();
            Result_7.Text = resData[2, 0].ToString();
            Result_8.Text = resData[2, 1].ToString();
            Result_9.Text = resData[2, 2].ToString();
        }

        private void BtnClk_Sum(object sender, RoutedEventArgs e)
        {
            double[,] test1 = TestArray1Fill();
            double[,] test2 = TestArray2Fill();
            Array array1 = new Array(test1);
            Array array2 = new Array(test2);

            var result = array1 + array2;

            PrintResult(result.Data);
        }

        private void BtnClk_Subtr(object sender, RoutedEventArgs e)
        {
            double[,] test1 = TestArray1Fill();
            double[,] test2 = TestArray2Fill();
            Array array1 = new Array(test1);
            Array array2 = new Array(test2);

            var result = array1 - array2;

            PrintResult(result.Data);
        }

        private void BtnClk_Mult(object sender, RoutedEventArgs e)
        {
            double[,] test1 = TestArray1Fill();
            double[,] test2 = TestArray2Fill();
            Array array1 = new Array(test1);
            Array array2 = new Array(test2);

            var result = array1 * array2;

            PrintResult(result.Data);
        }
    }
}
