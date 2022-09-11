
namespace Lab_4
{
    class Program
    {
        public static void Input( int answersCounter, int maxIncorrectAnswers, out int a, out int b, string N)
        {
            a = 0;
            b = 0;
            while (answersCounter < maxIncorrectAnswers)
            {
                Console.Clear();
                Console.WriteLine(" | после {0} некорректных ответов программа завершится |\n", maxIncorrectAnswers - answersCounter);
                Console.WriteLine(" {0} комплексное число:", N);

                try
                {
                    Console.WriteLine(" Введите а:");
                    Console.CursorLeft = 1;
                    a = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine(" Введите b:");
                    Console.CursorLeft = 1;
                    b = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine(" | на ввод принимаются только целые числа |");
                    answersCounter++;
                    Console.WriteLine(" | Нажмите лювую клавишу чтобы продолжить |");
                    Console.ReadKey();
                    continue;
                }
            }
        }

        public static void PrintResult(CNum result)
        {
            Console.CursorLeft = 4;
            Console.WriteLine(" Результат: {0}", result.Print());
            Console.WriteLine("\n | Завершено. Нажмите лювую клавишу чтобы продолжить |");
        }


        static void Main()
        {
            int answer = 4;
            int answersCounter = 0;
            int maxIncorrectAnswers = 5;
            int a;
            int b;


            Input(answersCounter, maxIncorrectAnswers, out a, out b, "Первое");
            CNum cNumA = new(a, b);

            Input(answersCounter, maxIncorrectAnswers, out a, out b, "Второе");
            CNum cNumB = new(a, b);

            CNum result;

            while (answersCounter < maxIncorrectAnswers)
            {
                Console.Clear();
                Console.WriteLine(" Первое комплексное число: {0}", cNumA.Print());
                Console.WriteLine(" Второе комплексное число: {0}", cNumB.Print());
                Console.WriteLine("\n Выберите действие:\n 1.Сложение\n 2.Вычитание\n 3.Умножение");
                Console.WriteLine("\n Введите 0 чтобы завершить работу программы");
                Console.WriteLine("\n | после {0} некорректных ответов программа завершится |\n", maxIncorrectAnswers - answersCounter);

                try
                {
                    Console.CursorLeft = 1;
                    answer = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine(" | на ввод принимаются только целые числа |");
                    answersCounter++;
                    Console.WriteLine(" | Нажмите лювую клавишу чтобы продолжить |");
                    Console.ReadKey();
                    continue;
                }

                switch (answer)
                {
                    case 1:
                        answersCounter = 0;
                        Console.WriteLine(" | Сложение комплексных чисел |\n");
                        result = cNumA.Add(cNumB);
                        PrintResult(result);
                        break;

                    case 2:
                        answersCounter = 0;
                        Console.WriteLine(" | Вычитание комплексных чисел |\n");
                        result = cNumA.Subt(cNumB);
                        PrintResult(result);
                        break;

                    case 3:
                        answersCounter = 0;
                        Console.WriteLine(" | Умножение комплексных чисел |\n");
                        result = cNumA.Mult(cNumB);
                        PrintResult(result);
                        break;

                    case 0:
                        return;

                    default:
                        Console.WriteLine(" | нужно ввести 1, 2 или 3 |");
                        Console.WriteLine(" | Нажмите лювую клавишу чтобы продолжить |");
                        answersCounter++;
                        break;
                }
                Console.ReadKey();
            }
        }
    }
}