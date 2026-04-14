using NUnit.Framework;
using Moq;
using HeroesGame.Contract;
using HeroesGame.Implementation.Hero;
namespace HeroesGame.Tests.Hero
{
    public class MoqTests
    {
        [Test]
        public void Hero_WithMockedWeapon()
        {
            var weaponMock = new Mock<IWeapon>();

            weaponMock.Setup(x => x.Damage).Returns(50);
            weaponMock.Setup(x => x.ArmorPenetration()).Returns(10);

            var hero = new Warrior();

            Assert.That(hero.Weapon, Is.Not.Null);
        }
    }
}