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
    public int DiameterOfBinaryTree(TreeNode root) {
        if(root == null) {return 0;}
        if((root.left == null) && (root.right == null)) {return 0;}
        DiameterInt(root);
        return maxFound - 1;
    }
    int maxFound = Int32.MinValue;
    public int DiameterInt(TreeNode root){
        if(root == null) {return 0;}
        int left = DiameterInt(root.left);
        int right = DiameterInt(root.right);
        maxFound = Math.Max(maxFound, 1 + left + right);
        return 1 + Math.Max(left, right);
    }
}
