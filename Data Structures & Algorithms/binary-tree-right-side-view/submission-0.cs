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
    Queue<TreeNode> bfsQueue = new Queue<TreeNode>();
    public List<int> RightSideView(TreeNode root) {
        List<int> resultList = new List<int>();
        if(root == null) {return resultList;}
        bfsQueue.Enqueue(root);
        while(bfsQueue.Count > 0){
            int levelCount = bfsQueue.Count;
            for(int i = 0; i < levelCount; i++){
                TreeNode currentNode = bfsQueue.Dequeue();
                if(i == (levelCount - 1)){
                    resultList.Add(currentNode.val);
                }
                if(currentNode.left != null) {bfsQueue.Enqueue(currentNode.left);}
                if(currentNode.right != null) {bfsQueue.Enqueue(currentNode.right);}
            }
        }
        return resultList;
    }
}
