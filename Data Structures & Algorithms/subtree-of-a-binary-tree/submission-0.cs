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
    public bool IsSubtree(TreeNode root, TreeNode subRoot) {
        if((root == null) || (subRoot == null)) {return false;}
        if(IsSameTree(root, subRoot)){
            return true;
        }
        return IsSubtree(root.left, subRoot) || IsSubtree(root.right, subRoot);
    }

    public bool IsSameTree(TreeNode a, TreeNode b){
        if((a == null) && (b != null)){return false;}
        if((a != null) && (b == null)){return false;}
        if((a  == null) && (b == null)) {return true;}
        if(a.val != b.val) {return false;}
        return IsSameTree(a.left, b.left) && IsSameTree(a.right, b.right);
    }
}
