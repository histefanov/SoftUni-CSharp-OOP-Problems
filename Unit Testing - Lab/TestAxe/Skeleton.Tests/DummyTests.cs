using NUnit.Framework;
using System;

[TestFixture]
public class DummyTests
{
    [Test]
    public void DummyLosesHealthIfAttacked()
    {
        Axe axe = new Axe(50, 20);
        Dummy dummy = new Dummy(100, 0);

        axe.Attack(dummy);

        Assert.That(dummy.Health == 50,
            "Dummy doesn't lose health when being attacked");
    }

    [Test]
    public void DeadDummyThrowsExceptionIfAttacked()
    {
        Axe axe = new Axe(50, 20);
        Dummy dummy = new Dummy(0, 0);

        Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy),
            "Dead dummy doesn't throw exception when being attacked");
    }

    [Test]
    public void DeadDummyCanGiveExp()
    {
        Dummy dummy = new Dummy(0, 100);

        int exp = dummy.GiveExperience();

        Assert.That(exp == 100,
            "Dead dummy doesn't give exp");
    }

    [Test]
    public void AliveDummyCannotGiveExp()
    {
        Dummy dummy = new Dummy(100, 100);

        Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience(),
            "Alive Dummy cannot give exp");
    }
}
