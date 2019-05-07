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

            return int.Parse(numbers);
        }
    }
}