using System;
using System.Collections.Generic;
using System.Windows;

namespace Lab_6
{
    public partial class Window4 : Window
    {
        public Window4()
        {
            InitializeComponent();

            for(int i = 0; i < 5; i++)
            {
                switch (i)
                {
                    case 0: StructFill(ref cloth1, i + 1); break;
                    case 1: StructFill(ref cloth2, i + 1); break;
                    case 2: StructFill(ref cloth3, i + 1); break;
                    case 3: StructFill(ref cloth4, i + 1); break;
                    case 4: StructFill(ref cloth5, i + 1); break;
                }
            }
        }

        public struct Cloth
        {
            public int N = 0;
            public string Name = "not found";
            public string Material = "not found";
            public string ColorName = "not found";
            public int RollsN = 0;
            public float Width = 0.0F;
            public Dictionary<int, int> Price = new Dictionary<int, int>()
            {
                {1, 0},
                {2, 0},
                {3, 0}
            };
        }

        protected string[] clothNames = new string[] { "Silk", "Cotton", "Woolen" };
        protected string[,] clothMaterials = new string[,] { { "Silk", "Dupont", "Satin", "Crepe" }, { "Velour", "Denim", "Satin", "Jacquard" }, { "Felt", "Cashmere", "Batting", "Drape" } };
        protected string[] shades = new string[] { "Dark ", "", "Light " };
        protected string[] colors = new string[] { "Red", "Green", "Blue", "Purple", "Yellow", "Gray", "Orange", "Brown" };


        public Cloth cloth1 = new Cloth();
        public Cloth cloth2 = new Cloth();
        public Cloth cloth3 = new Cloth();
        public Cloth cloth4 = new Cloth();
        public Cloth cloth5 = new Cloth();


        protected void StructFill(ref Cloth cloth, int N)
        {
            Random rand = new Random();
            cloth.N = N;
            int tempI = rand.Next(3);
            cloth.Name = clothNames[tempI];
            cloth.Material = clothMaterials[tempI, rand.Next(4)];
            tempI = rand.Next(3);
            cloth.ColorName = shades[tempI] + colors[rand.Next(colors.Length)];

            cloth.RollsN = rand.Next(30);
            cloth.Width = (float)rand.Next(10, 100) / 10F;

            cloth.Price[1] = rand.Next(100, 1000);
            cloth.Price[2] = rand.Next(100, 1000);
            cloth.Price[3] = rand.Next(100, 1000);
        }


        protected bool StructSearch(ref Cloth cloth)
        {
            int Ntemp = 0;
            int priceTemp = 0;
            int rollsnTemp = 0;

            Int32.TryParse(N_IN.Text.Trim(), out Ntemp);
            if (Ntemp == cloth.N) return true;

            if (Name_IN.Text.Trim().ToLower() == cloth.Name.ToLower()) return true;
            if (Color_IN.Text.Trim().ToLower() == cloth.ColorName.ToLower()) return true;

            Int32.TryParse(RollsN_IN.Text.Trim(), out rollsnTemp);
            if (rollsnTemp == cloth.RollsN) return true;

            Int32.TryParse(Price_IN.Text.Trim(), out priceTemp);
            if (priceTemp >= cloth.Price[1] - 50 && priceTemp <= cloth.Price[1] + 50) return true;
            else if (priceTemp >= cloth.Price[2] - 50 && priceTemp <= cloth.Price[1] + 50) return true;
            else if (priceTemp >= cloth.Price[3] - 50 && priceTemp <= cloth.Price[1] + 50) return true;

            return false;
        }


        protected void PrintResult(ref Cloth cloth)
        {
            N_OUT.Text = cloth.N.ToString();
            Name_OUT.Text = cloth.Name;
            Material_OUT.Text = cloth.Material;

            Code_OUT.Text = cloth.ColorName.ToLower() + cloth.RollsN.ToString();
            AvPrice_OUT.Text = ((cloth.Price[1] + cloth.Price[2] + cloth.Price[3]) / 3).ToString();

            if (Color_IN.Text.ToLower() == cloth.ColorName.ToLower()) ColMatch_OUT.Text = "YES";
            else ColMatch_OUT.Text = "NO";
        }


        private void Search_btn_clk(object sender, RoutedEventArgs e)
        {
            if (StructSearch(ref cloth1)) { PrintResult(ref cloth1); return; }
            if (StructSearch(ref cloth2)) { PrintResult(ref cloth2); return; }
            if (StructSearch(ref cloth3)) { PrintResult(ref cloth3); return; }
            if (StructSearch(ref cloth4)) { PrintResult(ref cloth4); return; }
            if (StructSearch(ref cloth5)) { PrintResult(ref cloth5); return; }

            Cloth cloth0 = new Cloth();
            PrintResult(ref cloth0);
        }
    }
}
