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
    public bool HasPathSum(TreeNode root, int targetSum) {
        if(root == null) {return false;}
        targetSum -= root.val;
        if((root.left == null) && (root.right == null)){
            return (targetSum == 0);
        }
        if (root.left != null){
            if(HasPathSum(root.left, targetSum)){
                return true;
            }
        }
        if(root.right != null){
            if(HasPathSum(root.right, targetSum)){
                return true;
            }
        }
        return false;
    }
}