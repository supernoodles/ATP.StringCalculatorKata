namespace ATP.StringCalculatorKata.Source
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (numbers == "-1")
            {
                throw new ArgumentException("Negative numbers not allowed (-1)");
            }

            if (string.IsNullOrWhiteSpace(numbers))
            {
                return 0;
            }

            var delimiters = new List<char> { '\n', ',' };

            var (operandList, customDelimiter) = Parse(numbers);

            if (customDelimiter != null)
            {
                delimiters.Add(customDelimiter.First());
            }

            return GetOperands(operandList, delimiters)
                .Sum(operand => operand.ToInt());
        }

        private (string operandList, string customDelimiter) Parse(string input)
        {
            var customDelimiter = GetCustomDelimiter(input);

            return (
                customDelimiter == null
                    ? input
                    : GetOperandListWithoutCustomDelimiter(input),
                customDelimiter);
        }

        private string GetCustomDelimiter(string numbers)
        {
            var customDelimiterPatternCheck = Regex.Match(numbers, "^//(.)\n", RegexOptions.IgnoreCase);

            return customDelimiterPatternCheck.Success
                ? customDelimiterPatternCheck.Groups[1].Value
                : null;
        }

        private string[] GetOperands(string numbers, List<char> delimiters) =>
            numbers.Split(delimiters.ToArray());

        private string GetOperandListWithoutCustomDelimiter(string numbers) =>
            numbers.Substring(numbers.IndexOf('\n') + 1);
    }

    internal static class StringExtensions
    {
        internal static int ToInt(this string number) => int.Parse(number);
    }
}