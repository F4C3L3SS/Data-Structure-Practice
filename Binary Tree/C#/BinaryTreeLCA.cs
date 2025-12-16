/// <summary>
/// LCA of a binary tree
/// https://github.com/bephrem1/backtobackswe/blob/master/Trees%2C%20Binary%20Trees%2C%20%26%20Binary%20Search%20Trees/LowestCommonAncestorBinaryTree/LowestCommonAncestorBinaryTree.java
/// </summary>
namespace Binary_Tree
{
    class BinaryTreeLCA
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

            BinaryTree() 
            { 
                root = null;
            }

            TreeNode? LCA(TreeNode? root, TreeNode p, TreeNode q)
            {
                // base case
                // 1. If node we are holding is null, then we cant search, just return null
                // 2. if we if any of the value is a root value, we ll grab/hold root in this call
                if (root == null)
                    return null;

                if (root.data == p.data || root.data == q.data)
                    return root;


                // if root doesnt satisfy any of our base cases
                // search left and right tree recursively
                TreeNode? leftResult = LCA(root.left, p, q);
                TreeNode? rightResult = LCA(root.right, p, q);

                // if no result is there from left, return whatever we got back on the right
                if (leftResult == null)
                    return rightResult;

                // if no result is there from right, return whatever we got back on the left
                if (rightResult == null)
                    return leftResult;

                // at this point, left and right doesnt return us anything, so we return what we 
                // were holding
                return root;
            }

            public static void Main(String[] args)
            {
                BinaryTree tree = new BinaryTree();
                tree.root = new TreeNode(3);
                tree.root.left = new TreeNode(9);
                tree.root.right = new TreeNode(20);
                tree.root.right.right = new TreeNode(7);
                tree.root.right.left = new TreeNode(15);

                

                TreeNode? ans = tree.LCA(tree.root, tree.root.left, tree.root.right);

                Console.WriteLine("LCA of {0} and {1} is: {2}", tree.root.left.data, tree.root.right.data, ans?.data);
            }
        }
    }
}
