using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SmallWorld;

namespace PetitsTests {
    [TestClass]
    public class UnitTest {
        [TestMethod]
        public void ConstructorTest() {
            Coord c = new Coord();

            Unit[] units = new Unit[3];
            units[0] = new Dwarf(c, 0);
            units[1] = new Elf(c, 0);
            units[2] = new Orc(c, 0);

            foreach(Unit u in units) {
                Assert.AreEqual(Unit.max_life, u.LifePoints);
            }

        }
    }
}
