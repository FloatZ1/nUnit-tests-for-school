using NUnit.Framework;
using HeroesGame.Implementation.Weapon;
using HeroesGame.Constant;

namespace HeroesGame.Tests.Weapon
{
    public class WeaponTests
    {
        private TwoHandSword sword;

        [SetUp]
        public void Setup()
        {
            sword = new TwoHandSword();
        }

        [Test]
        public void Constructor_ShouldSetInitialValues()
        {
            Assert.That(sword.Level, Is.EqualTo(WeaponConstants.InitialLevel));
            Assert.That(sword.Damage, Is.EqualTo(WeaponConstants.InitialDamage));
        }

        [Test]
        public void LevelUp_ShouldIncreaseDamage()
        {
            sword.LevelUp();

            Assert.That(sword.Level, Is.EqualTo(2));
            Assert.That(sword.Damage,
                Is.EqualTo(WeaponConstants.InitialDamage + WeaponConstants.DamagePerLevel));
        }

        [Test]
        public void ArmorPenetration_ShouldReturnCorrectValue()
        {
            var penetration = sword.ArmorPenetration();

            Assert.That(penetration,
                Is.EqualTo(WeaponConstants.TwoHandSwordArmorPenCoefficient));
        }
    }
}