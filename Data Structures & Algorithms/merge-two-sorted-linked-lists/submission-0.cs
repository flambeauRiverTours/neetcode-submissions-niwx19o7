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
    public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
        ListNode current = null;
        ListNode head = null;
        if(list1 == null){
            return list2;
        }
        if(list2 == null){
            return list1;
        } 
        if( list1.val > list2.val)
        {
                current = list2;
                list2 = list2.next;
        }
        else
        {
                current = list1;
                list1 = list1.next;
        }
        head = current;
        while((list1 != null) && (list2 != null))
        {
            if(list1.val > list2.val)
            {
                current.next = list2;
                current = list2;
                list2 = list2.next;
            }
            else{
                current.next = list1;
                current = list1;
                list1 = list1.next;
            }
        }
        if(list1 == null){
            current.next = list2;
        }
        if(list2 == null){
            current.next = list1;
        }
        return head;
    }
}