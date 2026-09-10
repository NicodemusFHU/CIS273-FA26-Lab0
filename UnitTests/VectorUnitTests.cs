using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vector;

namespace UnitTests
{
    [TestClass]
    [TestCategory("Vector")]
    public class VectorUnitTests
    {
        [TestMethod]
        public void TestMagnitude()
        {
            Vector.Vector v1 = new Vector.Vector() { X = 4.0, Y = 3.0 };
            Assert.AreEqual(v1.Magnitude, 5.0);

            Vector.Vector v2 = new Vector.Vector() { X = -4.0, Y = -4.0 };
            Assert.AreEqual(v2.Magnitude, Math.Sqrt(32));

        }

        [TestMethod]
        public void TestDirection()
        {

            Vector.Vector v1 = new Vector.Vector() { X = 4.0, Y = 4.0 };
            Assert.AreEqual(v1.Direction, 45.0);

            Vector.Vector v2 = new Vector.Vector() { X = -4.0, Y = -4.0 };
            Assert.AreEqual(v2.Direction, -135.0);

        }

        [TestMethod]
        public void TestConstructor()
        {
            Vector.Vector v1 = new Vector.Vector(3, 5);
            Vector.Vector expected = new Vector.Vector() { X = 3, Y = 5 };
            Assert.AreEqual(expected, v1);
        }

        [TestMethod]
        public void TestAdd()
        {
            Vector.Vector v1 = new Vector.Vector() { X = 4.0, Y = 4.0 };
            Vector.Vector v2 = new Vector.Vector() { X = -4.0, Y = -4.0 };
            Vector.Vector result = new Vector.Vector() { X = 0, Y = 0 };
            Assert.AreEqual(result, v1.Add(v2));

            Vector.Vector result2 = new Vector.Vector() { X = 8, Y = 8 };
            Assert.AreEqual(result2, v1.Add(v1));
        }

        [TestMethod]
        public void TestSubtract()
        {

            Vector.Vector v1 = new Vector.Vector() { X = 4.0, Y = 4.0 };
            Vector.Vector v2 = new Vector.Vector() { X = 4.0, Y = -4.0 };
            Vector.Vector result = new Vector.Vector() { X = 0, Y = 8.0 };
            Assert.AreEqual(result, v1.Subtract(v2));
        }

        [TestMethod]
        public void TestDot()
        {
            Vector.Vector v1 = new Vector.Vector() { X = 4.0, Y = 3.0 };
            Vector.Vector v2 = new Vector.Vector() { X = 5.0, Y = 10.0 };
            double result = 50;
            Assert.AreEqual(result, v1.Dot(v2));

            v1 = new Vector.Vector() { X = -1.0, Y = 3.0 };
            v2 = new Vector.Vector() { X = 4.0, Y = -5.0 };
            result = -19;
            Assert.AreEqual(result, v1.Dot(v2));

        }

        [TestMethod]
        public void TestAngleBetween()
        {
            Vector.Vector v1 = new Vector.Vector() { X = 4.0, Y = 3.0 };
            Vector.Vector v2 = new Vector.Vector() { X = 5.0, Y = 10.0 };
            double result = 26.56505;
            Assert.AreEqual(result, v1.AngleBetween(v2), 1e-3);

            v1 = new Vector.Vector() { X = -1.0, Y = 3.0 };
            v2 = new Vector.Vector() { X = 4.0, Y = -5.0 };
            result = 159.77514;
            Assert.AreEqual(result, v1.AngleBetween(v2), 1e-3);
        }

        [TestMethod]
        public void TestMultiply()
        {
            Vector.Vector v1 = new Vector.Vector() { X = 4.0, Y = 3.0 };
            Vector.Vector expected = new Vector.Vector() { X = 8.0, Y = 6.0 };
            Assert.AreEqual(expected, v1.Multiply(2));
        }

        [TestMethod]
        public void TestDivide()
        {
            Vector.Vector v1 = new Vector.Vector() { X = 4.0, Y = 3.0 };
            Vector.Vector expected = new Vector.Vector() { X = 2.0, Y = 1.5 };
            Assert.AreEqual(expected, v1.Divide(2));
        }

        [TestMethod]
        public void TestNormalize()
        {
            Vector.Vector v1 = new Vector.Vector() { X = 4.0, Y = 3.0 };
            Vector.Vector expected = new Vector.Vector() { X = 0.8, Y = 0.6 };
            Assert.AreEqual(expected, v1.Normalize());
        }

        [TestMethod]
        public void TestToString()
        {
            Vector.Vector v1 = new Vector.Vector() { X = 4.0, Y = 3.0 };
            string expected = "<4, 3>";
            Assert.AreEqual(expected, v1.ToString());

            Vector.Vector v2 = new Vector.Vector() { X = 4.0, Y = -5.0 };
            expected = "<4, -5>";
            Assert.AreEqual(expected, v2.ToString());

        }

        [TestMethod]
        public void TestStaticMethods()
        {
            Vector.Vector v1 = new Vector.Vector() { X = 4.0, Y = 3.0 };
            Vector.Vector v2 = new Vector.Vector() { X = 5.0, Y = 10.0 };
            double dotProduct = 50;
            Assert.AreEqual(dotProduct, Vector.Vector.Dot(v1, v2));
            Assert.AreEqual(dotProduct, v1 * v2);

            v1 = new Vector.Vector() { X = -1.0, Y = 3.0 };
            v2 = new Vector.Vector() { X = 4.0, Y = -5.0 };
            Vector.Vector sum = new Vector.Vector() { X = 3, Y = -2 };
            Assert.AreEqual(sum, Vector.Vector.Add(v1, v2));
            Assert.AreEqual(sum, v1 + v2);

            v1 = new Vector.Vector() { X = -1.0, Y = 3.0 };
            v2 = new Vector.Vector() { X = 4.0, Y = -5.0 };
            Vector.Vector difference = new Vector.Vector() { X = -5.0, Y = 8.0 };
            Assert.AreEqual(difference, Vector.Vector.Subtract(v1, v2));
            Assert.AreEqual(difference, v1 - v2);

        }

        [TestMethod]
        public void TestStaticAngleBetween()
        {
            Vector.Vector v1 = new Vector.Vector() { X = 4.0, Y = 3.0 };
            Vector.Vector v2 = new Vector.Vector() { X = 5.0, Y = 10.0 };
            double result = 26.56505;
            Assert.AreEqual(result, Vector.Vector.AngleBetween(v1, v2), 1e-3);
        }

        [TestMethod]
        public void TestStaticMultiply()
        {
            Vector.Vector v1 = new Vector.Vector() { X = 4.0, Y = 3.0 };
            Vector.Vector expected = new Vector.Vector() { X = 8.0, Y = 6.0 };
            Assert.AreEqual(expected, Vector.Vector.Multiply(v1, 2));
        }

        [TestMethod]
        public void TestStaticDivide()
        {
            Vector.Vector v1 = new Vector.Vector() { X = 4.0, Y = 3.0 };
            Vector.Vector expected = new Vector.Vector() { X = 2.0, Y = 1.5 };
            Assert.AreEqual(expected, Vector.Vector.Divide(v1, 2));
        }

        [TestMethod]
        public void TestStaticNormalize()
        {
            Vector.Vector v1 = new Vector.Vector() { X = 4.0, Y = 3.0 };
            Vector.Vector expected = new Vector.Vector() { X = 0.8, Y = 0.6 };
            Assert.AreEqual(expected, Vector.Vector.Normalize(v1));
        }
    }
}
