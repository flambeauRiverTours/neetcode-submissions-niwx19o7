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
    Queue<TreeNode> queue = new Queue<TreeNode>();
    public List<List<int>> LevelOrder(TreeNode root) {
        List<List<int>> resultList = new List<List<int>>();
        if(root == null) {return resultList;}
        queue.Enqueue(root);
        while(queue.Count > 0){
            List<int> levelList = new List<int>();
            int levelCount = queue.Count;
            for(int i = 0; i < levelCount; i++){
                TreeNode currentNode = queue.Dequeue();
                levelList.Add(currentNode.val);
                if(currentNode.left != null) {queue.Enqueue(currentNode.left);}
                if(currentNode.right != null) {queue.Enqueue(currentNode.right);}
            }
            resultList.Add(levelList);
        }
        return resultList;
    }
}
