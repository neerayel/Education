
namespace Lab_3
{
    class Program
    {
        static void Main()
        {
            int answer = 3;
            int answersCounter = 0;
            int maxIncorrectAnswers = 5;

            while (answersCounter < maxIncorrectAnswers)
            {
                Console.Clear();
                Console.WriteLine(" Выберите задание (введите число 1 или 2)");
                Console.WriteLine(" Введите 0 чтобы завершить работу программы");
                Console.WriteLine(" | после {0} некорректных ответов программа завершится |\n", maxIncorrectAnswers - answersCounter);

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
                        Console.WriteLine(" | Выбрано задание 1 |\n");
                        TaskSolution.Task1();
                        Console.WriteLine("\n | Завершено. Нажмите лювую клавишу чтобы продолжить |");
                        break;

                    case 2:
                        answersCounter = 0;
                        Console.WriteLine(" | Выбрано задание 2 |\n");
                        TaskSolution.Task2();
                        Console.WriteLine("\n | Завершено. Нажмите лювую клавишу чтобы продолжить |");
                        break;

                    case 5:
                        answersCounter = 0;
                        Console.WriteLine(" | Выбрано факториал тест |\n");
                        Console.CursorLeft = 8;
                        int testF = Convert.ToInt32(Console.ReadLine());
                        Console.CursorLeft = 8;
                        Console.WriteLine(TaskSolution.Factorial(testF));
                        Console.WriteLine("\n | Завершено. Нажмите лювую клавишу чтобы продолжить |");
                        break;

                    case 0:
                        return;

                    default:
                        Console.WriteLine(" | нужно ввести 1 или 2 |");
                        Console.WriteLine(" | Нажмите лювую клавишу чтобы продолжить |");
                        answersCounter++;
                        break;
                }
                Console.ReadKey();
            }
        }
    }
}