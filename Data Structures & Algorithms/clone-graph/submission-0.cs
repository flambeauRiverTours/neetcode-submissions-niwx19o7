/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class Solution {
    public Node CloneGraph(Node node) {
        if(node == null) {return null;}
        return CloneInt(node, new HashSet<Node>(), new Dictionary<Node, Node>());
    }

    public Node CloneInt(Node oldNode, HashSet<Node> visitedOldNodes, Dictionary<Node, Node> oldNodeToNewNodeMapping){
        visitedOldNodes.Add(oldNode);
        Node newNode = new Node(oldNode.val);
        oldNodeToNewNodeMapping.Add(oldNode, newNode);
        foreach(Node oldNeighbor in oldNode.neighbors){
            if(!visitedOldNodes.Contains(oldNeighbor)){
                CloneInt(oldNeighbor, visitedOldNodes, oldNodeToNewNodeMapping);
            }
            newNode.neighbors.Add(oldNodeToNewNodeMapping[oldNeighbor]);
        }
        return newNode;
    }

}
