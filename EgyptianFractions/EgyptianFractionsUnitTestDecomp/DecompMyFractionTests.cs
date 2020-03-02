using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Text;
using System;

namespace EgyptianFractions.Tests
{
    //  Fixed Tests
    //      num, denom: 4, 5; num, denom: 66, 100; num, denom: 22, 23; num, denom: 1001, 3456; 
    //      num, denom: 16, 17; num, denom: 0, 2; num, denom: 30, 45; num, denom: 125, 100; num, denom: 75, 3; num, denom: 2, 8; 
    //      num, denom: 9, 10; num, denom: 5, 6; num, denom: 81, 82; num, denom: 45, 30; num, denom: 13, 12; num, denom: 134, 162; 
    //      num, denom: 1340, 1620; num, denom: 14, 15; num, denom: 50, 4187; num, denom: 40, 35; num, denom: 7, 35; num, denom: 0, 1000; 

    [TestClass()]
    public class DecompMyFractionTests
    {
        [TestMethod]
        public void Test_Decomp_Greedy()
        {
            Queue<double> empty = new Queue<double>();
            Queue<double> denoms = new Queue<double>();
            StringBuilder sb = new StringBuilder();
            denoms = Decomp.GreedyAlgo(3, 4, empty);
            while (denoms.Count > 0)
            {
                sb.Append(denoms.Dequeue().ToString());
                if (denoms.Count > 0)
                {
                    sb.Append(", ");
                }
            }
            Assert.AreEqual("2, 4", sb.ToString());
        }

        [TestMethod]
        public void Test_Decomp_GetGCD()
        {
            Assert.AreEqual(20, Decomp.GetGCD(20, 100));
        }

        [TestMethod]
        public void Test_Decomp_Difference()
        {
            double expectedDiffNumer = 0;
            double expectedDenom = 8;
            double diffNumer = Decomp.Difference(1, 2, 2, 4, out double denom);
            bool diffNumersMatch = false;
            bool denomIsProduct = false;
            if (diffNumer == expectedDiffNumer)
            {
                diffNumersMatch = true;
            }
            if (denom == expectedDenom)
            {
                denomIsProduct = true;
            }
            Console.WriteLine($"diffNumer: { diffNumer }, out denom: { denom }.");
            Assert.AreEqual(diffNumersMatch, denomIsProduct);
        }

        [TestMethod]
        public void Test_Decomp_Mike()
        {
            Assert.AreEqual("[1, 1/2]", Decomp.Decompose("45", "30"));
        }

        [TestMethod]
        public void Test_Decomp_Lima()
        {
            Assert.AreEqual("[1/5]", Decomp.Decompose("7", "35"));
        }

        [TestMethod]
        public void Test_Decomp_Kilo()
        {
            Assert.AreEqual("[1/2, 1/3, 1/9, 1/83, 1/34362]", Decomp.Decompose("22", "23"));
        }

        [TestMethod]
        public void Test_Decomp_Juliet()
        {
            Assert.AreEqual("[1/2, 1/7, 1/59, 1/5163, 1/53307975]", Decomp.Decompose("66", "100"));
        }

        [TestMethod]
        public void Test_Decomp_India()
        {
            Assert.AreEqual("[1/2, 1/4, 1/20]", Decomp.Decompose("4", "5"));
        }

        [TestMethod()]
        public void Test_Decomp_Alpha()
        {
            Assert.AreEqual("[1]", Decomp.Decompose("4", "4"));
        }

        [TestMethod()]
        public void Test_Decomp_Bravo()
        {
            Assert.AreEqual("[1, 1/4]", Decomp.Decompose("125", "100"));
        }

        [TestMethod()]
        public void Test_Decomp_Charlie()
        {
            Assert.AreEqual("[1/4, 1/26, 1/848, 1/2381184]", Decomp.Decompose("1001", "3456"));
        }

        [TestMethod]
        public void Test_Decomp_Delta()
        {
            Assert.AreEqual("[1/2, 1/4]", Decomp.Decompose("3", "4"));
        }

        [TestMethod]
        public void Test_Decomp_Echo()
        {
            Assert.AreEqual("[3]", Decomp.Decompose("12", "4"));
        }

        [TestMethod]
        public void Test_Decomp_Foxtrot()
        {
            Assert.AreEqual("[]", Decomp.Decompose("0", "2"));
        }

        [TestMethod]
        public void Test_Decomp_Golf()
        {
            Assert.AreEqual("[1/2, 1/3, 1/15]", Decomp.Decompose("9", "10"));
        }

        [TestMethod()]
        public void Test_Decomp_Hotel()
        {
            Assert.AreEqual("[1/2, 1/3, 1/13, 1/359, 1/644046]", Decomp.Decompose("21", "23"));
        }
    }
}