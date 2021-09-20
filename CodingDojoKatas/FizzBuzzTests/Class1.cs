using Katas;
using NUnit.Framework;

namespace FizzBuzzTests
{
    [TestFixture]
    public class FizzBuzzTests
    {
        [TestCase(1, ExpectedResult = "1")]
        [TestCase(3, ExpectedResult = "Fizz")]
        [TestCase(5, ExpectedResult = "Buzz")]
        [TestCase(15, ExpectedResult = "FizzBuzz")]
        public string TestMethod(int value)
        {
            return FizzBuzz.Calculate(value);
        }
    }
}
