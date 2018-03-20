using System;
using GeeksForGeeks.Hard;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class GeeksForGeeksTest
    {
        [TestMethod]
        public void Test_LargeNumberSummation()
        {

        }

        [TestMethod]
        public void Test_Adventure_Maze()
        {
           //var a= AdventureMaze.FeedInput(5);
           // AdventureMaze.FindPath(5, a);

            int[,] b = new int[,] { { 3, 1, 2 }, { 2, 1, 2 }, { 1, 1, 2 } };

             b = new int[,] { { 3, 2, 2 }, { 2, 1, 1 }, { 1, 1, 3 } };
             b = new int[,] { { 3, 3, 3 }, { 3, 3, 3 }, { 3, 3, 3 } };

           var r= AdventureMaze.FindPath(3,b);
        }
    }
}
