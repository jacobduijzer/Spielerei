using System;
namespace MultistageDocker.UnitTests
{
    public class CalculatorShould
    {
        public CalculatorShould()
        {
        }

        [Fact]
        public void Construct() =>
            new Calculator().Should().BeOfType<Calculator>();

        [Fact]
        public void ImplementAddInterface() =>
            new Calculator().Should().Implement<IAdd>();
    }
}
