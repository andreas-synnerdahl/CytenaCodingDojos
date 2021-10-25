using System.Collections.Generic;
using System.Linq;
using BowlingGame;
using NUnit.Framework;

namespace BowlingGameTests
{
    [TestFixture]
    public class ScoreCalculatorTests
    {
        public static IEnumerable<TestCaseData> BowlingGames
        {
            get
            {
                yield return new TestCaseData(new List<Frame>
                {
                    new Frame
                    {
                        throw1 = "-",
                        throw2 = "-"
                    }
                }).Returns(0).SetName("BadBowler");
                yield return new TestCaseData(new List<Frame>
                {
                    new Frame
                    {
                        throw1 = "X"
                    }
                }).Returns(10).SetName("Single Strike");
                yield return new TestCaseData(new List<Frame>
                {
                    new Frame
                    {
                        throw1 = "X"
                    },
                    new Frame
                    {
                        throw1 = "4",
                        throw2 = "1"
                    }
                }).Returns(10 + 5 + 5).SetName("Single Strike");
                yield return new TestCaseData(new List<Frame>
                {
                    new Frame
                    {
                        throw1 = "8",
                        throw2 = "1"
                    }
                }).Returns(9).SetName("NormalThrow");
                yield return new TestCaseData(new List<Frame>
                {
                    new Frame
                    {
                        throw1 = "5",
                        throw2 = "/"
                    },
                    new Frame
                    {
                        throw1 = "3",
                        throw2 = "5"
                    }
                }).Returns(10 + 3 + 3 + 5).SetName("Spare With Bonus");
                yield return new TestCaseData(
                    Enumerable.Repeat("X", 9)
                    .Select(strike => new Frame
                    {
                        throw1 = strike,
                    }).Concat(new [] {new LastFrame
                        {
                             throw1 = "X",
                             throw2 = "X",
                             throw3 = "X"
                        }}).ToList()
                ).Returns(300).SetName("All strikes - Perfect 300");
            }
        }

        [TestCaseSource(nameof(BowlingGames))]
        public int Calculate(IList<Frame> frames)
        {
            return ScoreCalculator.Calculate(frames);
        }

        [TestCase("1", "-", "", ExpectedResult = 1)]
        [TestCase("1", "1", "", ExpectedResult = 2)]
        [TestCase("3", "/", "", ExpectedResult = 10)]
        [TestCase("X", "", "", ExpectedResult = 10)]
        [TestCase("3", "/", "5", ExpectedResult = 15)]
        [TestCase("X", "-", "-", ExpectedResult = 10)]
        [TestCase("X", "X", "-", ExpectedResult = 20)]
        [TestCase("X", "X", "X", ExpectedResult = 30)]
        public int CalculateFrameScore(string throw1, string throw2, string throw3)
        {
            return ScoreCalculator.CalculateScore(throw1, throw2, throw3);
        }
    }
}