/// <summary>
/// Level order traversal -> reads the elements level by level
/// Here we ll use list of list to store the tree elements
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

                while(q.Count != 0)
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
            }
        }
    }
}
