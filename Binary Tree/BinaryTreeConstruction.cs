/// <summary>
/// Construction using traversal arrays
/// Inorder - preorder
/// Inorder - Postorder
/// 1. take one node a time from preorder which will be our root (root , left, right)
/// 2. we search that node in inorder, (from that index- > left side nodes will be our left subtree and right side nodes will be our right subtree
/// 3. if both the start and end pointers are at same position, we return that node(its root at that point)
/// 4. for optimization, we are storing the inorder array characters as key and its indexes as value in dictionary in order to find index at O(1)
/// </summary>
namespace Binary_Tree
{
    class BinaryTreeConstruction
    {
        class TreeNode
        {
            public int data;
            public TreeNode? left, right;

            public TreeNode(int data)
            {
                this.data = data;
                left = null;
                right = null;
            }
        }

        class BinaryTree
        {
            public TreeNode? root;
            public static int preIndex = 0;

            static Dictionary<int, int> mp = new Dictionary<int, int>();

            public static TreeNode? ConstructTreeFromInorderPreorder(int[] arr, int[] pre, int inStart, int inEnd)
            {
                if (inStart > inEnd)
                    return null;

                TreeNode node = new TreeNode(pre[preIndex++]); // take the first character, which will be root

                // if this node has no children then return, we are at kinda root
                if (inStart == inEnd)
                    return node;

                // else find the index of this node in inorder traversal map
                int inIndex = mp[node.data];


                // using index in inorder traversal, construct left and right subtrees
                node.left = ConstructTreeFromInorderPreorder(arr, pre, inStart, inIndex - 1);
                node.right = ConstructTreeFromInorderPreorder(arr, pre, inIndex + 1, inEnd);
                return node;
            }

            public static TreeNode? ConstructTreeFromInorderPostorder(int[] arr, int[] post, int inStart, int inEnd, int postIdx)
            {
                if (inStart > inEnd)
                    return null;

                TreeNode node = new TreeNode(post[postIdx]);

                int inIndex = mp[node.data];
                node.left = ConstructTreeFromInorderPostorder(arr, post, inStart, inIndex - 1, postIdx - (inEnd - inIndex) - 1);
                node.right = ConstructTreeFromInorderPostorder(arr, post, inIndex + 1, inEnd, postIdx - 1);

                return node;
            }

            public static void buildTreeMap(int[] Inorder)
            {
                for (int i = 0; i < Inorder.Length; i++)
                    mp.Add(Inorder[i], i);
            }

            public static void printInorder(TreeNode? node)
            {
                if (node == null)
                    return;

                printInorder(node.left);
                Console.Write(node.data + " ");
                printInorder(node.right);
            }

            public static void Main(String[] args)
            {
                BinaryTree tree = new BinaryTree();

                //char[] arr = new char[] { 'D', 'B', 'E', 'A', 'F', 'C' };
                //char[] pre = new char[] { 'A', 'B', 'D', 'E', 'C', 'F' }; // first char in this will be root (root, left, right)

                int[] arr = new int[] { 9, 3, 15, 20, 7 };
                int[] pre = new int[] { 3, 9, 20, 15, 7 };
                int[] post = new int[] { 9, 15, 7, 20, 3 };

                buildTreeMap(arr);
                //tree.root = ConstructTreeFromInorderPreorder(arr, pre, 0, arr.Length - 1);
                //Console.WriteLine("Inorder result: ");
                //printInorder(tree.root);

                BinaryTree tree2 = new BinaryTree();
                tree2.root = ConstructTreeFromInorderPostorder(arr, post, 0, arr.Length - 1, post.Length - 1);
                printInorder(tree2.root);
            }
        }
    }
}
