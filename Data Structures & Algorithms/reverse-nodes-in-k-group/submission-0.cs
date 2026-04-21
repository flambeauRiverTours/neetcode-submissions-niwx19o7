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
    public ListNode ReverseKGroup(ListNode head, int k) {
        if(k == 1) {return head;}
        ListNode lastNode = null;
        ListNode currentNode = head;
        ListNode firstNode = head;
        Stack<ListNode> lnStack = new Stack<ListNode>();
        lnStack.Push(currentNode);
        while(currentNode.next != null){
            currentNode = currentNode.next;
            lnStack.Push(currentNode);
            if(lnStack.Count == k){
                ListNode nextNode = currentNode.next;
                bool hasPopped = false;
                while(lnStack.Count > 0){
                    ListNode pop = lnStack.Pop();
                    if(!hasPopped){
                        currentNode = pop;
                        if(lastNode != null){
                            lastNode.next = currentNode;
                        }
                        else{
                            firstNode = currentNode;
                        }
                        hasPopped = true;
                    }
                    else{
                        currentNode.next = pop;
                        currentNode = pop;
                        if(lnStack.Count == 0){
                            lastNode = currentNode;
                            currentNode.next = nextNode;
                        }
                    }
                }
            }
        }
        return firstNode;
    }
}
