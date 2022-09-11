using System;
using System.Windows;
using System.Windows.Controls;

namespace Lab_6
{
    public partial class Page3 : Page
    {
        public Page3()
        {
            InitializeComponent();
        }


        static void Task3(int[,] vs, int rows, int columns, out int result)
        {
            result = 0;
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    if (vs[i, j] == 0)
                    {
                        result = i + 1;
                        return;
                    }
                }
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int rows = 3;
            int columns = 0;

            int result = 0;
            int[,]? vs = null;

            Random random = new Random();
            int randMax = 0;

            Int32.TryParse(TB_1.Text, out randMax);
            if (randMax == 0)
            {
                randMax = 10;
                TB_1.Text = "10";
            }

            Int32.TryParse(TB_2.Text, out columns);
            if (columns == 0)
            {
                columns = 10;
                TB_2.Text = "10";
            }

            Int32.TryParse(TB_3.Text, out rows);
            if (rows == 0)
            {
                rows = 10;
                TB_3.Text = "10";
            }

            if (rows != 0 && columns != 0)
            {
                vs = new int[columns, rows];
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        vs[j, i] = random.Next(0, randMax);
                    }
                }
            }


            Task3(vs, rows, columns, out result);

            TB_Result.Text = "";
            TB_Result.Text += "Массив: \n";
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    TB_Result.Text += vs[j, i] + ", ";
                }
                TB_Result.Text += "\n";
            }

            TB_Result2.Text = "Результат - " + result;
        }
    }
}
