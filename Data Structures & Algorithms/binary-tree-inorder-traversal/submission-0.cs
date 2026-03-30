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
    public List<int> InorderTraversal(TreeNode root) {
        List<int> inorderList = new List<int>();
        InorderTraversalInternal(root, inorderList);
        return inorderList;
    }

    private void InorderTraversalInternal(TreeNode root, List<int> inorderList){
        if(root == null) {return;}
        InorderTraversalInternal(root.left, inorderList);
        inorderList.Add(root.val);
        InorderTraversalInternal(root.right, inorderList);
    }
}