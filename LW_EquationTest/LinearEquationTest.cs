using System;
using LW_Equation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LW_EquationTest
{
    [TestClass]
    public class LinearEquationTests
    {
        [TestMethod]
        public void LinearEquationTestEquals()
        {
            LinearEquation A = new LinearEquation(1, 2);
            LinearEquation B = new LinearEquation(1, 2);
            LinearEquation C = new LinearEquation(1, 3);

            bool resultA_B = A == B;
            bool resultA_C = A == C;
            bool resultC_B = C == B;

            Assert.AreEqual(true, resultA_B);
            Assert.AreEqual(false, resultA_C);
            Assert.AreEqual(false, resultC_B);
        }
        [TestMethod]
        public void LinearEquationTestEqualsDiffSize()
        {
            LinearEquation a = new LinearEquation(1, 2, 3);
            LinearEquation b = new LinearEquation(1, 2);

            bool result = a == b;

            Assert.AreEqual(false, result);
        }
        [TestMethod]
        public void LinearEquationTestNotEquals()
        {
            LinearEquation a = new LinearEquation(1, 3);
            LinearEquation b = new LinearEquation(1, 2);

            bool result = a != b;

            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public void LinearEquationTestNotEqualsDiffSize()
        {
            LinearEquation a = new LinearEquation(1, 2, 3);
            LinearEquation b = new LinearEquation(1, 2);

            bool result = a != b;

            Assert.AreEqual(true, result);
        }
        [TestMethod]
        public void LinearEquationTestIndexer()
        {
            LinearEquation a = new LinearEquation(1, 2, 3);

            Assert.AreEqual(1, a[0]);
            Assert.AreEqual(2, a[1]);
            Assert.AreEqual(3, a[2]);
        }
        [TestMethod]
        public void LinearEquationTestIndexerException()
        {
            LinearEquation a = new LinearEquation(1, 2);

            Exception resultLeft = Assert.ThrowsException<ArgumentOutOfRangeException>(() => a[-1]);
            Exception resultRight = Assert.ThrowsException<ArgumentOutOfRangeException>(() => a[2]);

            Assert.IsInstanceOfType(resultLeft, typeof(ArgumentOutOfRangeException));
            Assert.IsInstanceOfType(resultRight, typeof(ArgumentOutOfRangeException));
        }
        [TestMethod]
        public void LinearEquationTestOpeartorEqPlusFloat()
        {
            LinearEquation a = new LinearEquation(1, 2, 3);
            float b = 5.4F;

            LinearEquation result = a + b;

            Assert.AreEqual(new LinearEquation(1, 2, 8.4F), result);
        }
        [TestMethod]
        public void LinearEquationTestOpeartorEqPlusFloat2()
        {
            LinearEquation a = new LinearEquation(1, 2);
            float b = 5.4F;

            LinearEquation result = a + b;

            Assert.AreEqual(new LinearEquation(1, 7.4F), result);
        }
        [TestMethod]
        public void LinearEquationTestOpeartorEqPlusFloat3()
        {
            LinearEquation a = new LinearEquation(1, 2);
            float b = 1F;

            LinearEquation result = a + b;

            Assert.AreEqual(new LinearEquation(1, 3F), result);
        }
        [TestMethod]
        public void LinearEquationTestOpeartorEqPlusFloat4()
        {
            LinearEquation a = new LinearEquation(1, 2);
            float b = -1F;

            LinearEquation result = a + b;

            Assert.AreEqual(new LinearEquation(1, 1F), result);
        }
        [TestMethod]
        public void LinearEquationTestOpeartorEqMinusFloat()
        {
            LinearEquation a = new LinearEquation(1, 2, 3);
            float b = 5.4F;

            LinearEquation result = a - b;

            Assert.AreEqual(new LinearEquation(1, 2, -2.4F), result);
        }
        [TestMethod]
        public void LinearEquationTestOpeartorEqMinusFloat2()
        {
            LinearEquation a = new LinearEquation(1, 2, 3);
            float b = -5.4F;

            LinearEquation result = a - b;

            Assert.AreEqual(new LinearEquation(1, 2, 8.4F), result);
        }
        [TestMethod]
        public void LinearEquationTestOpeartorEqMinusFloat3()
        {
            LinearEquation a = new LinearEquation(1, 2);
            float b = 5.4F;

            LinearEquation result = a - b;

            Assert.AreEqual(new LinearEquation(1, -3.4F), result);
        }
        [TestMethod]
        public void LinearEquationTestOpeartorEqMinusFloat4()
        {
            LinearEquation a = new LinearEquation(1, 3);
            float b = -5.4F;

            LinearEquation result = a - b;

            Assert.AreEqual(new LinearEquation(1, 8.4F), result);
        }
        [TestMethod]
        public void LinearEquationTestOpeartorEqMinusFloat5()
        {
            LinearEquation a = new LinearEquation(1, 3);
            float b = -1F;

            LinearEquation result = a - b;

            Assert.AreEqual(new LinearEquation(1, 4F), result);
        }
        [TestMethod]
        public void LinearEquationTestOpeartorEqMinusFloat6()
        {
            LinearEquation a = new LinearEquation(1, 3);
            float b = 1F;

            LinearEquation result = a - b;

            Assert.AreEqual(new LinearEquation(1, 2F), result);
        }
        [TestMethod]
        public void LinearEquationTestOpeartorEqMinusFloat7()
        {
            LinearEquation a = new LinearEquation(1, 3);
            LinearEquation b = new LinearEquation(3, 4);

            LinearEquation result = a + b;

            Assert.AreEqual(4, result[0]);
            Assert.AreEqual(7, result[1]);
        }
        [TestMethod]
        public void LinearEquationTestOpeartorEqMinusFloat8()
        {
            LinearEquation a = new LinearEquation(1, 3);
            LinearEquation b = new LinearEquation(3, 4);

            LinearEquation result = a - b;

            Assert.AreEqual(-2, result[0]);
            Assert.AreEqual(-1, result[1]);
        }
        [TestMethod]
        public void LinearEquationTestOpeartorEqMinusFloat9()
        {
            LinearEquation a = new LinearEquation(0, 3);
            LinearEquation b = new LinearEquation(2, 4);

            Assert.AreEqual(a, false);
            Assert.AreEqual(b, true);
        }
        [TestMethod]
        public void LinearEquationTestOpeartorEqMinusFloat10()
        {
            LinearEquation a = new LinearEquation(1, 3);
            LinearEquation b = new LinearEquation(0,4);

            Assert.AreEqual(a.GetSolution(a), -3);
            Assert.AreEqual(b.GetSolution(b), null);
        }
        [TestMethod]
        public void LinearEquationTestOpeartorEqMinusFloat11()
        {
            LinearEquation a = new LinearEquation(0, 3);
            LinearEquation b = new LinearEquation(1,2,3,7);

            Assert.AreEqual(a.EquationToString(a), "0x + 3 = 0");
            Assert.AreEqual(b.EquationToString(b), "1x + 2y + 3z + 7 = 0");
        }
        [TestMethod]
        public void LinearEquationTestOpeartorEqMinusFloat12()
        {
            LinearEquation a = new LinearEquation(1, 2, 3, 4,5,6);
            a.InitializeRandom(a);

            bool isRand = ((a[0] != 1) || (a[1] != 2) || (a[2] != 3) || (a[3] != 4) || (a[4] != 5) || (a[5] != 6) || (a[6] != 7));
            Assert.IsTrue(isRand);
        }
        [TestMethod]
        public void LinearEquationTestOpeartorEqMinusFloat13()
        {
            LinearEquation a = new LinearEquation(1, 2, 3, 4);
            a.InitializeSame(a,2);

            bool isSame = ((a[0] == 2) && (a[1] == 2) && (a[2] == 2) && (a[3] == 2));
            Assert.IsTrue(isSame);
        }
        [TestMethod]
        public void LinearEquationTestOpeartorEqMinusFloat14()
        {
            LinearEquation a = new LinearEquation(1, 2, 3);
            a.Multiplication(a, 4);

            bool isMultiplicate = ((a[0] == 4) && (a[1] == 8) && (a[2] == 12));
            Assert.IsTrue(isMultiplicate);
        }
    }
}
