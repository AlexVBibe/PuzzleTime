/*
Invert a binary tree.

Example:

Input:

     4
   /   \
  2     7
 / \   / \
1   3 6   9
Output:

     4
   /   \
  7     2
 / \   / \
9   6 3   1
Trivia:
This problem was inspired by this original tweet by Max Howell:

Google: 90% of our engineers use the software you wrote (Homebrew), but you can’t invert a binary tree on a whiteboard so f*** off.
*/
using System;

namespace InvertBinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

     public class TreeNode {
         public int val;
         public TreeNode left;
         public TreeNode right;
         public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
             this.val = val;
             this.left = left;
             this.right = right;
         }
     }

    public class Solution
    {
        public TreeNode InvertTree(TreeNode root)
        {
            // 1. check node
            // 2. swap left and right, go left then go righ repeat
            if (root == null)
                return root;

            var left = root.left;
            root.left = root.right;
            root.right = left;
            if (root.left != null)
                InvertTree(root.left);
            if (root.right != null)
                InvertTree(root.right);

            return root;
        }
    }
}
