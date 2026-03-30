/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class BSTIterator {

    private Stack<TreeNode> stack;
    private TreeNode curr;
    public BSTIterator(TreeNode root) {
        stack = new Stack<TreeNode>();
        curr = root;
    }
    
    public int Next() {
        while(curr != null){
            stack.Push(curr);
            curr = curr.left;
        }
        curr = stack.Pop();
        int returnVal = curr.val;
        curr = curr.right;
        return returnVal;
    }
    
    public bool HasNext() {
        return ((stack.Count > 0) || (curr != null));
    }
}

/**
 * Your BSTIterator object will be instantiated and called as such:
 * BSTIterator obj = new BSTIterator(root);
 * int param_1 = obj.Next();
 * bool param_2 = obj.HasNext();
 */