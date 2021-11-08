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
                }).Returns(8 + 1).SetName("NormalThrow");
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

        [TestCase('4', '-', ExpectedResult = 2)]
        [TestCase('4', '4', ExpectedResult = 2)]
        [TestCase('4', '/', ExpectedResult = 3)]
        [TestCase('X', ' ', ExpectedResult = 3)]
        [TestCase('X', 'X', ExpectedResult = 3)]
        public int GetScoreWidth(char throw1, char throw2)
        {
            return ScoreCalculator.GetScoreWidth(throw1, throw2);
        }

        [TestCase('-', ExpectedResult = 2)]
        [TestCase('4', ExpectedResult = 2)]
        [TestCase('X', ExpectedResult = 1)]
        public int GetFrameWidth(char throw1)
        {
            return ScoreCalculator.GetFrameWidth(throw1);
        }

        //          1 2 3 4 5 6 7 8 9 10
        [TestCase("                     ", ExpectedResult = 0)]
        [TestCase("4-                   ", ExpectedResult = 4)]
        [TestCase("--                   ", ExpectedResult = 0)]
        [TestCase("81                   ", ExpectedResult = (8 + 1))]
        [TestCase("X                    ", ExpectedResult = 10)]
        [TestCase("X 41                 ", ExpectedResult = (10 + 4 + 1) + (4 + 1))]
        [TestCase("5/35                 ", ExpectedResult = (5 + 5 + 3) + (3 + 5))]
        [TestCase("X X X X X X X X X XXX", ExpectedResult = 300)]
        public int Calculate(string throws)
        {
            return ScoreCalculator.Calculate(throws);
        }

        [TestCase("1", "-", ExpectedResult = 1)]
        [TestCase("1", "1", ExpectedResult = 2)]
        [TestCase("3", "/", ExpectedResult = 10)]
        [TestCase("X", "", ExpectedResult = 10)]
        public int CalculateFrameScore(string throw1, string throw2)
        {
            var frame = new Frame
            {
                throw1 = throw1,
                throw2 = throw2,
            };

            return frame.CalculateScore();
        }

        [TestCase("1", "-", "", ExpectedResult = 1)]
        [TestCase("1", "1", "", ExpectedResult = 2)]
        [TestCase("3", "/", "-", ExpectedResult = 10)]
        [TestCase("3", "/", "5", ExpectedResult = 15)]
        [TestCase("X", "-", "-", ExpectedResult = 10)]
        [TestCase("X", "X", "-", ExpectedResult = 20)]
        [TestCase("X", "X", "X", ExpectedResult = 30)]
        public int CalculateLAstFrameScore(string throw1, string throw2, string throw3)
        {
            var frame = new LastFrame
            {
                throw1 = throw1,
                throw2 = throw2,
                throw3 = throw3,
            };

            return frame.CalculateScore();
        }
    }
}