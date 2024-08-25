namespace MyCalculator
{
    public class Calculator
    {
        public static int sum(int num1, int num2 )
        {
            if ( num1 < 0 || num2 < 0 )
            {
                return -1;
            }
            return num1 + num2;
        }

    }
}
