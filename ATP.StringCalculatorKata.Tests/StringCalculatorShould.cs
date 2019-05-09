
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
        [TestCase("1,2,3", ExpectedResult = 6)]
        [TestCase("100,200,49", ExpectedResult = 349)]
        [TestCase("42,42,42", ExpectedResult = 126)]
        [TestCase("42,42,42,1,1", ExpectedResult = 128)]
        public int GivenACommaDelimitedListOfNumbers_ReturnExpectedSum(string numbers) =>
            calculator.Add(numbers);

        [Test]
        public void GivenStringWith1NewLine2_Return3()
        {
            var result = calculator.Add("1\n2");

            result.Should().Be(3);
        }

        [Test]
        public void GivenStringWith2NewLine3NewLine_Return100()
        {
            var result = calculator.Add("2\n3\n100");

            result.Should().Be(105);
        }

        [Test]
        public void GivenStringWith1Newline2Newline3Newline4_Return10()
        {
            var result = calculator.Add("1\n2\n3\n4");

            result.Should().Be(10);
        }
    }
}
