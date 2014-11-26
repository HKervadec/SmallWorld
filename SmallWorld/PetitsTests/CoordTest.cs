using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SmallWorld;

namespace PetitsTests
{
    [TestClass]
    public class CoordTest
    {
        [TestMethod]
        public void ConstructorTest()
        {
            Coord c = new Coord();
            Assert.AreEqual(0, c.x);
            Assert.AreEqual(0, c.y);

            for(int x = 0 ; x < 16 ; x++){
                for(int y = 0 ; y < 16 ; y++){
                    c = new Coord(x, y);

                    Assert.AreEqual(x, c.x);
                    Assert.AreEqual(y, c.y);
                }
            }      
        }
    }
}
