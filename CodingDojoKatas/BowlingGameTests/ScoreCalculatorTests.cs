using BowlingGame;
using NUnit.Framework;
using System.Collections.Generic;

namespace BowlingGameTests
{
    [TestFixture]
    public class ScoreCalculatorTests
    {
        [Test]
        public void BadBowler()
        {
            int score = ScoreCalculator.Calculate(new List<Frame>
            {
                new Frame()
                {
                    throw1 = "-",
                    throw2 = "-",
                }
            });

            Assert.That(score, Is.EqualTo(0));
        }

        [Test]
        public void GoodBowler()
        {
            int score = ScoreCalculator.Calculate(new List<Frame>
            {
                new Frame()
                {
                    throw1 = "X",                   
                }
            });
            Assert.That(score, Is.EqualTo(10));
        }

        [Test]
        public void NormalThrow()
        {
            int score = ScoreCalculator.Calculate(new List<Frame>
            {
                new Frame()
                {
                    throw1 = "8",
                    throw2 = "1",
                }
            });
            Assert.That(score, Is.EqualTo(9));
        }

        [Test]
        public void ThadaThrow()
        {
            int score = ScoreCalculator.Calculate(new List<Frame>
            {
                new Frame()
                {
                    throw1 = "5",
                    throw2 = "/",
                },
                                new Frame()
                {
                    throw1 = "3",
                    throw2 = "5",
                }

            });
            Assert.That(score, Is.EqualTo(21)); // (10 + 3) + (3 + 5)  = 21
        }


    }
}
