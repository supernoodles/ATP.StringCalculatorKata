namespace ATP.StringCalculatorKata.Source
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers))
            {
                return 0;
            }

            var operands = numbers.Split(',');

            if (operands.Length == 2)
            {
                return operands[0].ToInt() + operands[1].ToInt();
            }

            if (operands.Length == 3)
            {
                return  operands[0].ToInt() + operands[1].ToInt() + operands[2].ToInt();
            }

            return int.Parse(numbers);
        }
    }

    internal static class StringExtensions
    {
        internal static int ToInt (this string number) => int.Parse(number);
    }
}