using System;
using NUnit.Framework;
using BowlingAppViewModel;
using BowlingAppModel;

namespace BowlingAppViewModelTests
{
    [TestFixture]
    public class BowlingAppViewModelTests
    {
        [Test]
        public void AddThrowCommand_NullParameter_ThrowsException()
        {
            var target = new BowlingAppViewModel.BowlingAppViewModel();

            Assert.That(() => target.AddThrowCommand.Execute(null),
                Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void AddMissCommand_AddMiss_CountIsSetTo1()
        {
            var target = new BowlingAppViewModel.BowlingAppViewModel();

            target.AddThrowCommand.Execute(Throw.Miss);

            Assert.That(target.ThrowCount, Is.EqualTo(1));
            Assert.That(target[0], Is.EqualTo(Throw.Miss));
        }

        [Test]
        public void AddMissCommand_AddOne_CountIsSetTo1()
        {
            var target = new BowlingAppViewModel.BowlingAppViewModel();

            target.AddThrowCommand.Execute(Throw.One);

            Assert.That(target.ThrowCount, Is.EqualTo(1));
            Assert.That(target[0], Is.EqualTo(Throw.One));
        }

        [Test]
        public void AddThrowCommand_AddNineNine_Throws()
        {
            var target = new BowlingAppViewModel.BowlingAppViewModel();

            target.AddThrowCommand.Execute(Throw.Nine);

            Assert.That(target.ThrowCount, Is.EqualTo(1));
            Assert.That(target[0], Is.EqualTo(Throw.Nine));

            Assert.That(() => target.AddThrowCommand.Execute(Throw.Nine),
                Throws.Exception);
        }
    }
}
