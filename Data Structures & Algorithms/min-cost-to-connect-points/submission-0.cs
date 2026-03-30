public class Solution {
    List<Node> nodes;
    HashSet<Node> visitedNodes;
    public int MinCostConnectPoints(int[][] points) {
        int cost = 0;
        nodes = new List<Node>();
        for(int i = 0; i < points.Length; i++){
            nodes.Add(new Node(points[i][0], points[i][1]));
        }
        visitedNodes = new HashSet<Node>();
        PriorityQueue<(Node, int), int> pq = new PriorityQueue<(Node, int), int>();
        pq.Enqueue((nodes.First(), 0), 0);

        while((pq.Count > 0) && (visitedNodes.Count != nodes.Count)){
            (Node node, int weight) currentNode = pq.Dequeue();
            if (visitedNodes.Contains(currentNode.node)) continue;
            cost += currentNode.weight;
            visitedNodes.Add(currentNode.node);
            foreach((Node node, int weight) neighbor in GetNodesToTravelTo(currentNode.node)){
                pq.Enqueue((neighbor.node, neighbor.weight), neighbor.weight);
            }
        }
        return cost;
    }

    private List<(Node, int)> GetNodesToTravelTo(Node currentNode){
        List<(Node, int)> result = new List<(Node, int)>();
        foreach(Node node in nodes){
            if(!visitedNodes.Contains(node)){
                result.Add((node, node.GetMDist(currentNode)));
            }
        }
        return result;
    }

}

public class Node{
    public Node(int _x, int _y){
        x = _x;
        y = _y;
    }
    public int x;
    public int y;

    public int GetMDist(Node otherNode){
        return Math.Abs(otherNode.x - x) + Math.Abs(otherNode.y - y);
    }
}