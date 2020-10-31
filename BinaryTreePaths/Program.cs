/*
Given a binary tree, return all root-to-leaf paths.
Note: A leaf is a node with no children.

Example:
Input:
   1
 /   \
2     3
 \
  5

Output: ["1->2->5", "1->3"]
Explanation: All root-to-leaf paths are: 1->2->5, 1->3
*/

using System;
using System.Collections.Generic;

namespace BinaryTreePaths
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

     public class TreeNode
     {
         public int val;
         public TreeNode left;
         public TreeNode right;
         public TreeNode(int val=0, TreeNode left=null, TreeNode right=null)
         {
             this.val = val;
             this.left = left;
             this.right = right;
         }
     }

    public class Solution
    {
        public IList<string> BinaryTreePaths(TreeNode root)
        {
            var result = new List<string>();
            TreeWalker(root, "", result);
            return result;
        }

        private void TreeWalker(TreeNode node, string path, IList<string> result)
        {
            if (node == null)
                return;

            path = path + node.val.ToString();
            if (node.left != null)
                TreeWalker(node.left, path + "->", result);

            if (node.right != null)
                TreeWalker(node.right, path + "->", result);

            if (node.left == null && node.right == null)
                result.Add(path);
        }
    }
}
