using NUnit.Framework;

namespace BowlingAppModel.Tests
{
    [TestFixture]
    public class LineTests
    {
        [Test]
        public void LineCtor_IsEmpty()
        {
            var target = new Line();

            Assert.That(target, Is.Empty);
        }

        [Test]
        public void LineIndexer_AssignElement_LineNotEmpty()
        {
            var target = new Line();

            target.Add(Throw.One);

            Assert.That(target, Is.Not.Empty);
        }

        [Test]
        public void Add_2ndElementGet1stElement_1stElementIsNone()
        {
            var target = new Line();

            target.Add(Throw.Miss);

            Assert.That(target[0], Is.EqualTo(Throw.Miss));
        }

        [Test]
        public void Add_Athrow_LineNotEmpty()
        {
            var target = new Line();

            target.Add(Throw.One);

            Assert.That(target, Is.Not.Empty);
        }

        [Test]
        public void Add_2ndElement_2ndElementCanBeRetrieved()
        {
            var target = new Line();

            target.Add(Throw.Miss);
            target.Add(Throw.One);

            Assert.That(target[0], Is.EqualTo(Throw.Miss));
            Assert.That(target[1], Is.EqualTo(Throw.One));
        }
        
        [Test]
        public void Add_NineNine_Throws()
        {
            var target = new Line();

            target.Add(Throw.Nine);

            Assert.That(
                () => target.Add(Throw.Nine),
                Throws.Exception);            
        }
        
        [Test]
        public void Add_Strike_CountIncrementedByTwo()
        {
            var target = new Line();

            target.Add(Throw.Strike);

            Assert.That(target.Count, Is.EqualTo(2));            
        }
        
        [Test]
        public void Add_StrikeAtSecond_CountIs2()
        {
            var target = new Line();
            target.Add(Throw.Miss);

            target.Add(Throw.Ten);

            Assert.That(target.Count, Is.EqualTo(2));            
        }

        [Test]
        public void CalculateScore_blabla()
        {
            Assert.Fail("we need to calculate the score finally");
        }
        
        [TestCase (Throw.Miss, ExpectedResult = 0)]
        [TestCase (Throw.One, ExpectedResult = 1)]
        [TestCase(Throw.Two, ExpectedResult = 2)]
        [TestCase(Throw.Three, ExpectedResult = 3)]
        [TestCase(Throw.Four, ExpectedResult = 4)]
        [TestCase(Throw.Five, ExpectedResult = 5)]
        [TestCase(Throw.Six, ExpectedResult = 6)]
        [TestCase(Throw.Seven, ExpectedResult = 7)]
        [TestCase(Throw.Eight, ExpectedResult = 8)]
        [TestCase(Throw.Nine, ExpectedResult = 9)]
        [TestCase(Throw.Strike, ExpectedResult = 10)]
        public int Throw_EnumValues_EnumValueCorrespondToThrowValue(Throw throwEnumValue)
        {
            return (int)throwEnumValue;
        }
    }
}
