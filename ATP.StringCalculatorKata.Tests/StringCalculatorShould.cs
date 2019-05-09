
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

        [TestCase("1", ExpectedResult = 1)]
        [TestCase("100", ExpectedResult = 100)]
        [TestCase("42", ExpectedResult = 42)]
        public int GivenStringWithOneNumber_ReturnThatNumber(string number) =>
            calculator.Add(number);

        [TestCase("1,2", ExpectedResult = 3)]
        [TestCase("2,3", ExpectedResult = 5)]
        [TestCase("250,40", ExpectedResult = 290)]
        public int GivenStringOfNumberCommaNumber_ReturnExpectedResult(string numbers) =>
            calculator.Add(numbers);

        [Test]
        public void GivenStringOf1Comma2Comma3_Return6()
        {
            var result = calculator.Add("1,2,3");

            result.Should().Be(6);
        }

        [Test]
        public void GivenStringOf100Comma200Comma49_Return349()
        {
            var result = calculator.Add("100,200,49");

            result.Should().Be(349);
        }

        [Test]
        public void GivenStringOf42Comma42Comma42_Return126()
        {
            var result = calculator.Add("42,42,42");

            result.Should().Be(126);
        }
    }
}
