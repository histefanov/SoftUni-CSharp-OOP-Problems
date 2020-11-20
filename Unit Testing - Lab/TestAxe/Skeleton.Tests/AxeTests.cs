using NUnit.Framework;

[TestFixture]
public class AxeTests
{
    [Test]
    public void AxeLosesDurabilityWhenAttacking()
    {
        Axe axe = new Axe(100, 100);
        Dummy dummy = new Dummy(100, 100);

        axe.Attack(dummy);

        Assert.That(axe.DurabilityPoints == 99, 
            "Axe durability points don't change after attacking");
    }
    
    [Test]
    public void AttackingWithABrokenWeapon()
    {
        Axe axe = new Axe(100, 0);
        Dummy dummy = new Dummy(100, 100);

        Assert.That(() => axe.Attack(dummy),
            Throws.InvalidOperationException
            .With.Message.EqualTo("Axe is broken."));
    }
}