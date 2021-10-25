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
            var frames = new []{frame, nextFrame, nextNextFrame};
            var throws = frames
                .SelectMany(f => f.GetUsedThrows())
                .ToList();

            var score = 0;
            for (var i = 0; i < throws.Count; i++)
            {
                var remaing = throws.Skip(i);
                var current = remaing.First();

                var currentThrow = remaing.Take(2);
                if (current == "X" )
                    currentThrow = remaing.Take(3); 
                else if (current == "/" )
                    currentThrow = remaing.Take(1); 

                score = currentThrow.Sum(GetScoreFromThrow);
            }

            return score;
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
