using System;

namespace ArcticProblem1
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(Int32.MinValue, null);

            TreeNode tn1 = new TreeNode(-100, root);
            TreeNode tn2 = new TreeNode(Int32.MaxValue, root);

            TreeNode tn4 = new TreeNode(Int32.MaxValue, tn1);

            //Action

            int expected = tn4.Sum;
            Console.WriteLine(expected);



        }
    }
}
