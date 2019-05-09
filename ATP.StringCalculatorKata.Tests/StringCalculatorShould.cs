
namespace ATP.StringCalculatorKata.Tests
{
    using FluentAssertions;
    using NUnit.Framework;
    using Source;

    [TestFixture]
    public class StringCalculatorShould
    {
        private StringCalculator calculator;

        [SetUp]
        public void Setup()
        {
            calculator = new StringCalculator();
        }

        [Test]
        public void GivenEmptyString_Return0()
        {
            var result = calculator.Add("");

            result.Should().Be(0);
        }

        [Test]
        public void GivenStringOf1_Return1()
        {
            var result = calculator.Add("1");

            result.Should().Be(1);
        }

        [Test]
        public void GivenStringOf100_Return100()
        {
            var result = calculator.Add("100");

            result.Should().Be(100);
        }

        [Test]
        public void GivenStringOf42_Return42()
        {
            var result = calculator.Add("42");

            result.Should().Be(42);
        }

        [Test]
        public void GivenStringOf1Comma2_Return3()
        {
            var result = calculator.Add("1,2");

            result.Should().Be(3);
        }

        [Test]
        public void GivenStringOf2Comma3_Return5()
        {
            var result = calculator.Add("2,3");

            result.Should().Be(5);
        }
    }
}
