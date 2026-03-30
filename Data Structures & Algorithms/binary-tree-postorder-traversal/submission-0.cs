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
    private List<int> currList;
    public List<int> PostorderTraversal(TreeNode root) {
        currList = new List<int>();
        Postorder(root);
        return currList;
    }

    private void Postorder(TreeNode curr){
        if(curr == null) {return;}
        Postorder(curr.left);
        Postorder(curr.right);
        currList.Add(curr.val);
    }
}