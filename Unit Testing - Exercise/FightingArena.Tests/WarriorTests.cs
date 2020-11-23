using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        private const string EXAMPLE_NAME = "Mark Antony";
        private const int EXAMPLE_HP = 50;
        private const int EXAMPLE_DAMAGE = 45;

        private Warrior warrior;
        private Warrior attackedWarrior;

        [SetUp]
        public void Setup()
        { }

        [Test]
        [TestCase("Hercules", 40, 100)]
        [TestCase("Arkantos", 30, 50)]
        [TestCase("Aurelius", 10, 10)]
        public void When_ConstructorIsInvoked_Expect_ProperBehaviour(
            string name, int dmg, int hp)
        {
            this.warrior = new Warrior(name, dmg, hp);

            Assert.AreEqual(this.warrior.Name, name);
            Assert.AreEqual(this.warrior.Damage, dmg);
            Assert.AreEqual(this.warrior.HP, hp);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("  ")]
        [TestCase("   ")]
        public void When_NameIsNullOrWhitespace_Expect_ArgExc(
            string name)
        {
            Assert.Throws<ArgumentException>(
                () => this.warrior = new Warrior(name, EXAMPLE_DAMAGE, EXAMPLE_HP));
        }

        [Test]
        public void When_NameIsEmpty_Expect_ArgExc()
        {
            Assert.Throws<ArgumentException>(
                () => this.warrior = new Warrior(string.Empty, EXAMPLE_DAMAGE, EXAMPLE_HP));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-5)]
        [TestCase(-20)]
        [TestCase(Int32.MinValue)]
        public void When_DamageIsZeroOrNegative_Expect_ArgExc(
            int damage)
        {
            Assert.Throws<ArgumentException>(
                () => this.warrior = new Warrior(EXAMPLE_NAME, damage, EXAMPLE_HP));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-5)]
        [TestCase(-20)]
        [TestCase(Int32.MinValue)]
        public void When_HPIsNegative_Expect_ArgExc(
            int hp)
        {
            Assert.Throws<ArgumentException>(
                () => this.warrior = new Warrior(EXAMPLE_NAME, EXAMPLE_DAMAGE, hp));
        }

        [Test]
        [TestCase(30)]
        [TestCase(20)]
        [TestCase(0)]
        public void When_WarriorAttacksBelow30HP_Expect_InvOpExc(
            int hp)
        {
            this.warrior = new Warrior("Gosho", 20, hp);
            this.attackedWarrior = new Warrior("Pesho", 10, 50);

            Assert.Throws<InvalidOperationException>(
                () => this.warrior.Attack(this.attackedWarrior));
        }

        [Test]
        [TestCase(30)]
        [TestCase(20)]
        [TestCase(0)]
        public void When_WarriorAttacksAnotherWarriorBelow30HP_Expect_InvOpExc(
            int hp)
        {
            this.warrior = new Warrior("Gosho", 20, 100);
            this.attackedWarrior = new Warrior("Pesho", 10, hp);

            Assert.Throws<InvalidOperationException>(
                () => this.warrior.Attack(attackedWarrior));
        }

        [Test]
        [TestCase(80)]
        [TestCase(0)]
        [TestCase(99)]
        public void When_WarriorAttacksStrongerEnemy_Expect_InvOpExc(
            int hp)
        {
            this.warrior = new Warrior("Gosho", 50, hp);
            this.attackedWarrior = new Warrior("Pesho", 100, 100);

            Assert.Throws<InvalidOperationException>(
                () => this.warrior.Attack(attackedWarrior));
        }

        [Test]
        public void When_WarriorAttacks_Expect_HPCannotDropBelowZero()
        {
            this.warrior = new Warrior("Gosho", 50, 100);
            this.attackedWarrior = new Warrior("Pesho", 20, 40);
            var expectedHP = 0;

            this.warrior.Attack(attackedWarrior);

            Assert.AreEqual(this.attackedWarrior.HP, expectedHP);
        }

        [Test]
        public void When_WarriorAttacks_Expect_ProperBehaviour()
        {
            this.warrior = new Warrior("Gosho", 20, 100);
            this.attackedWarrior = new Warrior("Pesho", 30, 120);
            var expectedWarriorHP = 70;
            var expectedAttackedWarriorHP = 100;

            this.warrior.Attack(attackedWarrior);

            Assert.AreEqual(this.warrior.HP, expectedWarriorHP);
            Assert.AreEqual(this.attackedWarrior.HP, expectedAttackedWarriorHP);
        }
    }
}