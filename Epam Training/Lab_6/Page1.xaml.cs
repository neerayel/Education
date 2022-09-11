using System;
using System.Windows;
using System.Windows.Controls;

namespace Lab_6
{
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }


        static void Task1(int[] vs, int C, out int count)
        {
            count = 0;
            foreach (int v in vs) if (v < C) count++;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int nmax = 0;
            int n = 0;
            int C = 0;
            int count = 0;
            int[]? vs = null;

            Random random = new Random();
            int randMax = 10;


            Int32.TryParse(TB_1.Text, out nmax);
            if (nmax == 0)
            {
                nmax = 10;
                TB_1.Text = "10";
            }


            Int32.TryParse(TB_2.Text, out n);
            if (n == 0)
            {
                n = 10;
                TB_2.Text = "10";
            }

            vs = new int[n];
            for (int i = 0; i < n; i++) vs[i] = random.Next(randMax);


            TB_Result.Text = "";
            TB_Result.Text += "Массив: \n";
            foreach (int v in vs) TB_Result.Text += (v + ", ");

            if (Int32.TryParse(TB_3.Text, out C)) Task1(vs, C, out count);
            else
            {
                C = 5;
                TB_3.Text = "5";
            }

            TB_Result2.Text = "Count = " + count;
        }
    }
}
