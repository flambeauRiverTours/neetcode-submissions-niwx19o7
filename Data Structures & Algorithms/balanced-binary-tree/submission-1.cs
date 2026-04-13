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
    Dictionary<TreeNode, int> heightDict;
    public bool IsBalanced(TreeNode root) {
        heightDict = new Dictionary<TreeNode, int>();
        return IsBalancedInternal(root);    
    }

    private bool IsBalancedInternal(TreeNode root){
        if(root == null) {return true;}
        if(Math.Abs(GetHeight(root.left) - GetHeight(root.right)) > 1) {return false;}
        return IsBalancedInternal(root.left) && IsBalancedInternal(root.right);
    }

    private int GetHeight(TreeNode root){
        if (root == null) {return 0;}
        if(heightDict.ContainsKey(root)) {return heightDict[root];}
        int height = 1 + Math.Max(GetHeight(root.left), GetHeight(root.right));
        heightDict[root] = height;
        return height;
    }

}
