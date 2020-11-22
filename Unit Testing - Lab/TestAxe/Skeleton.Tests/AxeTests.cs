using NUnit.Framework;

[TestFixture]
public class AxeTests
{
    private Axe axe;
    private Dummy dummy;

    [SetUp]
    public void Initialize()
    {
        this.dummy = new Dummy(10, 10);
        this.axe = new Axe(20, 0);
    }

    [Test]
    [TestCase(100, 100, 100, 100, 99)]
    [TestCase(50, 40, 20, 35, 39)]
    public void AxeLosesDurabilityWhenAttacking(
        int attack,
        int durability,
        int health,
        int experience,
        int expectedResult)
    {
        this.axe = new Axe(attack, durability);
        this.dummy = new Dummy(health, experience);

        axe.Attack(dummy);

        Assert.That(axe.DurabilityPoints == expectedResult, 
            "Axe durability points don't change after attacking");
    }
    
    [Test]
    public void AttackingWithABrokenWeapon()
    {
        this.axe = new Axe(100, 0);
        this.dummy = new Dummy(100, 100);

        Assert.That(() => axe.Attack(dummy),
            Throws.InvalidOperationException
            .With.Message.EqualTo("Axe is broken."),
            "Attacking with broken axe doesn't throw exception.");
    }
}