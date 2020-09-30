/*
You are given two non-empty linked lists representing two non-negative integers. 
The digits are stored in reverse order and each of their nodes contain a single digit. 
Add the two numbers and return it as a linked list.

You may assume the two numbers do not contain any leading zero, except the number 0 itself.

Example:
Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
Output: 7 -> 0 -> 8
Explanation: 342 + 465 = 807.
*/

using System;

namespace AddTwoNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

     public class ListNode
     {
         public int val;
         public ListNode next;
         public ListNode(int val=0, ListNode next=null)
         {
             this.val = val;
             this.next = next;
         }
     }

    public class Solution
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var root = new ListNode();
            var shiftNumber = 0;
            var node = root;
            while (l1 != null || l2 != null)
            {
                var x = l1?.val ?? 0;
                var y = l2?.val ?? 0;

                var newValue = x + y + shiftNumber;
                shiftNumber = newValue > 9 ? 1 : 0;
                if (shiftNumber != 0)
                    newValue = newValue - 10;

                node.next = new ListNode(newValue);
                node = node.next;

                l1 = l1?.next;
                l2 = l2?.next;
            }

            if (shiftNumber != 0)
                node.next = new ListNode(shiftNumber);

            return root.next;
        }
    }
}
