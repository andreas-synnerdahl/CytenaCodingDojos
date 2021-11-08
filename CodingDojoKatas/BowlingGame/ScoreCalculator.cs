using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace BowlingGame
{
    // https://codingdojo.org/kata/Bowling/

    public class ScoreCalculator
    {
        public static int Calculate(string throws)
        {
            var throwsWithoutSpaces = throws.Where(t => t != ' ').ToArray();

            var score = 0;

            var throwIndex = 0;
            while (throwIndex <= throwsWithoutSpaces.Length - 1)
            {
                var currentThrow = throwsWithoutSpaces[throwIndex];
                var nextThrow = throwsWithoutSpaces[throwIndex + 1];
                //var nextNextThrow = throws[throwIndex + 2];

                var width = GetScoreWidth(currentThrow, nextThrow);
                var x = new ArraySegment<char>(throwsWithoutSpaces, currentThrow, width).Sum(GetScoreFromThrow);

                var frameWidth = GetFrameWidth(currentThrow);
                throwIndex += frameWidth;
            }

            return score;
        }

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

        private static int GetScoreFromThrow(char theThrow)
        {
            return theThrow switch
            {
                ' ' => 0,
                'X' => 10,
                '-' => 0,
                '/' => 10,
                _ => int.Parse(theThrow.ToString()),
            };
        }

        public static int GetScoreWidth(char throw1, char throw2)
        {
            if (throw1 == 'X')
                return 3;
            if (throw2 == '/')
                return 3;
            return 2;
        }

        public static int GetFrameWidth(char throw1)
        {
            if (throw1 == 'X')
                return 1;
            return 2;
        }
    }
}
