using NUnit.Framework;
using IComparable_IComparer_Interfaces;

namespace UnitTests
{
    [TestFixture]
    public class BoxUnitTester
    {
        // this is the testing class
        // must be annotated to be used as a class for testing purposes
        // TestFixture is the attribute for this
        // test whether the method in box forumla Volume is correct
        // annotate the method with TEST attribute
        [Test]
        public void BoxAreaTester()
        {
            // need two values: expected, actual
            // three inputs required for Box(Length, Width, Height)
            // L=1, W=2, and H=3 should return 22
            double expected = (2 * (2 * 3)) + (2 * (3 * 4)) + (2 * (4 * 2));
            Box b1 = new Box(2, 3, 4);
            double actual = b1.Area();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void BoxVolumeTester()
        {
            double expected = 2 * 3 * 4;
            Box b1 = new Box(2, 3, 4);
            double actual = b1.Volume();
            Assert.AreEqual(expected, actual);
        }
    }
}
