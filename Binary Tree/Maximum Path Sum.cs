/// <summary>
/// Maximum Path Sum of a Binary Tree (Leetcode 124 : https://leetcode.com/problems/binary-tree-maximum-path-sum/)
/// HelpLink: https://www.youtube.com/watch?v=WszrfSwMz58&ab_channel=takeUforward
/// </summary>

namespace Binary_Tree
{
    class Maximum_Path_Sum
    {
        public class TreeNode
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


        public class BinaryTree
        {
            TreeNode? root;
            static int maxGlobal = Int32.MinValue;

            BinaryTree()
            {
                root = null;
            }

            int MaxPathSumHelper(TreeNode? root)
            {
                if (root == null)
                    return 0;

                int leftResult = Math.Max(0, MaxPathSumHelper(root.left)); // we are just returning 0 if we encounter a negative value at the left;
                int rightResult = Math.Max(0, MaxPathSumHelper(root.right)); // we are just returning 0 if we encounter a negative value at the right;

                // in every result, we need to have global sum at the point which gives us the (umbrella path result, which doesnt contain root)
                maxGlobal = Math.Max(maxGlobal, leftResult + rightResult + root.data);

                // this determines, if we are standing at root, which path to pick?
                // left or right 
                return root.data + Math.Max(leftResult, rightResult); 
            }

            int MaxPathSum(TreeNode root)
            {
                MaxPathSumHelper(root);
                return maxGlobal;
            }

            public static void Main(string[] args)
            {
                BinaryTree tree = new BinaryTree();
                tree.root = new TreeNode(3);
                tree.root.left = new TreeNode(9);
                tree.root.right = new TreeNode(20);
                tree.root.right.right = new TreeNode(7);
                tree.root.right.left = new TreeNode(15);

                Console.WriteLine("Maximum Path Sum is: {0}", tree.MaxPathSum(tree.root));
            }
        }
    }
}
