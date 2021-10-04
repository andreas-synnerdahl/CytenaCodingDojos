using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingGame
{
    public class ScoreCalculator
    {
        public static int Calculate(IList<Frame> frames)
        {
            var totalScore = 0;
            var scoreNextThrow = 0;
            var scoreNextNextThrow = 0;

            foreach (var frame in frames.Reverse())
            {
                var score = 0;

                if (frame.throw1 == "X")
                {
                    score = 10 + scoreNextThrow + scoreNextNextThrow;

                    scoreNextNextThrow = scoreNextThrow;
                    scoreNextThrow = score;
                }
                else if (frame.throw2 == "/")
                {
                    score = 10 + scoreNextThrow;

                    scoreNextNextThrow = scoreNextThrow;
                    scoreNextThrow = score;
                }
                else
                {
                    var scoreThrow1 = GetScoreFromThrow(frame.throw1);
                    var scoreThrow2 = GetScoreFromThrow(frame.throw2);

                    score = Math.Min(scoreThrow1 + scoreThrow2, 10);

                    scoreNextNextThrow = scoreThrow2;
                    scoreNextThrow = scoreThrow1;
                }

                totalScore += score;
            }

            return totalScore;
        }

        private static int GetScoreFromThrow(string theThrow)
        {
            return theThrow switch
            {
                "" => 0,
                "X" => 10,
                "-" => 0,
                "/" => 10,
                _ => int.Parse(theThrow),
            };
        }
    }
}
