using System;
using System.Collections.Generic;

namespace BowlingGame
{
    public class ScoreCalculator
    {
        public static int Calculate(List<Frame> frames)
        {
            var score = 0;
            foreach (var frame in frames)
            {
                if (frame.throw1 == "-" && frame.throw2 == "-")
                {
                    return 0;
                }

                if(frame.throw1 == "X")
                {
                    return 10;
                }

                score = score + int.Parse(frame.throw1) + int.Parse(frame.throw2);
            }

            return score;
        }
    }
}
