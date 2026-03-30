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
    public int GoodNodes(TreeNode root) {
        return GoodNodesInt(root, new Stack<int>());
    }

    public int GoodNodesInt(TreeNode root, Stack<int> path){
        if(root == null) {return 0;}
        int result = 0;
        bool pushed = false;
        if((path.Count == 0) ||(root.val >= path.Peek())) {
            result++;
            path.Push(root.val);
            pushed = true;
        }
        result += GoodNodesInt(root.left, path);
        result += GoodNodesInt(root.right, path);
        if(pushed) {path.Pop();}
        return result;
    }
}
