
namespace ATP.StringCalculatorKata.Tests
{
    using FluentAssertions;
    using NUnit.Framework;

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
    }

    public class StringCalculator
    {
        public int Add(string numbers)
        {
            return 0;
        }
    }
}
