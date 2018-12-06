using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTGCardChecker;

namespace UnitTestProject
{
    [TestClass]
    public class CardTest
    {
        #region test Subclass card creation
        [TestMethod]
        public void testLandCard()
        {
            var subCard = new LandCard(3);
            Assert.AreEqual(subCard.amountInDeck, 3);
            Assert.IsInstanceOfType(subCard, typeof(LandCard));
        }
        [TestMethod]
        public void testInstantCard()
        {
            var subCard = new InstantCard(3);
            Assert.AreEqual(subCard.amountInDeck, 3);
            Assert.IsInstanceOfType(subCard, typeof(InstantCard));
        }
        [TestMethod]
        public void testSoceryCard()
        {
            var subCard = new SorceryCard(3);
            Assert.AreEqual(subCard.amountInDeck, 3);
            Assert.IsInstanceOfType(subCard, typeof(SorceryCard));
        }
        [TestMethod]
        public void testPlaneswalkerCard()
        {
            var subCard = new PlaneswalkerCard(6, 3);
            Assert.AreEqual(subCard.amountInDeck, 3);
            Assert.AreEqual(subCard.loyalty, 6);
            Assert.IsInstanceOfType(subCard, typeof(PlaneswalkerCard));
        }
        [TestMethod]
        public void testEntchantmentCard()
        {
            var subCard = new EntchantmentCard(3);
            Assert.AreEqual(subCard.amountInDeck, 3);
            Assert.IsInstanceOfType(subCard, typeof(EntchantmentCard));
        }
        [TestMethod]
        public void testCreatureCard()
        {
            var subCard = new CreatureCard(1, 2, 3);
            Assert.AreEqual(subCard.power, 1);
            Assert.AreEqual(subCard.toughness, 2);
            Assert.AreEqual(subCard.amountInDeck, 3);
            Assert.IsInstanceOfType(subCard, typeof(CreatureCard));
        }
        #endregion
        #region test abstract card class
        [TestMethod]
        public void testCard()
        {
            var testCard = new LandCard(1);
            testCard.build("string1","string2","string3");
            Assert.AreEqual(testCard.cardName, "string1");
            Assert.AreEqual(testCard.cost, "string2");
            Assert.AreEqual(testCard.text, "string3");
        }
        #endregion
    }
}
