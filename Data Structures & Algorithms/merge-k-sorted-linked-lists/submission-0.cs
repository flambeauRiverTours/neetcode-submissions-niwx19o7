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
    public ListNode MergeKLists(ListNode[] lists) {
        return MergeKListsSub(new List<ListNode>(lists));
    }

    private ListNode MergeKListsSub(List<ListNode> lists){
        if(lists.Count == 1) {
            return lists[0];
        }
        if(lists.Count == 0) { return null; }
        int mid = lists.Count / 2;
        ListNode leftList = MergeKListsSub(lists.GetRange(0, mid));
        ListNode rightList = MergeKListsSub(lists.GetRange(mid, lists.Count - mid));
        return Merge(leftList, rightList);
    }

    private ListNode Merge(ListNode leftList, ListNode rightList){
        if(leftList == null) {return rightList;}
        if(rightList == null) {return leftList;}
        ListNode currentNode = null;
        ListNode firstNode = null;
        while ((leftList != null) || (rightList != null)){
            if(leftList == null){
                currentNode.next = rightList;
                return firstNode;
            }
            if(rightList == null){
                currentNode.next = leftList;
                return firstNode;
            }
            if(leftList.val > rightList.val){
                if(currentNode != null){
                    currentNode.next = rightList;
                }
                currentNode = rightList;
                rightList = rightList.next;
            }
            else{
                if(currentNode != null){
                    currentNode.next = leftList;
                }
                currentNode = leftList;
                leftList = leftList.next;
            }
            if(firstNode == null){
                firstNode = currentNode;
            }
        }
        return firstNode;
    }
}
