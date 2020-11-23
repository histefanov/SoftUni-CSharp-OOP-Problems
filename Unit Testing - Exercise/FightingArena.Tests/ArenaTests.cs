using FightingArena;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;

        private Warrior warrior1;
        private Warrior warrior2;

        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
        }

        [Test]
        public void When_ConstructorIsInvoked_Expect_ProperBehaviour()
        {
            Assert.IsNotNull(this.arena.Warriors);
            Assert.IsNotNull(this.arena.Count);
        }

        [Test]
        public void When_ArenaCountIsCalled_Expect_CorrectResult()
        {
            this.arena.Enroll(new Warrior("Pesho", 10, 10));
            var expectedResult = 1;

            Assert.AreEqual(this.arena.Count, expectedResult);
        }

        [Test]
        public void When_EnrollingNewUniqueWarrior_Expect_ProperBehaviour()
        {
            this.warrior1 = new Warrior("Pesho", 30, 40);
            this.arena.Enroll(warrior1);

            Assert.That(this.arena.Warriors, Has.Member(warrior1));
        }

        [Test]
        public void When_EnrollingExistingWarrior_Expect_InvOpExc()
        {
            this.warrior1 = new Warrior("Pesho", 50, 50);
            this.arena.Enroll(this.warrior1);

            Assert.Throws<InvalidOperationException>(
                () => this.arena.Enroll(this.warrior1));
        }

        [Test]
        public void When_EnrollingWarriorWithExistingName_Expect_InvOpExc()
        {
            this.warrior1 = new Warrior("Goshko", 60, 40);
            this.warrior2 = new Warrior("Goshko", 30, 30);

            this.arena.Enroll(this.warrior1);

            Assert.Throws<InvalidOperationException>(
                () => this.arena.Enroll(this.warrior2));
        }

        [Test]
        public void When_FightingNotEnrolledWarrior_Expect_InvOpExc()
        {
            this.warrior1 = new Warrior("Goshko", 60, 40);
            this.warrior2 = new Warrior("Pesho", 30, 30);

            this.arena.Enroll(this.warrior1);

            Assert.Throws<InvalidOperationException>(
                () => this.arena.Fight(this.warrior1.Name, this.warrior2.Name));
        }

        [Test]
        public void When_AttackerIsNotEnrolled_Expect_InvOpExc()
        {
            this.warrior1 = new Warrior("Goshko", 60, 40);
            this.warrior2 = new Warrior("Pesho", 30, 30);

            this.arena.Enroll(this.warrior2);

            Assert.Throws<InvalidOperationException>(
                () => this.arena.Fight(this.warrior1.Name, this.warrior2.Name));
        }

        [Test]
        public void When_BothFightingWarriorsAreNotEnrolled_Expect_InvOpExc()
        {
            Assert.Throws<InvalidOperationException>(
                () => this.arena.Fight("Pesho", "Gosho"));
        }

        [Test]
        public void WhenBothFightingWarriorsAreEnrolled_Expect_ProperBehaviour()
        {
            this.warrior1 = new Warrior("Goshko", 20, 100);
            this.warrior2 = new Warrior("Pesho", 25, 100);
            var expectedWarrior1HP = this.warrior1.HP - this.warrior2.Damage;
            var expectedWarrior2HP = this.warrior2.HP - this.warrior1.Damage;

            this.arena.Enroll(this.warrior1);
            this.arena.Enroll(this.warrior2);
            this.arena.Fight(this.warrior1.Name, this.warrior2.Name);

            Assert.That(this.warrior1.HP == expectedWarrior1HP);
            Assert.That(this.warrior2.HP == expectedWarrior2HP);
        }
    }
}
