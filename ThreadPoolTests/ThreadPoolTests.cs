using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace ThreadPoolLibrary
{
    [TestClass]
    public class ThreadPoolTests
    {
        [TestMethod]
        public void SeveralTask_CheckOrder()
        {
            //Arrange
            Resource resA = new Resource("A");
            Resource resB = new Resource("B");
            Resource resC = new Resource("C");
            Resource resD = new Resource("D");

            Task item1 = new MyTask(new Resource[] { resA }, 1, 100);
            Task item2 = new MyTask(new Resource[] { resB }, 2, 100);
            Task item3 = new MyTask(new Resource[] { resA, resB }, 3, 200);
            Task item4 = new MyTask(new Resource[] { resC }, 4, 300);
            Task item5 = new MyTask(new Resource[] { resB }, 5, 400);

            //Act
            MyThreadPool.Dispach(item1);
            MyThreadPool.Dispach(item2);
            MyThreadPool.Dispach(item3);
            MyThreadPool.Dispach(item4);
            MyThreadPool.Dispach(item5);

            //Wait for Tasks to finsih
            Thread.Sleep(1000);

            //Assert
           
            Assert.IsTrue( Math.Abs(item3.StartTime - item1.StartTime) > 100);

        }


        [TestMethod]
        public void SeveralTask_CheckOrder_2()
        {
            //Arrange
            Resource resA = new Resource("A");
            Resource resB = new Resource("B");
            Resource resC = new Resource("C");
            Resource resD = new Resource("D");

            Task item1 = new MyTask(new Resource[] { resA }, 1, 100);
            Task item2 = new MyTask(new Resource[] { resB }, 2, 100);
            Task item3 = new MyTask(new Resource[] { resA, resB }, 3, 200);
            Task item4 = new MyTask(new Resource[] { resC }, 4, 300);
            Task item5 = new MyTask(new Resource[] { resB }, 5, 400);

            //Act
            MyThreadPool.Dispach(item1);
            MyThreadPool.Dispach(item2);
            MyThreadPool.Dispach(item3);
            MyThreadPool.Dispach(item4);
            MyThreadPool.Dispach(item5);

            //Wait for Tasks to finsih
            Thread.Sleep(1000);

            //Assert

            Assert.IsTrue(Math.Abs(item3.StartTime - item2.StartTime) > 100);

        }

        [TestMethod]
        public void TwoTasks_SameResource_CheckOrder()
        {
            //Arrange
            Resource resA = new Resource("A");
            Task item1 = new MyTask(new Resource[] { resA }, 1, 200);
            Task item2 = new MyTask(new Resource[] { resA }, 2, 100);
           
            //Action
            MyThreadPool.Dispach(item1);
            MyThreadPool.Dispach(item2);
            //Wait Tasks to finish
            Thread.Sleep(300);

            //Assert
            Assert.IsTrue(Math.Abs(item1.StartTime - item2.StartTime) >= 200);

        }

        [TestMethod]
        public void TwoTasks_SameResource_checkConcurrentThreads()
        {
            //Arrange
            Resource resA = new Resource("A");
            Task item1 = new MyTask(new Resource[] { resA }, 1, 200);
            Task item2 = new MyTask(new Resource[] { resA }, 2, 100);

            //Action
            MyThreadPool.Dispach(item1);
            MyThreadPool.Dispach(item2);
            Thread.Sleep(5);
            Assert.IsTrue(resA.NumberOfConcurrentAccess == 1);

            //Assert
           // Assert.IsTrue(Math.Abs(item1.StartTime - item2.StartTime) > 200);

        }
    }
}
