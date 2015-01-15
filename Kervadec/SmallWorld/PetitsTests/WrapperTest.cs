using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Wrapper;

namespace PetitsTests
{
    [TestClass]
    public class WrapperTest
    {
        [TestMethod]
        public void ConstructorTest()
        {
            WrapperAlgo algo = new WrapperAlgo();
            Assert.AreEqual(1, algo.computeFoo());
        }
    }
}
