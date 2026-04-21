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
    int maxSum = int.MinValue;
    public int MaxPathSum(TreeNode root){
        MaxPathSumInt(root);
        return maxSum;
    }
    private int MaxPathSumInt(TreeNode root) {
        if(root == null) {return 0;}
        int leftChildGain = Math.Max(0, MaxPathSumInt(root.left));
        int rightChildGain = Math.Max(0, MaxPathSumInt(root.right));
        maxSum = Math.Max(maxSum, root.val + leftChildGain + rightChildGain);
        return root.val + Math.Max(leftChildGain, rightChildGain);
    }

}
