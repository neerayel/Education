
using System;
using Xunit;

namespace Lab_7_1.Tests
{
    public class Vector3Tests
    {
        [Fact]
        public void Summation_IsResultANewVector3()
        {
            // Arrange
            Vector3 vector1 = new Vector3();
            Vector3 vector2 = new Vector3();

            // Act
            var result = vector1 + vector2;

            // Assert
            Assert.IsType<Vector3>(result);
        }

        [Fact]
        public void Summation_IsResultCorrect()
        {
            // Arrange
            Vector3 vector1 = new Vector3(5, 10, 15);
            Vector3 vector2 = new Vector3(9, 6, 3);
            Vector3 expected = new Vector3(14, 16, 18);

            // Act
            var result = vector1 + vector2;

            // Assert
            Assert.Equal(expected.X, result.X);
            Assert.Equal(expected.Y, result.Y);
            Assert.Equal(expected.Z, result.Z);
        }

        [Fact]
        public void Summation_IsResultTypeCorrect()
        {
            // Arrange
            Vector3 vector1 = new Vector3(1, 1, 1);
            Vector3 vector2 = new Vector3(1, 1, 1);
            Vector3 expected = new Vector3(1, 1, 1);

            // Act
            var result = vector1 + vector2;

            // Assert
            Assert.Equal(expected.X.GetType(), result.X.GetType());
            Assert.Equal(expected.Y.GetType(), result.Y.GetType());
            Assert.Equal(expected.Z.GetType(), result.Z.GetType());
        }

        [Fact]
        public void Multiplication_IsResultANewVector3()
        {
            // Arrange
            Vector3 vector1 = new Vector3();
            double testNumber = 5;
            Vector3 expected = new Vector3(1, 1, 1);

            // Act
            var result = vector1 * testNumber;

            // Assert
            Assert.IsType<Vector3>(result);
        }

        [Fact]
        public void Multiplication_IsResultCorrect()
        {
            // Arrange
            Vector3 vector1 = new Vector3(5, 10, 15);
            double testNumber = 5;
            Vector3 expected = new Vector3(25, 50, 75);

            // Act
            var result = vector1 * testNumber;

            // Assert
            Assert.Equal(expected.X, result.X);
            Assert.Equal(expected.Y, result.Y);
            Assert.Equal(expected.Z, result.Z);
        }

        [Fact]
        public void Multiplication_IsResultTypeCorrect_intIn_doubleOut()
        {
            // Arrange
            Vector3 vector1 = new Vector3(5, 10, 15);
            int testNumber = 5;
            Vector3 expected = new Vector3(14, 16, 18);

            // Act
            var result = vector1 * testNumber;

            // Assert
            Assert.Equal(expected.X.GetType(), result.X.GetType());
            Assert.Equal(expected.Y.GetType(), result.Y.GetType());
            Assert.Equal(expected.Z.GetType(), result.Z.GetType());
        }

        [Fact]
        public void Multiplication_IsResultTypeCorrect_floatIn_doubleOut()
        {
            // Arrange
            Vector3 vector1 = new Vector3(5, 10, 15);
            float testNumber = 5.0F;
            Vector3 expected = new Vector3(14, 16, 18);

            // Act
            var result = vector1 * testNumber;

            // Assert
            Assert.Equal(expected.X.GetType(), result.X.GetType());
            Assert.Equal(expected.Y.GetType(), result.Y.GetType());
            Assert.Equal(expected.Z.GetType(), result.Z.GetType());
        }

        [Fact]
        public void Vector_IsLengthCorrect()
        {
            // Arrange
            Vector3 vector = new Vector3(5, 5, 5);
            double len = vector.Length();
            double expected = 8.66;
            
            // Act
            var result = Math.Round(len, 2);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}