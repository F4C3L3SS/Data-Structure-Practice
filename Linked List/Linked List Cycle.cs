/// <summary>
/// Below code contains 2 things:
/// 
/// 1. Detecting linked list cycle using Floyd Cycle algo and detecting the entrance to the cycle
/// 2. Detecting the entrance to the cycle using Floyd Cycle algo (2 pass)
/// </summary>
namespace Linked_List
{
    internal class Linked_List_Cycle
    {

        public class ListNode
        {
            public ListNode? next;
            public int data;

            public ListNode(int data)
            {
                this.data = data;
                next = null;
            }
        }

        public ListNode? head;

        public void push(int new_data)
        {
            /* 1 & 2: Allocate the Node &
                    Put in the data*/
            ListNode new_node = new ListNode(new_data);

            /* 3. Make next of new Node as head */
            new_node.next = head;

            /* 4. Move the head to point to new Node */
            head = new_node;
        }

        public class Cycle
        {
            static ListNode? detectCycleUsingHashSet (ListNode head)
            {
                HashSet<ListNode> node = new();

                ListNode? temp = head;
                while(temp != null)
                {
                    if (node.Contains(temp))
                    {
                        return temp;
                    }
                    node.Add(temp);
                    temp = temp.next;
                }
                return null;
            }
            // Initially we try to find the intersecting point using tortoise and hare method
            // To compute the intersection point, let's note that the hare has traversed
            // twice as many nodes as the tortoise, ie 2d(tortoise) = d(hare)
            // 2 (F + a) = F + nC + a , n is a random integer
            // Refer Loop 1, 2, 3 images for more explaination
            static ListNode? detectCycleUsingFloydWarshall(ListNode head)
            {
                if (head == null)
                    return null;


                // If there is a cycle, the fast/slow pointers will intersect at some node.
                // Otherwise, if there is no cycle, so we cannot find an entrance to the cycle
                ListNode? intersect = GetIntersect(head);
                if (intersect == null)
                    return null;

                ListNode? ptr1 = head;
                ListNode? ptr2 = intersect;

                while(ptr1 != ptr2)
                {
                    ptr1 = ptr1.next;
                    ptr2 = ptr2.next;
                }

                return ptr1; // we can return either ptr1 or ptr2. (both will point at the same)
            }

            static ListNode? GetIntersect(ListNode head)
            {
                ListNode? slow = head;
                ListNode? fast = head;

                while(fast != null && fast.next != null)
                {
                    slow = slow.next;
                    fast = fast.next.next;
                    if (slow == fast)
                        return slow; // we can return either slow or fast. (both will point at the same)
                }

                return null;
            }

            public static void Main(string[] args)
            {
                Linked_List_Cycle llist = new Linked_List_Cycle();

                llist.push(20);
                llist.push(4);
                llist.push(15);
                llist.push(10);
                llist.push(5);

                /*Create loop for testing */
                llist.head.next.next.next.next.next = llist.head.next;

                ListNode? intersect = detectCycleUsingFloydWarshall(llist.head);
                //ListNode intersect = detectCycleUsingHashSet(llist.head);

                //if(intersect != null)
                if (intersect != null)
                    Console.WriteLine("Entrance found at: {0}", intersect.data);
                else
                    Console.WriteLine("No Loop");
            }
        }
    }
}
