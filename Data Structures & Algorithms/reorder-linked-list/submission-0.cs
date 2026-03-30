/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */

public class Solution {
    public void ReorderList(ListNode head) {
        List<ListNode> listNodeList = new List<ListNode>();
        ListNode currentNode = head;
        while(currentNode != null){
            listNodeList.Add(currentNode);
            currentNode = currentNode.next;
        }
        for(int i = 0; i < (listNodeList.Count / 2); i++){
            int nextIndex = listNodeList.Count - (i + 1);
            if(nextIndex > i){
                listNodeList[i].next = listNodeList[nextIndex];
                listNodeList[listNodeList.Count - (i + 1)].next = listNodeList[i + 1];
            }
        }
        listNodeList[(listNodeList.Count / 2)].next = null;
    }
}
