using Microsoft.VisualStudio.TestTools.UnitTesting;
using TriangleTest.Models;
using TriangleTest.Services;

namespace UnitTests
{
    [TestClass]
    public class TriangleTests
    {
        [TestMethod]
        public void A1Test()
        {
            var triangle = TriangleService.GetTriangle('a', 1);
            Assert.IsTrue(triangle.V1x == 0);
            Assert.IsTrue(triangle.V1y == 50);
            Assert.IsTrue(triangle.V2x == 0);
            Assert.IsTrue(triangle.V2y == 60);
            Assert.IsTrue(triangle.V3x == 10);
            Assert.IsTrue(triangle.V3y == 50);
        }
        [TestMethod]
        public void A2Test()
        {
            var triangle = TriangleService.GetTriangle('a', 2);
            Assert.IsTrue(triangle.V1x == 10);
            Assert.IsTrue(triangle.V1y == 50);
            Assert.IsTrue(triangle.V2x == 0);
            Assert.IsTrue(triangle.V2y == 60);
            Assert.IsTrue(triangle.V3x == 10);
            Assert.IsTrue(triangle.V3y == 60);

        }
        [TestMethod]
        public void C6Test()
        {
            var triangle = TriangleService.GetTriangle('c', 6);
            Assert.IsTrue(triangle.V1x == 30);
            Assert.IsTrue(triangle.V1y == 30);

            Assert.IsTrue(triangle.V2x == 20);
            Assert.IsTrue(triangle.V2y == 40);

            Assert.IsTrue(triangle.V3x == 30);
            Assert.IsTrue(triangle.V3y == 40);
        }
        [TestMethod]
        public void F9Test()
        {
            var triangle = TriangleService.GetTriangle('f', 9);
            Assert.IsTrue(triangle.V1x == 40);
            Assert.IsTrue(triangle.V1y == 0);

            Assert.IsTrue(triangle.V2x == 40);
            Assert.IsTrue(triangle.V2y == 10);

            Assert.IsTrue(triangle.V3x == 50);
            Assert.IsTrue(triangle.V3y == 0);
        }

        [TestMethod]
        public void RowColumnA1Test()
        {
            Triangle t = new Triangle();
            t.V1x = 0;
            t.V1y = 50;
            t.V2x = 0;
            t.V2y = 60;
            t.V3x = 10;
            t.V3y = 50;
            //Should Return A 1;
            string result = TriangleService.GetRowAndColumn(t);
            Assert.IsTrue(result == "Row is A and Column is 1");
        }

        [TestMethod]
        public void RowColumnC6Test()
        {
            Triangle triangle = new Triangle();
            triangle.V1x = 30;
            triangle.V1y = 30;

            triangle.V2x = 20;
            triangle.V2y = 40;

            triangle.V3x = 30;
            triangle.V3y = 40;
            //Should Return C6;
            string result = TriangleService.GetRowAndColumn(triangle);
            Assert.IsTrue(result == "Row is C and Column is 6");
        }
    }
}
