
namespace ATP.StringCalculatorKata.Tests
{
    using FluentAssertions;
    using NUnit.Framework;
    using Source;

    [TestFixture]
    public class StringCalculatorShould
    {
        [Test]
        public void GivenEmptyString_Return0()
        {
            var  calculator = new StringCalculator();
            var result = calculator.Add("");
            result.Should().Be(0);
        }

        [Test]
        public void GivenStringOf1_Return1()
        {
            var calculator = new StringCalculator();
            var result = calculator.Add("1");
            result.Should().Be(1);
        }
    }
}
