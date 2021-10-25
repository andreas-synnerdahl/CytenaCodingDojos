using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingGame
{
    // https://codingdojo.org/kata/Bowling/

    public static class ScoreCalculator
    {
        public static int Calculate(IList<Frame> frames)
        {
            var totalScore = 0;

            var nextFrame = Frame.Empty;
            var nextNextFrame = Frame.Empty;

            foreach (var frame in frames.Reverse())
            {
                var score = CalculateScore(frame, nextFrame, nextNextFrame);

                nextNextFrame = nextFrame;
                nextFrame = frame;

                totalScore += score;
            }

            return totalScore;
        }

        public static int CalculateScore(Frame frame, Frame nextFrame, Frame nextNextFrame)
        {
            var throws = GetThrows(frame, nextFrame, nextNextFrame);

            if (frame.throw1 == "X")
            {
                return throws
                    .Take(3)
                    .Sum(GetScoreFromThrow);
            }
            else if (frame.throw2== "/")
            {
                return throws
                    .Skip(1)
                    .Take(2)
                    .Sum(GetScoreFromThrow);
            }
            else
            {
                return throws
                    .Take(2)
                    .Sum(GetScoreFromThrow);
            }
        }

        private static IEnumerable<string> GetThrows(params Frame[] frames) => frames
            .SelectMany(GetThrows);

        private static IEnumerable<string> GetThrows(Frame frame)
        {
            yield return frame.throw1;

            if (frame.throw1 != "X")
            {
                yield return frame.throw2;
            }
        }

        private static int GetScoreFromThrow(string theThrow)
        {
            return theThrow switch
            {
                "" => 0,
                "X" => 10,
                "-" => 0,
                "/" => 10,
                null => 0,
                _ => int.Parse(theThrow),
            };
        }
    }
}
