using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace BowlingGame
{
    [DebuggerDisplay(nameof(Frame) + ": throw1 {throw1} throw2 {throw2}")]
    public class Frame
    {
        public static readonly Frame Empty = new Frame();

        public string throw1 = "";
        public string throw2 = "";

        public virtual int CalculateScore()
        {
            if (throw2 == "/")
                return 10;

            return GetScoreFromThrow(throw1) + GetScoreFromThrow(throw2);
        }

        protected static int GetScoreFromThrow(string theThrow)
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

        public IEnumerable<string> GetUsedThrows()
        {
            if (throw1 == "X")
            {
                yield return throw1;
            }
            else if (throw2 == "/")
            {
                yield return throw2;
            }
            else
            {
                yield return throw1;
                yield return throw2;
            }
        }        
    }

    [DebuggerDisplay(nameof(LastFrame) + ": throw1 {throw1} throw2 {throw2} throw3 {throw3}")]
    public class LastFrame : Frame
    {
        public string throw3 = "";

        public override int CalculateScore()
        {
            if (throw2 == "/")
                return GetScoreFromThrow("/") + GetScoreFromThrow(throw3);
            if (throw2 == "X")
                return base.CalculateScore() + GetScoreFromThrow(throw3);

            else
                return base.CalculateScore();
        }
    }
}