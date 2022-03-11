using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchingAndSorting
{
    internal class Merge_Sort_Singly_Linked_List
    {
        public class ListNode
        {
            public int data;
            public ListNode? next;
            public ListNode(int key)
            {
                this.data = key;
                next = null;
            }
        }

        public class MergeSortPractice
        {
            
            static ListNode? MergeSort(ListNode? head)
            {
                if (head?.next == null)
                    return head;

                // find the mid for splitting the linked list into 2 halves
                ListNode? mid = GetMid(head);
                // storing the position of mid.next
                ListNode? head2 = mid?.next; 

                // set the mid.next as null since we need to split first list
                mid.next = null;
                ListNode? newHead1 = MergeSort(head);
                ListNode? newHead2 = MergeSort(head2);
                //ListNode? finalHead = IterativeMerge(newHead1, newHead2);
                ListNode? finalHead = RecursiveMerge(newHead1, newHead2);
                return finalHead;

            }

            // Time complexity: O(n+m)
            // Space compexity: O(1) since we are only allocating few constant pointers
            static ListNode? IterativeMerge(ListNode? head1, ListNode? head2)
            {
                ListNode result = new(-1);
                ListNode temp = result;

                // add the elements from head1 and head2 based on which is smaller
                while(head1 != null && head2 != null)
                {
                    if(head1.data <= head2.data)
                    {
                        temp.next = head1;
                        head1 = head1.next;
                    }
                    else
                    {
                        temp.next = head2;
                        head2 = head2.next;
                    }
                    temp = temp.next;
                }

                // add the rest of the elements left in head1 and head2
                while(head1 != null)
                {
                    temp.next = head1;
                    head1 = head1.next;
                    temp = temp.next;
                }

                while (head2 != null)
                {
                    temp.next = head2;
                    head2 = head2.next;
                    temp = temp.next;
                }

                return result.next;
            }

            // Time complexity: O(n+m)
            // Space complexity: O(n+m) [since recursion is using stack space to allocate pointers]
            static ListNode? RecursiveMerge(ListNode? l1, ListNode? l2)
            {
                if (l1 == null) return l2;
                if (l2 == null) return l1;

                if(l1.data < l2.data)
                {
                    l1.next = RecursiveMerge(l1.next, l2);
                    return l1;
                }
                else
                {
                    l2.next = RecursiveMerge(l1, l2.next);
                    return l2;
                }
            }

            static ListNode? GetMid(ListNode head)
            {
                ListNode? slow = head;
                ListNode? fast = head.next;

                while(fast != null && fast.next != null)
                {
                    slow = slow?.next;
                    fast = fast.next.next;
                }

                return slow;
            }
            
            static void printList(ListNode? head)
            {
                ListNode? curr = head;
                while(curr?.next != null)
                {
                    Console.Write(curr.data + " ");
                    curr = curr.next;
                }
            }

            public static void Main(string[] args)
            {
                ListNode? head = new ListNode(7);
                ListNode temp = head;
                temp.next = new ListNode(10);
                temp = temp.next;
                temp.next = new ListNode(5);
                temp = temp.next;
                temp.next = new ListNode(20);
                temp = temp.next;
                temp.next = new ListNode(3);
                temp = temp.next;
                temp.next = new ListNode(2);
                temp = temp.next;

                head = MergeSort(head);

                Console.Write("\nSorted Linked List: \n");
                printList(head);
            }
        }
    }
}
