
namespace Lab_5_2
{
    class Program
    {
        static void Task2(int[] vs, out int result)
        {
            result = 1;
            for(int i = 0; i < vs.Length; i++)
            {
                if (vs[i] == 0) break;
                result *= vs[i];
            }
        }


        static void Main()
        {
            int n = 0;
            int result = 0;
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
                if (Int32.TryParse(Console.ReadLine(), out n))
                {
                    vs = new int[n];
                    for (int i = 0; i < n; i++) vs[i] = random.Next(0 ,randMax);
                    break;
                }
            }
            currentAttempt = 0;

            if (vs == null)
            {
                Console.WriteLine("Завершение программы...");
                return;
            }

            Task2(vs, out result);

            Console.WriteLine("Массив: ");
            foreach (int v in vs) Console.Write(v + ", ");

            Console.WriteLine("\nПроизведение элементов, расположенных до первого, равного нулю: ");
            Console.WriteLine(result);
        }
    }
}