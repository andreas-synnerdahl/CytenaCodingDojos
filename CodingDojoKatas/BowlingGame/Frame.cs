namespace BowlingGame
{
    public class Frame
    {
        public string throw1 = "";
        public string throw2 = "";

        public int CalculateScore()
        {
            if (throw2 == "/")
                return 10;

            return GetScoreFromThrow(throw1) + GetScoreFromThrow(throw2);
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

    public class LastFrame : Frame
    {
        public string throw3 = "";
    }
}