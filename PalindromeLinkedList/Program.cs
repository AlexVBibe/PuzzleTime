/*
 Given a singly linked list, determine if it is a palindrome.

Example 1:
Input: 1->2
Output: false

Example 2:
Input: 1->2->2->1
Output: true
Follow up:
Could you do it in O(n) time and O(1) space?
 */

using System;

namespace PalindromeLinkedList
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
        public bool IsPalindrome(ListNode head)
        {
            if (head == null)
                return true;

            var slow = head;
            var fast = head;
            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
            }

            fast = head;
            slow = Reverse(slow);
            while (slow != null)
            {
                if (fast?.val != slow?.val)
                    return false;
                fast = fast.next;
                slow = slow.next;
            }
            return true;
        }

        public ListNode Reverse(ListNode head)
        {
            ListNode previous = null;
            var node = head;
            while (node != null)
            {
                var next = node.next;
                node.next = previous;
                previous = node;
                node = next;
            }

            return previous;
        }
    }
}
