using System;
using System.Windows;
using System.Windows.Controls;

namespace Lab_6
{
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
        }

        static void Task2(int[] vs, out int result)
        {
            result = 1;
            for (int i = 0; i < vs.Length; i++)
            {
                if (vs[i] == 0) break;
                result *= vs[i];
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int n = 0;
            int result = 0;
            int[]? vs = null;

            Random random = new Random();
            int randMax = 0;


            Int32.TryParse(TB_1.Text, out randMax);
            if(randMax == 0)
                {
                randMax = 10;
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

            Task2(vs, out result);

            TB_Result2.Text = "Count = " + result;
        }
    }
}
