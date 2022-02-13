/// <summary>
/// For inserting a new key, we need to find its exact position
/// 1. Start from the root. 
/// 2.Compare the searching element with root, if less than root, then recursively call left subtree, else recursively call right subtree. 
/// 3. If the element to search is found anywhere, return true, else return false. 
/// 
/// For deletion, we have three cases
/// 1. Node to be deleted is the leaf: Simply remove from the tree. 
///      50                        50
///    /    \     delete(20)     /   \
///   30     70  --------->    30     70
///  /  \    / \                \    /  \ 
/// 20   40 60  80              40  60   80
/// 
/// 2. Node to be deleted has only one child: Copy the child to the node and delete the child 
///             50                           50
///           /    \       delete(30)      /   \
///          30      70     --------->    40     70
///            \    /  \                        /  \ 
///            40  60   80                     60   80
/// 3. Node to be deleted has two children: Find inorder successor of the node. Copy contents of the inorder successor to the node and delete the inorder successor. Note that inorder predecessor can also be used
///             50                   60
///           /    \   delete(50)   /   \
///         40      70  ---------> 40    70
///         /  \                          \ 
///        60   80                         80
///
/// Note: Inorder successor is the smallest element(left most element) in the right subtree
/// Inorder predecessor is the smallest element (leftmost element) in the left subtree
/// </summary>
namespace Binary_Search_Tree
{
    class BinarySearchTree
    {
        class Node
        {
            public int data;
            public Node? left, right;

            public Node(int data)
            {
                this.data = data;
                left = null;
                right = null;
            }
        }

        class BST
        {
            Node? root;
            public BST()
            {
                root = null;
            }

            Node insertRecursive(Node? root, int key)
            {
                // if tree is empty, return a new node
                if(root == null)
                {
                    root = new Node(key);
                    return root;
                }

                if (key < root.data)
                    root.left = insertRecursive(root.left, key);
                else if (key > root.data)
                    root.right = insertRecursive(root.right, key);

                return root;
            }

            void inorderHelper(Node? root)
            {
                if (root == null)
                    return;

                inorderHelper(root.left);
                Console.Write(root.data + " ");
                inorderHelper(root.right);
            }

            void inorderHelperStack(Node? root)
            {
                Node? temp = root;
                Stack<Node> st = new Stack<Node>();
                while(temp != null || st.Count != 0)
                {
                    while(temp != null)
                    {
                        st.Push(temp);
                        temp = temp.left;
                    }

                    temp = st.Pop();
                    Console.Write(temp.data + " ");
                    temp = temp.right;
                }
            }

            Node deleteRec(Node? root, int key)
            {
                if (root == null)
                    return root;

                if (key < root.data)
                    root.left = deleteRec(root.left, key);
                else if (key > root.data)
                    root.right = deleteRec(root.right, key);
                
                // if root's key is same as the key to be deleted
                else
                {
                    // node to be deleted with only one child or no child
                    if (root.left == null)
                        return root.right; // if left child doesnt exist, we just copy the right child to the root;
                    else if (root.right == null)
                        return root.left; // if right child doesnt exist, we just copy the left child to the root;

                    root.data = minValue(root.right); // we are finding the inorder successor and copying to the root;

                    root.right = deleteRec(root.right, root.data);
                }
                return root;
            }

            // finding inorder successor
            int minValue(Node root)
            {
                while(root.left != null)
                {
                    root = root.left; 
                }
                return root.data;
            }

            void insert(int key)
            {
                root = insertRecursive(root, key);
            }

            void deleteKey(int key)
            {
                root = deleteRec(root, key);
            }

            void inorder()
            {
                inorderHelper(root);
            }

            void inorderUsingStack()
            {
                inorderHelperStack(root);
            }

            public static void Main(string[] args)
            {
                BST tree = new BST();

                tree.insert(50);
                tree.insert(30);
                tree.insert(20);
                tree.insert(40);
                tree.insert(70);
                tree.insert(60);
                tree.insert(80);

                Console.WriteLine("Inorder recursive:");
                tree.inorder();
                Console.WriteLine("\n\nInorder using stack:");
                tree.inorderUsingStack();

                Console.WriteLine("\nDelete 20");
                tree.deleteKey(20);
                Console.WriteLine(
                    "Inorder traversal of the modified tree");
                tree.inorder();

                Console.WriteLine("\nDelete 30");
                tree.deleteKey(30);
                Console.WriteLine(
                    "Inorder traversal of the modified tree");
                tree.inorder();

                Console.WriteLine("\nDelete 50");
                tree.deleteKey(50);
                Console.WriteLine(
                    "Inorder traversal of the modified tree");
                tree.inorder();

                Console.WriteLine("\nDelete 60");
                tree.deleteKey(60);
                Console.WriteLine(
                    "Inorder traversal of the modified tree");
                tree.inorder();
            }
        }
    }
}
