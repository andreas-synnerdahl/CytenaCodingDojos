using System.Collections.Generic;

namespace RomanLiterals
{
    public class RomanLiteralsParser
    {
        private int _currentValue;
        private int _biggestDigit;

        private static readonly Dictionary<char, int> ValueMap = new Dictionary<char, int>
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 },
        };

        public int ParseRomanLiteral(string romanLiteral)
        {
            if (romanLiteral.Length == 1)
            {
                int currentDigitValue = ValueMap[romanLiteral[0]];

                AccumulateCurrentLiteralValue(currentDigitValue);
            }
            else if (romanLiteral.Length > 1)
            {
                var rightmostDigitIndex = romanLiteral.Length - 1;

                int currentDigitValue = ValueMap[romanLiteral[rightmostDigitIndex]];

                AccumulateCurrentLiteralValue(currentDigitValue);

                ParseRomanLiteral(romanLiteral.Substring(0, romanLiteral.Length - 1));
            }

            return _currentValue;
        }

        private void AccumulateCurrentLiteralValue(int currentDigitValue)
        {
            if (currentDigitValue >= _biggestDigit)
            {
                _biggestDigit = currentDigitValue;
                _currentValue += currentDigitValue;
            }
            else
            {
                _currentValue -= currentDigitValue;
            }
        }
    }
}
