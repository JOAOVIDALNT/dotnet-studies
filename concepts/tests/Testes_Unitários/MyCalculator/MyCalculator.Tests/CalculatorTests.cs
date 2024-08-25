namespace MyCalculator.Tests
{
    public class CalculatorTests
    {
        [Fact(DisplayName = "Given valid numbers, when sum then should then should success.")]
        public void GivenValidNumbers_WhenSum_ThenShouldSuccess()
        {
            // ARRANGE
            const int resultExpecte = 5;
            const int firstNumber = 2;
            const int secondNumber = 3;

            // ACT
            var resultActual = Calculator.sum(firstNumber, secondNumber);

            // ASSERT
            Assert.Equal(resultExpecte, resultActual);
        }
    }
}