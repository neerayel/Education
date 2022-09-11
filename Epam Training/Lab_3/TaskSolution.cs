
namespace Lab_3
{
    internal class TaskSolution
    {
        public static void Task1()
        {
            double R = 3;
            double f = 0;
            double x = 0;

            Console.WriteLine("\tВведите -10 <= x <= 8");
            try
            {
                Console.CursorLeft = 8;
                x = Convert.ToDouble(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("\tНеверный ввод");
                return;
            }

            if (x >= -10 && x <= -8) f = -3;
            else if (x >= -8 && x <= -3) f = (x + 3) / 1.666;
            else if (x >= -3 && x <= 3) f = -Math.Sqrt(Math.Pow(R, 2) - Math.Pow(x, 2));
            else if (x >= 3 && x <= 5) f = x - 3;
            else f = 3;

            Console.WriteLine("\tДля x=" + x);
            Console.WriteLine("\tf={0}", f);
        }


        public static double Factorial(int n)
        {
            if (n == 1 || n == 0) return 1;

            double result = 1;
            for(int i = n; i > 1; i--)
            {
                result *= i;
            }

            return result;
        }


        public static void Task2()
        {
            double result = 0;
            int xStart;
            int xEnd;
            int step;
            double eps;

            string header = "\t|  {0,3}  |  {1,10}  |  {2,5}  |";
            string tableRow = "\t|  {0,3}  |  {1,10:F5}  |  {2,5}  |";

            try
            {
                Console.WriteLine("\tВведите начальное значение х");
                Console.CursorLeft = 8;
                xStart = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("\n\tВведите конечное значение х");
                Console.CursorLeft = 8;
                xEnd = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("\n\tВведите шаг dx");
                Console.CursorLeft = 8;
                step = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("\n\tВведите точность eps");
                Console.CursorLeft = 8;
                eps = Convert.ToDouble(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("\tНеверный ввод");
                return;
            }

            Console.WriteLine("\n\t Значения функции");
            Console.WriteLine(header, "x", "y", "count");
            Console.Write("\t");
            for (int i = 0; i <= header.Length; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();

            for (int i = xStart; i <= xEnd; i += step)
            {
                int count = 0;
                int n = i;
                double tempDiv = 0;

                do
                {
                    count++;
                    result += tempDiv;

                    tempDiv = (Math.Pow(i, n) * -1) / Factorial(n);

                    n++;
                }
                while (Math.Abs(tempDiv) >= eps);

                Console.WriteLine(tableRow, i, result, count);
            }
        }
    }

}
