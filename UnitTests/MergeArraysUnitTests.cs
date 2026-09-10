using System;
using MergeArrays;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    [TestCategory("MergeArrays")]
         public class MergeArraysUnitTests
    {

        [TestMethod]
        public void TestMergeArraysForNulls()
        {
            int[] array1 = { };
            int[] array2 = { };
            int[] expectedResult = { };
            var result = Program.MergeSortedArrays(array1, array2);
            TestArraysForEquality(expectedResult, result);

        }

        [TestMethod]
        public void TestMergeArraysForNull1()
        {
            int[] array1 = { };
            int[] array2 = { 1, 2, 3, 9 };
            int[] expectedResult = { 1, 2, 3, 9 };
            var result = Program.MergeSortedArrays(array1, array2);
            TestArraysForEquality(expectedResult, result);

        }

        [TestMethod]
        public void TestMergeArraysForNull2()
        {
            int[] array1 = { 1, 2, 3, 9 };
            int[] array2 = { };
            int[] expectedResult = { 1, 2, 3, 9 };
            var result = Program.MergeSortedArrays(array1, array2);
            TestArraysForEquality(expectedResult, result);

        }

        [TestMethod]
        public void TestMergeArrays1()
        {
            int[] array1 = { 1, 2, 3, 9 };
            int[] array2 = { 4, 6, 10, 12, 14, 16, 18, 21 };
            int[] expectedResult = { 1, 2, 3, 4, 6, 9, 10, 12, 14, 16, 18, 21 };
            var result = Program.MergeSortedArrays(array1, array2);
            TestArraysForEquality(expectedResult, result);

        }

        [TestMethod]
        public void TestMergeArrays2()
        {
            int[] array1 = { 4, 6, 10, 12, 14, 16, 18, 21 };
            int[] array2 = { 1, 2, 3, 9 };
            int[] expectedResult = { 1, 2, 3, 4, 6, 9, 10, 12, 14, 16, 18, 21 };
            var result = Program.MergeSortedArrays(array1, array2);
            TestArraysForEquality(expectedResult, result);

        }

        [TestMethod]
        public void TestMergeArrays3()
        {
            int[] array1 = { 0, 0, 0, 0 };
            int[] array2 = { 0, 0, 0, 0 };
            int[] expectedResult = { 0, 0, 0, 0, 0, 0, 0, 0 };
            var result = Program.MergeSortedArrays(array1, array2);
            TestArraysForEquality(expectedResult, result);

        }

        [TestMethod]
        public void TestMergeArrays4()
        {
            int[] array1 = { 0, 0, 0, 0 };
            int[] array2 = { 1, 1, 1, 1 };
            int[] expectedResult = { 0, 0, 0, 0, 1, 1, 1, 1 };
            var result = Program.MergeSortedArrays(array1, array2);
            TestArraysForEquality(expectedResult, result);

        }

        [TestMethod]
        public void TestMergeArrays5()
        {
            int[] array1 = { 0, 2, 4, 6 };
            int[] array2 = { 1, 3, 5, 7 };
            int[] expectedResult = { 0, 1, 2, 3, 4, 5, 6, 7 };
            var result = Program.MergeSortedArrays(array1, array2);
            TestArraysForEquality(expectedResult, result);

        }

        private static void TestArraysForEquality(int[] expectedResult, int[] result)
        {
            Assert.AreEqual(expectedResult.Length, result.Length);

            for (int i = 0; i < expectedResult.Length; i++)
            {
                Assert.AreEqual(expectedResult[i], result[i]);
            }
        }
    }
}
