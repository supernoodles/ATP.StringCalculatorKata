namespace ATP.StringCalculatorKata.Source
{
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

        var customDelimiterPatternCheck = Regex.Match(numbers, "^//(.)\n", RegexOptions.IgnoreCase);
        var delimiters = new char[] {'\n', ','};

        if(customDelimiterPatternCheck.Success)
        {
            delimiters = customDelimiterPatternCheck.Groups[1].ToString().ToCharArray();
            numbers = numbers.Substring(customDelimiterPatternCheck.Length);
        }

        var operands = numbers.Split(delimiters);

        return operands.Sum(operand => operand.ToInt());
        }
    }

    internal static class StringExtensions
    {
        internal static int ToInt (this string number) => int.Parse(number);
    }
}