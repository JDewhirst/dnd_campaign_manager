using NUnit.Framework;
using DnDCampaignManagerApp;
using CampaignManagerData;
using System.Linq;

namespace DnDCampaignManagerTests
{
    public class DiceRollerTests
    {
        [TestCase("1d6", 6)]
        [TestCase("1d2147483647", 2147483647)]
        [TestCase("1d1", 1)]
        public void WhenDiceAreParsedTheCorrectDieSizeIsReturned(string input, int expected)
        {
            var result = DiceRoller.ParseDice(input);
            Assert.AreEqual(expected, result.Item2);
        }

        [Test]
        public void WhenAttemptIncorrectDiceThrowException()
        {
            Assert.Fail();
        }

        [TestCase("6d6", 6)]
        [TestCase("2147483647d4", 2147483647)]
        [TestCase("1d1", 1)]
        public void WhenDiceAreParsedTheCorrectNumberOfDiceIsReturned(string input, int expected)
        {
            var result = DiceRoller.ParseDice(input);
            Assert.AreEqual(expected, result.Item1);
        }


    }
}
