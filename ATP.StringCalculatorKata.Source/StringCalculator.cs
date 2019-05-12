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

            var operands = GetOperands(operandList, delimiters)
                .Select(operand => operand.ToInt())
                .ToList();

            CheckForNegativeNumbers(operands);

            return operands.Sum();
        }

        private void CheckForNegativeNumbers(List<int> operands)
        {
            var negativeOperands = operands.Where(operand => operand < 0).ToList();

            if (negativeOperands.Any())
            {
                throw new ArgumentException($"Negatives not allowed {string.Join(",", negativeOperands)}");
            }
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