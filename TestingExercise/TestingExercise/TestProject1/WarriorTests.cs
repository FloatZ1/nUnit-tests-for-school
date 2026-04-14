using NUnit.Framework;
using HeroesGame.Implementation.Hero;
using HeroesGame.Constant;
//tippy
namespace HeroesGame.Tests.Hero
{
    public class WarriorTests
    {
        private Warrior warrior;

        [SetUp]
        public void Setup()
        {
            warrior = new Warrior();
        }

        [Test]
        public void Warrior_LevelUp_ShouldIncreaseStats()
        {
            warrior.GainExperience(120);

            Assert.That(warrior.Level, Is.EqualTo(2));
            Assert.That(warrior.Armor, Is.EqualTo(HeroConstants.WarriorArmorPerLevel));
            Assert.That(warrior.MaxHealth,
                Is.EqualTo(HeroConstants.InitialMaxHealth + HeroConstants.WarriorMaxHealthPerLevel));
        }
    }
}
