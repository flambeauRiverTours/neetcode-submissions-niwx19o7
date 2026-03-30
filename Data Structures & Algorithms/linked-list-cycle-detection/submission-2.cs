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
    public bool HasCycle(ListNode head) {
        if(head == null){return false;}
        HashSet<int> valsVisited = new HashSet<int>();
        while((head.next != null) && !valsVisited.Contains(head.val)){
            valsVisited.Add(head.val);
            head = head.next;
        }
        return !(head.next == null);
    }
}
