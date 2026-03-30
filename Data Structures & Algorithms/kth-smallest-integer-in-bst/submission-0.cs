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

public class Solution {
    Stack<int> smallestElementsStack = new Stack<int>();
    public int KthSmallest(TreeNode root, int k) {
        KthSmallestInternal(root, k);
        return smallestElementsStack.Pop();
    }

    public int KthSmallestInternal(TreeNode root, int k){
        if(root == null) {return  k;}
        k = KthSmallestInternal(root.left, k);
        if(k <= 0) { return k;}
        smallestElementsStack.Push(root.val);
        k--;
        k = KthSmallestInternal(root.right, k);
        return k;
    }
}
