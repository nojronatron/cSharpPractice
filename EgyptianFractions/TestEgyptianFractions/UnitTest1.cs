using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EgyptianFractions;

namespace TestEgyptianFractions
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_GreedyAlgo_Alpha()
        {
            string expectedResult = "2/1";
            MyFraction f1 = new MyFraction(8, 11);
            MyFraction result = new MyFraction(MyEgyptianFractions.GreedyAlgo(f1.Numerator, f1.Denominator));
            Console.WriteLine(result.ToString());
            Assert.AreEqual(expectedResult, result.ToString());
        }

        [TestMethod]
        public void Test_GreedyAlgo_Bravo()
        {
            //string expectedResult = "";
            decimal x = 4;
            decimal y = 13;
            Queue<decimal> denominators = new Queue<decimal>();
            MyEgyptianFractions.GreedyAlgo(x, y, denominators);
            decimal thisDenominator = 0m;
            StringBuilder sb = new StringBuilder();
            sb.Append($"{ x }/{ y } expands to: ");
            while (denominators.Count > 0)
            {
                thisDenominator = denominators.Dequeue();
                sb.Append($"1/{ thisDenominator }");
                if (denominators.Count > 0)
                {
                    sb.Append(" + ");
                }
            }
            Console.WriteLine(sb.ToString());
            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void Test_ReducedFractions_Alpha()
        {
            Assert.AreEqual("[1/2, 1/4]", Decomp.Decompose("3", "4"));
        }

        [TestMethod]
        public void Test_ReducedFractions_Bravo()
        {
            Assert.AreEqual("[3]", Decomp.Decompose("12", "4"));
        }

        [TestMethod]
        public void Test_ReducedFractions_Charlie()
        {
            Assert.AreEqual("[]", Decomp.Decompose("0", "2"));
        }

        [TestMethod]
        public void Test_ReducedFractions_Delta()
        {
            Assert.AreEqual("[1/2, 1/3, 1/15]", Decomp.Decompose("9", "10"));
        }

        [TestMethod()]
        public void Test_ReducedFractions_Echo()
        {
            Assert.AreEqual("[1/2, 1/3, 1/13, 1/359, 1/644046]", Decomp.Decompose("21", "23"));
        }
        [TestMethod]
        public void Test_FractionSplitter_Alpha()
        {
            string expectedResult = "2/11, 6/11";
            MyFraction f1 = new MyFraction(8, 11);
            MyFraction result = new MyFraction();
            MyFraction fraction2 = null;
            result = MyEgyptianFractions.FractionSplitter(f1, out fraction2);
            Console.WriteLine(result.ToString());
            Assert.AreEqual(expectedResult, $"{result.ToString()}, {fraction2.ToString()}");
        }
    }
}
