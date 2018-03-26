using System;
using GeeksForGeeks.DataStructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.DataStructure
{
    [TestClass]
    public class LinkedListTest
    {
        [TestMethod]
        public void Insert_Test()
        {
            LinkedList<int> linkedList = new LinkedList<int>();
            linkedList.InsertFront(25);
            linkedList.InsertFront(15);
            linkedList.InsertFront(5);
            linkedList.InsertAfter(15);
            var node= linkedList.InsertAfter(50);


            //linkedList.InsertTail(50);
            //linkedList.InsertTail(60);
            //linkedList.InsertTail(70);
            //linkedList.InsertTail(60);
            //linkedList.InsertTail(800);

            //linkedList.DeteteFront();
            //linkedList.DeleteTail();
            //linkedList.Delete(25);


            var result = linkedList.ToString();
            var count = linkedList.Size;
            linkedList.InsertFront(25);
            linkedList.InsertTail(60);

            foreach (var item in linkedList)
            {

            }
        }
    }
}
