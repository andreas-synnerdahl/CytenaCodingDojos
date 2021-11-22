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

            target[0] = Throw.One;

            Assert.That(target, Is.Not.Empty);
        }

        [Test]
        public void LineIndexer_Assign2ndElement_2ndElementCanBeRetrieved()
        {
            var target = new Line();

            target[1] = Throw.One;

            Assert.That(target[1], Is.EqualTo(Throw.One));
        }

        [Test]
        public void LineIndexer_Assign2ndElementGet1stElement_1stElementIsNone()
        {
            var target = new Line();

            target[1] = Throw.One;

            Assert.That(target[0], Is.EqualTo(Throw.Miss));
        }
    }
}
