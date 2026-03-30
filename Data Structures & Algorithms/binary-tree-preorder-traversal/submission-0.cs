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
    List<int> currList;
    public List<int> PreorderTraversal(TreeNode root) {
        currList = new List<int>();
        Preorder(root);
        return currList;
    }
    private void Preorder(TreeNode node){
        if(node == null) {return;}
        currList.Add(node.val);
        Preorder(node.left);
        Preorder(node.right);
    }

}