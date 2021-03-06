﻿
namespace ATP.StringCalculatorKata.Tests
{
    using FluentAssertions;
    using NUnit.Framework;
    using Source;
    using System;

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

        [TestCase("1\n2", ExpectedResult = 3)]
        [TestCase("2\n3\n100", ExpectedResult = 105)]
        [TestCase("1\n2\n3\n4", ExpectedResult = 10)]
        public int GivenANewLineDelimitedListOfNumbers_ReturnExpectedSum(string numbers) =>
            calculator.Add(numbers);

        [TestCase("1\n2,3", ExpectedResult = 6)]
        [TestCase("11,2\n3", ExpectedResult = 16)]
        [TestCase("1\n2\n3,4", ExpectedResult = 10)]
        public int GivenListDelimitedWithNewlinesAndCommas_ReturnExpectedSum(string numbers) =>
            calculator.Add(numbers);

        [Test]
        public void GivenOneNumberAndTwoDelimiters_ReturnFormatException()
        {
            calculator
                .Invoking(sut => sut.Add("1,\n"))
                .Should().Throw<FormatException>();
        }

        [Test]
        public void WhenSemicolonDelimiter_Given1Semicolon2_Return3()
        {
            var input = "//;\n1;2";

            var result = calculator.Add(input);

            result.Should().Be(3);
        }

        [Test]
        public void WhenSemicolonDelimiter_Given1Semicolon2Semicolon5_Return8()
        {
            var input = "//;\n1;2;5";

            var result = calculator.Add(input);

            result.Should().Be(8);
        }

        [Test]
        public void WhenPipeDelimiter_Given1Pipe2Pipe5_Return8()
        {
            var input = "//|\n1|2|5";

            var result = calculator.Add(input);

            result.Should().Be(8);
        }

        [Test]
        public void GivenStringWithOneNegativeNumber_ReturnException()
        {
            var input = "-1";

            Assert.Throws<ArgumentException>(() => calculator.Add(input));
        }


    }
}
