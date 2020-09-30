/*
Remove all elements from a linked list of integers that have value val.
Example:
Input:  1->2->6->3->4->5->6, val = 6
Output: 1->2->3->4->5
*/

using System;

namespace RemoveLinkedListElements
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

     public class ListNode {
         public int val;
         public ListNode next;
         public ListNode(int val=0, ListNode next=null) {
             this.val = val;
             this.next = next;
         }
     }

    public class Solution
    {
        public ListNode RemoveElements(ListNode head, int val)
        {
            if (head == null)
                return head;

            var node = head;
            while (node.next != null)
            {
                var n = node.next;
                if (n.val == val)
                    node.next = n.next;
                else
                    node = node.next;
            }

            return head.val == val ? head.next : head;
        }
    }
}
