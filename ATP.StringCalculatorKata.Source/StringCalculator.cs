namespace ATP.StringCalculatorKata.Source
{
    using System.Linq;

    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers))
            {
                return 0;
            }

            var operands = numbers.Split(',');

            return operands.Sum(operand => int.Parse(operand));
        }
    }
}