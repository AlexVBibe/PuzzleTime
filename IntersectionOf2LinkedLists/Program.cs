using System;

namespace IntersectionOf2LinkedLists
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
         public ListNode(int x) { val = x; }
     }

    public class Solution
    {
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            var a2b = headA;
            var b2a = headB;
            while (a2b != null && b2a != null)
            {
                if (a2b == b2a)
                    return a2b;
                a2b = a2b.next;
                if (a2b == null)
                {
                    a2b = headB;
                    headB = null;
                }
                b2a = b2a.next;
                if (b2a == null)
                {
                    b2a = headA;
                    headA = null;
                }
            }

            return null;
        }
    }
}
