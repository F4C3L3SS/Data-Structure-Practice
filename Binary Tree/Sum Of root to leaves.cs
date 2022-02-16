/// <summary>
/// Sum of root to leaves (LC 1022)
/// https://leetcode.com/problems/sum-of-root-to-leaf-binary-numbers/
/// 
/// here everytime we are visiting a node, we are storing the same in the sum,
/// also, whenever we are encountering a new node(eg. left), 
/// we are just leftshifting it by one and adding the previous (root value) value to it.
/// </summary>
namespace Binary_Tree
{
    class Sum_Of_root_to_leaves
    {
        class TreeNode
        {
            public int val;
            public TreeNode? left;
            public TreeNode? right;
            public TreeNode(int val)
            {
                this.val = val;
                left = null;
                right = null;
            }
        }

        class SumRootLeaves
        {
            TreeNode? root;

            static int SumRoot(TreeNode? root, int sum)
            {
                if (root == null)
                    return 0;

                sum = (sum << 1) + root.val; // here we are just left shifting the sum by 1 and appending the root value to it.

                // Eg: 1 << 1 -> 10 , 11 << 1  -> 110

                if (root.left != null || root.right != null)
                    return SumRoot(root.left, sum) + SumRoot(root.right, sum);
                else
                    return sum;

            }

            public static void Main(String[] args)
            {
                SumRootLeaves sum = new SumRootLeaves()
                {
                    root = new TreeNode(1)
                    {
                        left = new TreeNode(0),
                        right = new TreeNode(1)
                    }
                };

                sum.root.left.left = new TreeNode(0);
                sum.root.left.right = new TreeNode(1);
                sum.root.right.left = new TreeNode(0);
                sum.root.right.right = new TreeNode(1);

                Console.WriteLine("Sum of root to leaves: {0}", SumRoot(sum.root, 0));
            }
        }
    }
}
