using System;
using System.Linq;
using NUnit.Framework;

namespace BowlingAppModel.Tests
{
    [TestFixture]
    public class LineTests
    {
        [Test]
        public void Indexer_FirstElementInitialized()
        {
            var target = new Line();

            Assert.That(target[0], Is.Not.Null);
        }

        [Test]
        public void Enumerate_All_Ten_Elements()
        {
            var target = new Line();

            Assert.That(target.Count(), Is.EqualTo(10));
        }

        [Test]
        public void Enumerate_possible_Throws()
        {
            var target = new Line();

            Assert.That(target.Select(f => f.Count).Take(9), Is.EqualTo(2));
            Assert.That(target.Select(f => f.Count).Last(), Is.EqualTo(3));
        }
    }
}
