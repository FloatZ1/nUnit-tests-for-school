using NUnit.Framework;
using HeroesGame.Implementation.Hero;
using HeroesGame.Implementation.Monster;

namespace HeroesGame.Tests
{
    public class CombatProcessorTests
    {
        private CombatProcessor processor;
        private Warrior hero;

        [SetUp]
        public void Setup()
        {
            hero = new Warrior();
            processor = new CombatProcessor(hero);
        }

        [Test]
        public void Constructor_ShouldCreateLogger()
        {
            Assert.That(processor.Logger, Is.Not.Null);
            Assert.That(processor.Logger.Count, Is.EqualTo(0));
        }

        [Test]
        public void Fight_ShouldAddLogEntries()
        {
            var monster = new GiantWorm(1);

            processor.Fight(monster);

            Assert.That(processor.Logger.Count, Is.GreaterThan(0));
        }

        [Test]
        public void Fight_ShouldKillMonster()
        {
            var monster = new GiantWorm(1);

            processor.Fight(monster);

            Assert.That(monster.IsDead(), Is.True);
        }

        [Test]
        public void Fight_ShouldGiveExperience()
        {
            var monster = new GiantWorm(1);

            processor.Fight(monster);

            Assert.That(hero.Experience, Is.GreaterThan(0));
        }
    }
}