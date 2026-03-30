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
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        int diffRootP = root.val - p.val;
        int diffRootQ = root.val - q.val;
        if(0 > (diffRootP * diffRootQ)) {return root;}
        if(diffRootP == 0) {return p;}
        if(diffRootQ == 0) {return q;}
        if(diffRootP > 0){
            return LowestCommonAncestor(root.left, p, q);
        }
        return LowestCommonAncestor(root.right, p, q);
    }
}