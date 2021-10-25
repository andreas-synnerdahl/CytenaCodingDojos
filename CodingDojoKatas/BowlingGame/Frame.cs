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
    }

    [DebuggerDisplay(nameof(LastFrame) + ": throw1 {throw1} throw2 {throw2} throw3 {throw3}")]
    public class LastFrame : Frame
    {
        public string throw3 = "";
    }
}