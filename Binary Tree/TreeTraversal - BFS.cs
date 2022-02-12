/// <summary>
/// Level order traversal -> reads the elements level by level
/// Here we ll use list of list to store the tree elements
/// This file contains: 1. Iterative & Recursive Level order traversal
/// 2. Moris Threaded Inorder & Postorder Traversal
/// </summary>
namespace Binary_Tree
{
    class TreeTraversal___BFS
    {
        public class TreeNode
        {
            public int data;
            public TreeNode? left, right;
            public TreeNode(int data = 0, TreeNode? left = null, TreeNode? right = null)
            {
                this.data = data;
                this.left = left;
                this.right = right;
            }
        }


        public class BinaryTree
        {
            TreeNode temp;

            static IList<IList<int>> res = new List<IList<int>>();
            public static IList<IList<int>> LevelOrderRecursive(TreeNode root)
            {
                LevelOrderHelper(root, 0);
                printListElements();
                return res;
            }

            public static void LevelOrderHelper(TreeNode? root, int level)
            {
                if (root == null)
                    return;

                // At every new level, we just create a new list
                if (res.Count == level)
                    res.Add(new List<int>());

                res[level].Add(root.data); // otherwise we just add the elements to already created list above
                LevelOrderHelper(root.left, level + 1); // recurse for left subtree
                LevelOrderHelper(root.right, level + 1); // recurse for right subtree
            }

            public static void LevelOrderIterative(TreeNode root)
            {
                Console.WriteLine("Iterative Queue level order");
                if (root == null)
                    return;

                Queue<TreeNode> q = new Queue<TreeNode>();
                q.Enqueue(root);

                while (q.Count != 0)
                {
                    TreeNode tempNode = q.Dequeue();
                    Console.Write(tempNode.data + " ");

                    if (tempNode.left != null)
                        q.Enqueue(tempNode.left);

                    if (tempNode.right != null)
                        q.Enqueue(tempNode.right);

                }
            }


            public static void printListElements()
            {
                Console.WriteLine("Recursive Level Order");
                Console.Write("[");
                foreach (var ele in res)
                {
                    Console.Write("[");
                    foreach (var i in ele)
                    {
                        Console.Write(i + " ");
                    }
                    Console.Write("]");
                }
                Console.Write("]");
                Console.WriteLine();
            }

            /*
             * Uses O(1) space and O(n) time
             * 1. if left is null, print current node and go right
             * 2. before going left, make right most node on left subtree connected to current node, then go left
             * 3. if thread is already pointed to current node, then remove the thread
             */
            public static void MorrisThreadedInorderTraversal(TreeNode root)
            {
                Console.WriteLine("\nMorris Threaded Inorder Traversal: ");
                TreeNode? current, prev;

                if (root == null)
                    return;

                current = root;

                while (current != null)
                {
                    // if left is null, print current node and go right
                    if (current.left == null)
                    {
                        Console.Write(current.data + " ");
                        current = current.right;
                    }
                    else
                    {
                        // before going left, make right most node on left subtree connected to current node, then go left

                        prev = current.left;
                        while (prev.right != null && prev.right != current)
                            prev = prev.right; // finding the rightmost element in the left subtree

                        if (prev.right == null)
                        {
                            prev.right = current; // set the thread from rightmost element to the current (our way to return back)
                            current = current.left; // now we can go left safely withouth losing the current
                        }
                        else
                        { // if thread already existed, we need to remove the link now
                            prev.right = null;
                            Console.Write(current.data + " "); // we are at root, print it
                            current = current.right;
                        }
                    }
                }
            }

            public static void MorrisThreadedPreorderTraversal(TreeNode root)
            {
                Console.WriteLine("\nMorris Threaded Preorder Traversal: ");
                TreeNode? current, prev;

                if (root == null)
                    return;

                current = root;

                while (current != null)
                {
                    // if left is null, print current node and go right
                    if (current.left == null)
                    {
                        Console.Write(current.data + " ");
                        current = current.right;
                    }
                    else
                    {
                        // before going left, make right most node on left subtree connected to current node, then go left

                        prev = current.left;
                        while (prev.right != null && prev.right != current)
                            prev = prev.right; // finding the rightmost element in the left subtree

                        if (prev.right == null)
                        {
                            prev.right = current; // set the thread from rightmost element to the current (our way to return back)
                            Console.Write(current.data + " ");  // this is the only change, we are printing here only before going left
                            current = current.left; // now we can go left safely withouth losing the current
                        }
                        else
                        { // if thread already existed, we need to remove the link now
                            prev.right = null;
                            current = current.right;
                        }
                    }
                }
            }

            /**
	         * prints inOrder using stack and inner while loop to
	         * get to the left most node
	         * Runtime: O(n) , even though it looks like double loop, it is just 
	         * going through left elements right away before processing further
	         */
            public static void InorderUsingStack(TreeNode root)
            {
                Console.WriteLine("\nInorder Using stack");
                if (root == null)
                    return;

                Stack<TreeNode> st = new Stack<TreeNode>();
                TreeNode? curr = root;

                while(curr != null || st.Count > 0)
                {
                    // reach to the leftmost node of the subtree
                    while(curr != null)
                    {
                        st.Push(curr);
                        curr = curr.left;
                    }

                    curr = st.Pop();
                    Console.Write(curr.data + " ");
                    curr = curr.right;
                }
            }

            public static void Main(String[] args)
            {
                BinaryTree tree = new BinaryTree();
                tree.temp = new TreeNode(3);
                tree.temp.left = new TreeNode(9);
                tree.temp.right = new TreeNode(20);
                tree.temp.right.right = new TreeNode(7);
                tree.temp.right.left = new TreeNode(15);
                LevelOrderRecursive(tree.temp);
                LevelOrderIterative(tree.temp);
                MorrisThreadedInorderTraversal(tree.temp);
                MorrisThreadedPreorderTraversal(tree.temp);
                InorderUsingStack(tree.temp);
            }
        }
    }
}
