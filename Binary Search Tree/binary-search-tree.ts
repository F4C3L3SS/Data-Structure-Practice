/*
 * For inserting a new key, we need to find its exact position
 * 1. Start from the root. 
 * 2. Compare the searching element with root, if less than root, then recursively call left subtree, else recursively call right subtree. 
 * 3. If the element to search is found anywhere, return true, else return false. 
 * 
 * For deletion, we have three cases
 * 1. Node to be deleted is the leaf: Simply remove from the tree. 
 *      50                        50
 *    /    \     delete(20)     /   \
 *   30     70  --------->    30     70
 *  /  \    / \                \    /  \ 
 * 20   40 60  80              40  60   80
 * 
 * 2. Node to be deleted has only one child: Copy the child to the node and delete the child 
 *             50                           50
 *           /    \       delete(30)      /   \
 *          30      70     --------->    40     70
 *            \    /  \                        /  \ 
 *            40  60   80                     60   80
 * 3. Node to be deleted has two children: Find inorder successor of the node.
 *  Copy contents of the inorder successor to the node and delete the inorder successor. Note that inorder predecessor can also be used
 *             50                   60
 *           /    \   delete(50)   /   \
 *         40      70  ---------> 40    70
 *                /  \                   \ 
 *               60   80                  80
 *
 * Note: Inorder successor is the smallest element(left most element) in the right subtree
 * Inorder predecessor is the largest element (leftmost element) in the left subtree
 */

class TreeNode {
    value: number;
    left: TreeNode | null = null;
    right: TreeNode | null = null;

    constructor(value: number) {
        this.value = value;
    }
}

class BinarySearchTree {
    root: TreeNode | null = null;

    insert(value: number): void {
        this.root = this._insert(this.root, value);
    }

    _insert(node: TreeNode | null, value: number): TreeNode {
        if (!node) {
            return new TreeNode(value);
        }

        if (value < node.value) {
            node.left = this._insert(node.left, value);
        } else if (value > node.value) {
            node.right = this._insert(node.right, value);
        }

        return node;
    }

    delete(value: number): void {
        this.root = this._delete(this.root, value);
    }

    _delete(node: TreeNode | null, value: number): TreeNode | null {
        if (!node) return null;

        if (value < node.value) {
            node.left = this._delete(node.left, value); // traverse left
        } else if (value > node.value) {
            node.right = this._delete(node.right, value); // traverse right
        } else {
            // Node with only one child
            if (!node.left) return node.right; // node has no left child
            if (!node.right) return node.left; // node has no right child

            // Node with two children: get the inorder successor (smallest in right subtree)
            const minRight = this._findMin(node.right);
            node.value = minRight.value; // Replace value (NOT the node), Now the tree temporarily looks like it has a duplicate value.
            node.right = this._delete(node.right, minRight.value);
        }

        return node;
    }

    _findMin(node: TreeNode): TreeNode {
        while (node.left) {
            node = node.left;
        }
        return node;
    }

    // L Ro R
    inorder(): number[] {
        const result: number[] = [];
        this.inorderRec(this.root, result);
        return result;
    }

    inorderRec(node: TreeNode | null, result: number[]): void {
        if (!node) return;

        this.inorderRec(node.left, result);
        result.push(node.value);
        this.inorderRec(node.right, result);
    }

    // Ro L R
    preorder(): number[] {
        const result: number[] = [];
        this.preorderRec(this.root, result);
        return result;
    }

    preorderRec(node: TreeNode | null, result: number[]): void {
        if (!node) return;

        result.push(node.value);
        this.preorderRec(node.left, result);
        this.preorderRec(node.right, result);
    }


    // L R Ro
    postorder(): number[] {
        const result: number[] = [];
        this.postorderRec(this.root, result);
        return result;
    }

    postorderRec(node: TreeNode | null, result: number[]): void {
        if (!node) return;

        this.postorderRec(node.left, result);
        this.postorderRec(node.right, result);
        result.push(node.value);
    }

    levelOrder(): number[] {
        const result: number[] = [];
        const h = this.height(this.root);

        for (let i = 1; i <= h; i++) {
            this.levelRec(this.root, i, result);
        }

        return result;
    }

    levelRec(node: TreeNode | null, level: number, result: number[]) {
        if (!node) return;

        if (level === 1) {
            result.push(node.value);
        } else {
            this.levelRec(node.left, level - 1, result);
            this.levelRec(node.right, level - 1, result);
        }
    }

    height(node: TreeNode | null): number {
        if (!node) return 0;

        return 1 + Math.max(this.height(node.left), this.height(node.right));
    }

    // Level Order Traversal in 2D (each level as a separate array) - Recursive
    levelOrder2D(): number[][] {
        const result: number[][] = [];
        const h = this.height(this.root);

        for (let i = 1; i <= h; i++) {
            const level: number[] = [];
            this.levelRec2D(this.root, i, level);
            result.push(level);
        }

        return result;
    }

    levelRec2D(node: TreeNode | null, level: number, currentLevel: number[]): void {
        if (!node) return;

        if (level === 1) {
            currentLevel.push(node.value);
        } else {
            this.levelRec2D(node.left, level - 1, currentLevel);
            this.levelRec2D(node.right, level - 1, currentLevel);
        }
    }

    // Level Order Traversal in 2D (each level as a separate array) - Iterative
    levelOrder2DIterative(): number[][] {
        const result: number[][] = [];
        if (!this.root) return result;

        const queue: TreeNode[] = [this.root];

        while (queue.length > 0) {
            const levelSize = queue.length;
            const currentLevel: number[] = [];

            for (let i = 0; i < levelSize; i++) {
                const node = queue.shift();
                if (node) {
                    currentLevel.push(node.value);

                    if (node.left) queue.push(node.left);
                    if (node.right) queue.push(node.right);
                }
            }

            result.push(currentLevel);
        }

        return result;
    }
}

const bst = new BinarySearchTree();

bst.insert(50);
bst.insert(30);
bst.insert(70);
bst.insert(20);
bst.insert(40);
bst.insert(60);
bst.insert(80);

console.log("Inorder:", bst.inorder());
console.log("Preorder:", bst.preorder());
console.log("Postorder:", bst.postorder());
console.log("LevelOrder:", bst.levelOrder());
console.log("LevelOrder 2D (Recursive):", bst.levelOrder2D());
console.log("LevelOrder 2D (Iterative):", bst.levelOrder2DIterative());

// bst.delete(50);
// console.log("After delete:", bst.inorder());