using System;
using NUnit.Framework;
using BowlingAppViewModel;

namespace BowlingAppViewModelTests
{
    [TestFixture]
    public class BowlingAppViewModelTests
    {
        [Test]
        public void AddMissCommand_AddMiss_CountIsSetTo1()
        {
            var target = new BowlingAppViewModel.BowlingAppViewModel();

            target.AddMissCommand.Execute(default);

            Assert.That(target.ThrowCount, Is.EqualTo(1));
        }

        [Test]
        public void AddMissCommand_AddOne_CountIsSetTo1()
        {
            var target = new BowlingAppViewModel.BowlingAppViewModel();

            target.AddOneCommand.Execute(default);

            Assert.That(target.ThrowCount, Is.EqualTo(1));
        }
    }
}
