using Xunit;

namespace Lab_8.Tests
{
    public class ArrayTests
    {
        [Fact]
        public void Sum_ResultIsNotNull()
        {
            Array array1 = new Array(3, 3);
            Array array2 = new Array(3, 3);

            var result = array1 + array2;

            Assert.NotNull(result);
        }

        [Fact]
        public void Sum_ResultIsCorrect()
        {
            double[,] doublesArray1 = new double[,] { { 1, 2, 3 }, { 1, 2, 3 }, { 1, 2, 3 } };
            double[,] doublesArray2 = new double[,] { { 4, 5, 6 }, { 4, 5, 6 }, { 4, 5, 6 } };
            double[,] expectedArray = new double[,] { { 5, 7, 9 }, { 5, 7, 9 }, { 5, 7, 9 } };
            Array array1 = new Array(doublesArray1);
            Array array2 = new Array(doublesArray2);
            Array expected = new Array(expectedArray);

            var result = array1 + array2;

            Assert.Equal(expected.Data, result.Data);
        }

        [Fact]
        public void Sum_ResultTypeIsCorrect()
        {
            Array array1 = new Array(3, 3);
            Array array2 = new Array(3, 3);

            var result = array1 + array2;

            Assert.IsType<Array>(result);
        }


        [Fact]
        public void Subtr_ResultIsNotNull()
        {
            Array array1 = new Array(3, 3);
            Array array2 = new Array(3, 3);

            var result = array1 - array2;

            Assert.NotNull(result);
        }

        [Fact]
        public void Subtr_ResultIsCorrect()
        {
            double[,] doublesArray1 = new double[,] { { 1, 2, 3 }, { 1, 2, 3 }, { 1, 2, 3 } };
            double[,] doublesArray2 = new double[,] { { 4, 5, 6 }, { 4, 5, 6 }, { 4, 5, 6 } };
            double[,] expectedArray = new double[,] { { -3, -3, -3 }, { -3, -3, -3 }, { -3, -3, -3 } };
            Array array1 = new Array(doublesArray1);
            Array array2 = new Array(doublesArray2);
            Array expected = new Array(expectedArray);

            var result = array1 - array2;

            Assert.Equal(expected.Data, result.Data);
        }

        [Fact]
        public void Subtr_ResultTypeIsCorrect()
        {
            Array array1 = new Array(3, 3);
            Array array2 = new Array(3, 3);

            var result = array1 - array2;

            Assert.IsType<Array>(result);
        }


        [Fact]
        public void Mult_ResultIsNotNull()
        {
            Array array = new Array(3, 3);
            double multiplier = 2;

            var result = array * multiplier;

            Assert.NotNull(result);
        }

        [Fact]
        public void Mult_ResultIsCorrect()
        {
            double[,] doublesArray = new double[,] { { 1, 2 }, { 3, 4 } };
            double multiplier = 2;
            double[,] expectedArray = new double[,] { { 2, 4 }, { 6, 8 } };
            Array array = new Array(doublesArray);
            Array expected = new Array(expectedArray);

            var result = array * multiplier;

            Assert.Equal(expected.Data, result.Data);
        }

        [Fact]
        public void Mult_ResultTypeIsCorrect()
        {
            Array array = new Array(3, 3);
            double multiplier = 2;

            var result = array * multiplier;

            Assert.IsType<Array>(result);
        }


        [Fact]
        public void ArrayMult_ResultIsNotNull()
        {
            Array array1 = new Array(3, 3);
            Array array2 = new Array(3, 3);

            var result = array1 * array2;

            Assert.NotNull(result);
        }

        [Fact]
        public void ArrayMult_ResultIsCorrect()
        {
            double[,] doublesArray1 = new double[,] { { 1, 2 }, { 3, 4 } };
            double[,] doublesArray2 = new double[,] { { 5, 6 }, { 7, 8 } };
            double[,] expectedArray = new double[,] { { 19, 22 }, { 43, 50 } };
            Array array1 = new Array(doublesArray1);
            Array array2 = new Array(doublesArray2);
            Array expected = new Array(expectedArray);

            var result = array1 * array2;

            Assert.Equal(expected.Data, result.Data);
        }

        [Fact]
        public void ArrayMult_ResultTypeIsCorrect()
        {
            Array array1 = new Array(3, 3);
            Array array2 = new Array(3, 3);

            var result = array1 * array2;

            Assert.IsType<Array>(result);
        }
    }
}