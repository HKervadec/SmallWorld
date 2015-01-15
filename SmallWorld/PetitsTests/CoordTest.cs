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
            Assert.AreEqual(0, c.X);
            Assert.AreEqual(0, c.Y);

            for(int x = 0 ; x < 16 ; x++){
                for(int y = 0 ; y < 16 ; y++){
                    c = new Coord(x, y);

                    Assert.AreEqual(x, c.X);
                    Assert.AreEqual(y, c.Y);
                }
            }
        }

        [TestMethod]
        public void NextToTest()
        {
            Coord a = new Coord();
            Coord b = new Coord();

            for(int x = 0; x < 16; x++){
                for(int y = 0; y < 16; y++){
                    a.X = x;
                    a.Y = y;

                    for(int i = -1; i <= 1; i++){
                        for(int j = -1 ; j <= 1 ; j++){
                            b.X = x - i;
                            b.Y = y - j;

                            if(i != 0 && j != 0){
                                Assert.IsTrue(a.NextTo(b));
                            }
                            else {
                                Assert.IsFalse(a.NextTo(b));
                            }
                        }
                    }
                    for(int i = -2 ; i <= 2 ; i += 4) {
                        b.X = x - i;
                        b.Y = y;

                        Assert.IsTrue(a.NextTo(b));
                    }
                }
            }
        }
    }
}
