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
                return int.Parse(operands[0]) + int.Parse(operands[1]);
            }

            return int.Parse(numbers);
        }
    }
}