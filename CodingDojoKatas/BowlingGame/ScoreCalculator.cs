using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingGame
{
    // https://codingdojo.org/kata/Bowling/

    public class ScoreCalculator
    {
        public static int Calculate(IList<Frame> frames)
        {
            var nextFrame = new Frame();
            var nextNextFrame = new Frame();

            var totalScore = 0;

            foreach (var frame in frames.Reverse())
            {
                var score = CalculateFrameScore(frame, nextFrame, nextNextFrame);

                nextNextFrame = nextFrame;
                nextFrame = frame;

                totalScore += score;
            }
            
            return totalScore;
        }

        public static int CalculateFrameScore(Frame frame, Frame nextFrame, Frame nextNextFrame)
        {
            if (frame.throw1 == "X")
            {
                return 10 + CalculateFrameScore(nextFrame, nextNextFrame, new Frame()) + CalculateFrameScore(nextNextFrame, new Frame(), new Frame());
            }
            else if (frame.throw2 == "/")
            {
                return 10 + CalculateFrameScore(nextFrame, nextNextFrame, new Frame());
            }
            else
            {
                var scoreThrow1 = GetScoreFromThrow(frame.throw1);
                var scoreThrow2 = GetScoreFromThrow(frame.throw2);

                return Math.Min(scoreThrow1 + scoreThrow2, 10);
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
                _ => int.Parse(theThrow),
            };
        }
    }
}
