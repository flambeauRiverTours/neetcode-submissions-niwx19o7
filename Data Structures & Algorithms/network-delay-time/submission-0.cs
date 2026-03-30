public class Solution {
    public int NetworkDelayTime(int[][] times, int n, int k) {
        Dictionary<int, List<Node>> adjList = new Dictionary<int, List<Node>>();
        for(int i = 0; i < times.Length; i++){
            if(!adjList.ContainsKey(times[i][0])){
                adjList[times[i][0]] = new List<Node>();
            }
            adjList[times[i][0]].Add(new Node(times[i][1], times[i][2]));
        }
        
        int max = 0;
        PriorityQueue<Node, int> pq = new PriorityQueue<Node, int>();
        HashSet<int> finishedNodes = new HashSet<int>();
        pq.Enqueue(new Node(k, 0), 0);
        while(pq.Count > 0){
            Node currentNode = pq.Dequeue();
            if(!finishedNodes.Contains(currentNode.node)){
                finishedNodes.Add(currentNode.node);
                if(currentNode.distance > max){
                    max = currentNode.distance;
                }
                if(adjList.ContainsKey(currentNode.node)){
                    foreach(Node nextNode in adjList[currentNode.node]){
                        pq.Enqueue(new Node(nextNode.node, nextNode.distance + currentNode.distance), nextNode.distance + currentNode.distance);
                    }
                }
            }
        }

        for(int i = 1; i <= n; i++){
            if(!finishedNodes.Contains(i)){
                return -1;
            }
        }
        return max;
    }
}

public class Node{
    public Node(int _node, int _distance){
        node = _node;
        distance = _distance;
    }
    public int node;
    public int distance;
}
