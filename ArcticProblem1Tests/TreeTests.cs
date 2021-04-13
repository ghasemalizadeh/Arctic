using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ArcticProblem1
{
    [TestClass]
    public class TreeTests
    {
        [TestMethod]
        public void Test_Tree_Valid_Values()
        {
            //Arrange
            TreeNode root = new TreeNode(5, null);

            TreeNode tn1 = new TreeNode(4, root);
            TreeNode tn2 = new TreeNode(3, root);

            TreeNode tn4 = new TreeNode(2, tn1);
            int expected = 11;

            //Action
            int actual = tn4.Sum;
            //Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void BorderValues_MaxValue_ThrowException()
        {
            //Arrange
            TreeNode root = new TreeNode(int.MaxValue, null);

            TreeNode tn1 = new TreeNode(100, root);
            TreeNode tn2 = new TreeNode(3, root);

            TreeNode tn4 = new TreeNode(2, tn1);
           

            //Action
            int actual = tn4.Sum;
           

        }




        [TestMethod]
        public void BorderValues_MaxValue_Valid()
        {
            //Arrange
            TreeNode root = new TreeNode(int.MaxValue, null);

            TreeNode tn1 = new TreeNode(-100, root);
            TreeNode tn2 = new TreeNode(3, root);

            TreeNode tn4 = new TreeNode(100, tn1);
            int expected = Int32.MaxValue;
            //Action
            int actual = tn4.Sum;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BorderValues_MinValue_Valid()
        {
            //Arrange
            TreeNode root = new TreeNode(int.MinValue, null);

            TreeNode tn1 = new TreeNode(100, root);
            TreeNode tn2 = new TreeNode(3, root);

            TreeNode tn4 = new TreeNode(-100, tn1);
            int expected = Int32.MinValue;

            //Action
            int actual = tn4.Sum;
            //Assert
            Assert.AreEqual(expected, actual);
        }



        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void BorderValues_MinValue_ThrowException()
        {
            //Arrange
            TreeNode root = new TreeNode(int.MinValue, null);

            TreeNode tn1 = new TreeNode(-1000, root);
            TreeNode tn2 = new TreeNode(3, root);

            TreeNode tn4 = new TreeNode(2, tn1);
            

            //Action
            int actual =tn4.Sum;
           

        }


    }
}
