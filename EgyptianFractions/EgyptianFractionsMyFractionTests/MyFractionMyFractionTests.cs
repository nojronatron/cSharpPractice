using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EgyptianFractions.Tests
{
    [TestClass()]
    public class MyFractionMyFractionTests
    {
        [TestMethod()]
        public void MyFractionTest_CreatesMyFractionObject()
        {
            MyFraction mf = new MyFraction();
            string expectedResult = "EgyptianFractions.MyFraction";
            string actualResult = mf.GetType().FullName.ToString();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod()]
        public void MyFractionTest_CtorDoublesBuildFraction()
        {
            MyFraction mf = new MyFraction(1, 3);
            string expectedResult = "1/3";
            string actualResult = mf.ToString();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod()]
        public void DecimalEquivalentTest()
        {
            MyFraction mf = new MyFraction(1, 4);
            decimal expectedResult = 0.25m;
            decimal actualResult = mf.DecimalEquivalent();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod()]
        public void IsImproperTest_True()
        {
            MyFraction mf = new MyFraction(4, 3);
            Assert.IsTrue(mf.IsImproper());
        }

        [TestMethod()]
        public void IsImproperTest_False()
        {
            MyFraction mf = new MyFraction(3, 4);
            Assert.IsFalse(mf.IsImproper());
        }

        [TestMethod()]
        public void GetImproperFractionTest()
        {
            MyFraction mf = new MyFraction(4, 3);
            string expectedResult = "1 1/3";
            string actualResult = mf.GetImproperFraction();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod()]
        public void DifferenceTest()
        {
            MyFraction mf1 = new MyFraction(1, 2);
            MyFraction mf2 = new MyFraction(3, 4);
            string expectedResult = "1/4";
            MyFraction mfDiff = mf1.Difference(mf2);
            string actualResult = mfDiff.ToString();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod()]
        public void DecimalTypeToFractionAlpha()
        {
            MyFraction mf = new MyFraction(0.75);
            string expectedResult = "3/4";
            string actualResult = mf.ToString();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod()]
        public void DecimalTypeToFractionBravo()
        {
            MyFraction mf = new MyFraction(0.9);
            string expectedResult = "9/10";
            string actualResult = mf.ToString();
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}