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
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        return AddTwoNumbersListNodeRecurse(l1, l2, 0);
    }

    private ListNode AddTwoNumbersListNodeRecurse(ListNode l1, ListNode l2, int carry){
        if((l1 == null) && (l2 == null)) {
            if(carry == 0){
                return null;
            }
            return new ListNode(carry);
        }

        int newVal = carry;
        if(l1 != null) { newVal += l1.val;}
        if(l2 != null) { newVal += l2.val;}
        int newCarry = 0;
        if(newVal >= 10){
            newCarry = 1;
            newVal %= 10;
        }
        ListNode result = new ListNode(newVal);
        result.next = AddTwoNumbersListNodeRecurse(l1 == null ? null : l1.next, l2 == null ? null : l2.next, newCarry);
        return result;
    }
}
