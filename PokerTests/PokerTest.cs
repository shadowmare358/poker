using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerLibrary;

namespace PokerTests
{
    [TestClass]
    public class PokerTest
    {
        [TestMethod]
        public void TestIfWalletIsEmpty()
        {
            Betting bet = new Betting
            {
                ComputerWallet = -100
            };
            Assert.AreEqual(bet.CheckSolvency(), false);
        }
        [TestMethod]
        public void TestIfWalletIsNotEmpty()
        {
            Betting bet = new Betting
            {
            ComputerWallet = 100,
            PlayerWallet = 100
            };
            Assert.AreEqual(bet.CheckSolvency(),true);
        }
    }
}
