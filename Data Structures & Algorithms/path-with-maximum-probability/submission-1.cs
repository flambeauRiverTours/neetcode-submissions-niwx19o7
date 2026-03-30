public class Solution {
    public double MaxProbability(int n, int[][] edges, double[] succProb, int start_node, int end_node) {
        Dictionary<int, List<Node>> adjList = new Dictionary<int, List<Node>>();
        for(int i = 0; i < edges.Length; i++){
            if(!adjList.ContainsKey(edges[i][0])){
                adjList[edges[i][0]] = new List<Node>();
            }
            if(!adjList.ContainsKey(edges[i][1])){
                adjList[edges[i][1]] = new List<Node>();
            }
            adjList[edges[i][1]].Add(new Node(edges[i][0], succProb[i]));
            adjList[edges[i][0]].Add(new Node(edges[i][1], succProb[i]));
        }
        PriorityQueue<Node, double> pq = new PriorityQueue<Node, double>();
        HashSet<int> visitedNodes = new HashSet<int>();
        pq.Enqueue(new Node(start_node, 1), 1);
        while(pq.Count > 0){
            Node nextNode = pq.Dequeue();
            if(nextNode.node == end_node){
                return nextNode.prob;
            }
            if(!visitedNodes.Contains(nextNode.node)){
                visitedNodes.Add(nextNode.node);
                if(adjList.ContainsKey(nextNode.node)){
                foreach(Node adjNode in adjList[nextNode.node]){
                    double totalProb = nextNode.prob * adjNode.prob;
                    pq.Enqueue(new Node(adjNode.node, totalProb), 1 - totalProb);
                }
                }
            }
        }
        return 0;
    }
}

public class Node{
    public Node(int _node, double _prob){
        node = _node;
        prob = _prob;
    }
    public int node;
    public double prob;
}