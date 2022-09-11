
namespace Lab_5_3
{
    class Program
    {
        static void Task3(int[,] vs, int rows, int columns, out int result)
        {
            result = 0;
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    if(vs[i, j] == 0)
                    {
                        result = i+1;
                        return;
                    }
                }
            }
        }


        static void Main()
        {
            int rows = 3;
            int columns = 0;

            int result = 0;
            int[,]? vs = null;

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


                Console.WriteLine("Введите количество столбцов массива: ");
                Int32.TryParse(Console.ReadLine(), out columns);

                Console.WriteLine("Введите количество строк массива: ");
                Int32.TryParse(Console.ReadLine(), out rows);


                if (rows != 0 && columns != 0)
                {
                    vs = new int[columns, rows];
                    for (int i = 0; i < columns; i++)
                    {
                        for (int j = 0; j < rows; j++)
                        {
                            vs[i, j] = random.Next(0, randMax);
                        }
                    }
                    break;
                }
            }
            currentAttempt = 0;

            if (vs == null)
            {
                Console.WriteLine("Завершение программы...");
                return;
            }

            Task3(vs, rows, columns, out result);

            Console.WriteLine("\nМассив: ");
            for(int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(vs[j, i] + ", ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\nПервый столбец, содержащий 0: ");
            Console.WriteLine(result);
        }
    }
}