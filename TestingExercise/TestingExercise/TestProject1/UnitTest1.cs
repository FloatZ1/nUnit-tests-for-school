using NUnit.Framework;
using HeroesGame.Implementation.Hero;
using HeroesGame.Constant;

namespace HeroesGame.Tests.Hero
{
    public class BaseHeroTests
    {
        private Warrior hero;

        [SetUp]
        public void Setup()
        {
            hero = new Warrior();
        }

        [Test]
        public void Constructor_ShouldSetCorrectInitialValues()
        {
            Assert.That(hero.Level, Is.EqualTo(HeroConstants.InitialLevel));
            Assert.That(hero.Experience, Is.EqualTo(HeroConstants.InitialExperience));
            Assert.That(hero.MaxHealth, Is.EqualTo(HeroConstants.InitialMaxHealth));
            Assert.That(hero.Health, Is.EqualTo(HeroConstants.InitialMaxHealth));
            Assert.That(hero.Armor, Is.EqualTo(HeroConstants.InitialArmor));
        }

        [TestCase(10)]
        [TestCase(20)]
        [TestCase(30)]
        public void TakeHit_ShouldReduceHealthCorrectly(double damage)
        {
            var expectedHealth = hero.Health - (damage - hero.Armor);

            hero.TakeHit(damage);

            Assert.That(hero.Health, Is.EqualTo(expectedHealth));
        }

        [TestCase(-10)]
        [TestCase(-50)]
        public void TakeHit_ShouldThrowException_WhenDamageNegative(double damage)
        {
            Assert.Throws<System.ArgumentException>(() => hero.TakeHit(damage));
        }

        [Test]
        public void GainExperience_ShouldIncreaseExperience()
        {
            hero.GainExperience(20);

            Assert.That(hero.Experience, Is.EqualTo(20));
        }

        [Test]
        public void GainExperience_ShouldLevelUp_WhenMaxReached()
        {
            hero.GainExperience(120);

            Assert.That(hero.Level, Is.EqualTo(2));
        }

        [Test]
        public void Heal_ShouldIncreaseHealth()
        {
            hero.TakeHit(50);

            hero.Heal();

            Assert.That(hero.Health, Is.GreaterThan(0));
        }

        [Test]
        public void Heal_ShouldNotExceedMaxHealth()
        {
            hero.Heal();

            Assert.That(hero.Health, Is.EqualTo(hero.MaxHealth));
        }

        [Test]
        public void IsDead_ShouldReturnTrue_WhenHealthBelowZero()
        {
            hero.TakeHit(200);

            Assert.That(hero.IsDead(), Is.True);
        }

        [Test]
        public void IsDead_ShouldReturnFalse_WhenAlive()
        {
            Assert.That(hero.IsDead(), Is.False);
        }
    }
}