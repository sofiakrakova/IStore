using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace IStore.Domain.Tests
{
    [TestClass]
    public class ItemCardTests
    {
        [TestMethod]
        public void ItemCardWithNegativePriceThrowsException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                ItemCard itemCard = new ItemCard("", "", -0.01, "");
            });
        }

        [TestMethod]
        public void ItemCardWithEmptyTitleThrowsException()
        {
            Assert.ThrowsException<ArgumentException>(() =>
            {
                ItemCard itemCard = new ItemCard("", "", 100, "");
            });
        }
    }
}
