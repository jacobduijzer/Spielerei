using System;
namespace MultistageDocker.Domain
{
    public class Calculator : IAdd
    {
        public Calculator()
        {
        }

        public double Add(double a, double b) => a + b;
    }
}
