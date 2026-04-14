using NUnit.Framework;
using HeroesGame.Implementation.Monster;
using HeroesGame.Constant;

namespace HeroesGame.Tests.Monster
{
    public class MonsterTests
    {
        private GiantWorm monster;

        [SetUp]
        public void Setup()
        {
            monster = new GiantWorm(2);
        }

        [Test]
        public void Constructor_ShouldSetHealth()
        {
            Assert.That(monster.Health,
                Is.EqualTo(2 * MonsterConstants.MaxHealthPerLevel));
        }

        [Test]
        public void Damage_ShouldReturnCorrectValue()
        {
            var damage = monster.Damage();

            Assert.That(damage,
                Is.EqualTo(2 * MonsterConstants.GiantWormDamagePerLevel));
        }

        [Test]
        public void Experience_ShouldReturnCorrectValue()
        {
            var xp = monster.Experience();

            Assert.That(xp,
                Is.EqualTo(2 * MonsterConstants.GiantWormXpPerLevel));
        }

        [Test]
        public void Armor_ShouldReturnCorrectValue()
        {
            var armor = monster.Armor();

            Assert.That(armor,
                Is.EqualTo(2 * MonsterConstants.GiantWormArmorPerLevel));
        }
    }
}