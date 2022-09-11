using Xunit;

namespace Lab_7_2.Tests
{
    public class PolynomialTests
    {
        [Fact]
        public void TextView_NotNull()
        {
            Polynomial pol = new Polynomial("x^3 + 3x^2 + 5x + 2", 'x');

            Assert.NotNull(pol.TextView_Original());
            Assert.NotNull(pol.TextView_AfterSum());
        }

        [Fact]
        public void TextView_NotEmptyString()
        {
            Polynomial pol = new Polynomial(" ", 'x');

            Assert.Equal("0", pol.TextView_Original());
            Assert.Equal("0", pol.TextView_AfterSum());
        }

        [Fact]
        public void Sum_IsNotNull()
        {
            Polynomial pol = new Polynomial("x^3 + 3x^2 + 5x + 2", 'x');

            var result = pol + pol;

            Assert.NotNull(result);
        }

        [Fact]
        public void Sum_IsResultCorrect()
        {
            Polynomial pol = new Polynomial("x^3 + 3x^2 + 5x + 2", 'x');
            Polynomial expected = new Polynomial("2x^3 + 6x^2 + 10x + 4", 'x');

            var result = pol + pol;

            Assert.Equal(expected.TextView_AfterSum(), result.TextView_AfterSum());
        }

        [Fact]
        public void Sum_IsResultTypeCorrect()
        {
            Polynomial pol = new Polynomial("x^3 + 3x^2 + 5x + 2", 'x');

            var result = pol + pol;

            Assert.IsType<Polynomial>(result);
        }

        [Fact]
        public void Subtr_IsNotNull()
        {
            Polynomial pol = new Polynomial("x^3 + 3x^2 + 5x + 2", 'x');

            var result = pol - pol;

            Assert.NotNull(result);
        }

        [Fact]
        public void Subtr_IsResultCorrect()
        {
            Polynomial pol1 = new Polynomial("2x^3 + 6x^2 + 10x + 4", 'x');
            Polynomial pol2 = new Polynomial("x^3 + 3x^2 + 5x + 2", 'x');
            Polynomial expected = new Polynomial("x^3 + 3x^2 + 5x + 2", 'x');

            var result = pol1 - pol2;

            Assert.Equal(expected.TextView_AfterSum(), result.TextView_AfterSum());
        }

        [Fact]
        public void Subtr_IsResultTypeCorrect()
        {
            Polynomial pol = new Polynomial("x^3 + 3x^2 + 5x + 2", 'x');

            var result = pol - pol;

            Assert.IsType<Polynomial>(result);
        }

        [Fact]
        public void Mult_IsNotNull()
        {
            Polynomial pol = new Polynomial("x^3 + 3x^2 + 5x + 2", 'x');

            var result = pol * pol;

            Assert.NotNull(result);
        }

        [Fact]
        public void Mult_IsResultCorrect()
        {
            Polynomial pol1 = new Polynomial("3x^2 + 5x + 2", 'x');
            Polynomial pol2 = new Polynomial("2x^3 + 10x + 4", 'x');
            Polynomial expected = new Polynomial("6x^5 + 10x^4 + 34x^3 + 62x^2 + 40x + 8", 'x');

            var result = pol1 * pol2;

            Assert.Equal(expected.TextView_AfterSum(), result.TextView_AfterSum());
        }

        [Fact]
        public void Mult_IsResultTypeCorrect()
        {
            Polynomial pol = new Polynomial("x^3 + 3x^2 + 5x + 2", 'x');

            var result = pol * pol;

            Assert.IsType<Polynomial>(result);
        }
    }
}