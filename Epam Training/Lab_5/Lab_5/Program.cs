
namespace Lab_5
{
    class Program
    {
        static void Task1(int[] vs, int C, out int count)
        {
            count = 0;
            foreach (int v in vs) if (v < C) count++;
        }


        static void Main()
        {
            int n = 0;
            int C = 0;
            int count = 0;
            int[]? vs = null;

            Random random = new Random();
            int randMax = 10;

            int maxAttempts = 5;
            int currentAttempt = 0;

            for (; currentAttempt < maxAttempts; currentAttempt++)
            {
                Console.Clear();
                Console.WriteLine("{0} попыток ввода", maxAttempts - currentAttempt);
                Console.WriteLine("Cтандартное значение - 10");
                Console.WriteLine("Введите максимальное значение элементов массива: ");
                int temp;
                if (Int32.TryParse(Console.ReadLine(), out temp))
                {
                    randMax = temp;
                    break;
                }
            }
            currentAttempt = 0;

            for (; currentAttempt < maxAttempts; currentAttempt++)
            {
                Console.Clear();
                Console.WriteLine("{0} попыток ввода", maxAttempts - currentAttempt);
                Console.WriteLine("Введите количество элементов массива: ");
                if(Int32.TryParse(Console.ReadLine(), out n))
                {
                    vs = new int[n];
                    for (int i = 0; i < n; i++) vs[i] = random.Next(randMax);
                    break;
                }
            }
            currentAttempt = 0;

            if(vs == null)
            {
                Console.WriteLine("Завершение программы...");
                return;
            }

            for (; currentAttempt < maxAttempts; currentAttempt++)
            {
                Console.Clear();
                Console.WriteLine("{0} попыток ввода", maxAttempts - currentAttempt);
                Console.WriteLine("Массив: ");
                foreach(int v in vs) Console.Write(v + ", ");
                Console.WriteLine("\n\nВведите С: ");
                if (Int32.TryParse(Console.ReadLine(), out C))
                {
                    Task1(vs, C, out count);
                    break;
                }
            }

            if (C == 0)
            {
                Console.WriteLine("Завершение программы...");
                return;
            }

            Console.WriteLine("\nКоличество элементов массива, меньших C: ");
            Console.WriteLine(count);
        }
    }
}