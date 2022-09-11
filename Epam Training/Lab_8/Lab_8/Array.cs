
using System;

namespace Lab_8
{
    public class Array
    {
        public double[,] Data { get; } = new double[,] {};


        public Array(int x, int y) // если на вход идет сколько на сколько должен быть массив, то заоплняется он рандомными числами
        {
            double[,] randData = new double[x, y];
            Random rand = new Random();

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    randData[i, j] = Math.Round(rand.NextDouble() * 10, 2);
                }
            }

            this.Data = randData;
        }

        public Array(double[,] customData)
        {
            this.Data = customData;
        }


        protected static double[,] Sum(double[,] data1, double[,] data2)
        {
            int x = data1.GetLength(0);
            int y = data1.GetLength(1);

            if (x != data2.GetLength(0) || y != data2.GetLength(1))
            {
                throw new ArgumentException("Summation can only be applied to arrays of the same size");
            }

            double[,] res = new double[x, y];

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    res[i, j] = data1[i, j] + data2[i, j];
                }
            }

            return res;
        }


        protected static double[,] Subtr(double[,] data1, double[,] data2)
        {
            int x = data1.GetLength(0);
            int y = data1.GetLength(1);

            if (x != data2.GetLength(0) || y != data2.GetLength(1))
            {
                throw new ArgumentException("Subtraction can only be applied to arrays of the same size");
            }

            double[,] res = new double[x, y];

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    res[i, j] = data1[i, j] - data2[i, j];
                }
            }

            return res;
        }


        protected static double[,] MuliplierMult(double[,] data1, double multiplier)
        {
            int x = data1.GetLength(0);
            int y = data1.GetLength(1);

            double[,] res = new double[x, y];

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    res[i, j] = data1[i, j] * multiplier;
                }
            }

            return res;
        }


        protected static double[,] ArrayMult(double[,] data1, double[,] data2)
        {
            int xRes = data1.GetLength(0);
            int yRes = data2.GetLength(1);

            int n  = data1.GetLength(1);
            double[,] res = new double[xRes, yRes];

            for (int i = 0; i < xRes; i++)
            {
                for (int j = 0; j < yRes; j++)
                {
                    double tempSum = 0;
                    for (int s = 0; s < n; s++) tempSum += data1[i, s] * data2[s, j];
                    res[i, j] = tempSum;
                }
            }

            return res;
        }


        public static Array operator +(Array array1, Array array2)
        {
            double[,] result = Sum(array1.Data, array2.Data);
            return new Array(result);
        }


        public static Array operator -(Array array1, Array array2)
        {
            double[,] result = Subtr(array1.Data, array2.Data);
            return new Array(result);
        }


        public static Array operator *(Array array1, double multiplier)
        {
            double[,] result = MuliplierMult(array1.Data, multiplier);
            return new Array(result);
        }


        public static Array operator *(Array array1, Array array2)
        {
            double[,] result = ArrayMult(array1.Data, array2.Data);
            return new Array(result);
        }
    }
}
