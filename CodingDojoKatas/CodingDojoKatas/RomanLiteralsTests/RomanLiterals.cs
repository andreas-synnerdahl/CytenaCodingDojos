using NUnit.Framework;
using RomanLiterals;
using System;
using System.Collections.Generic;

namespace RomanLiteralsTests
{
    [TestFixture]
    public class RomanLiteralsParserTests
    {
        [TestCase("I", ExpectedResult = 1)]
        [TestCase("II", ExpectedResult = 2)]
        [TestCase("VII", ExpectedResult = 7)]
        [TestCase("IIV", ExpectedResult = 3)]
        [TestCase("IV", ExpectedResult = 4)]
        [TestCase("V", ExpectedResult = 5)]
        [TestCase("X", ExpectedResult = 10)]
        [TestCase("C", ExpectedResult = 100)]
        [TestCase("M", ExpectedResult = 1000)]
        [TestCase("L", ExpectedResult = 50)]
        [TestCase("D", ExpectedResult = 500)]
        [TestCase("ID", ExpectedResult = 499)]
        [TestCase("CDL", ExpectedResult = 450)]
        [TestCase("IX", ExpectedResult = 9)]
        [TestCase("XL", ExpectedResult = 40)]
        [TestCase("XC", ExpectedResult = 90)]
        [TestCase("CD", ExpectedResult = 400)]
        [TestCase("CM", ExpectedResult = 900)]
        public int ParseRomanLiteral_Digits_ParsedCorrectly(string romanLiteral)
        {
            var target = new RomanLiteralsParser();

            return target.ParseRomanLiteral(romanLiteral);
        }

        [TestCase("a")]
        public void ParseRomanLiteral_Digits_ParsedUnknownCharacter(string romanLiteral)
        {
            var target = new RomanLiteralsParser();

            Assert.That(() => target.ParseRomanLiteral(romanLiteral), Throws.Exception.TypeOf<KeyNotFoundException>());
        }
    }
}
