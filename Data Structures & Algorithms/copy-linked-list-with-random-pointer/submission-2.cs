/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
*/

public class Solution {
    public Node copyRandomList(Node head) {
        Dictionary<Node, Node> dict = new Dictionary<Node, Node>();
        return DeepCopy(dict, head);
    }

    private Node DeepCopy(Dictionary<Node, Node> dict, Node head){
        if(head == null) {return null;}
        if(dict.ContainsKey(head)) {return dict[head];}
        Node newNode = new Node(head.val);
        dict[head] = newNode;
        newNode.next = DeepCopy(dict, head.next);
        newNode.random = DeepCopy(dict, head.random);
        return newNode;
    }
}
