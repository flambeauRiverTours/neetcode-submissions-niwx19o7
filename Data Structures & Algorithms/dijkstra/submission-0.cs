public class Solution {
    public Dictionary<int, int> ShortestPath(int n, List<List<int>> edges, int src) {
        Dictionary<int, List<(int node, int val)>> adjList = new Dictionary<int, List<(int node, int val)>>();
        for (int i = 0; i < n; i++) adjList[i] = new List<(int node, int val)>();
        foreach(List<int> edge in edges){
            adjList[edge[0]].Add((edge[1], edge[2]));
        }
        Dictionary<int, int> result = new Dictionary<int, int>();
        PriorityQueue<(int node, int totalPath), int> nodeMinHeap = new PriorityQueue<(int node, int totalPath), int>();
        nodeMinHeap.Enqueue((src, 0), 0);
        while(nodeMinHeap.Count > 0){
            (int node, int path) nextNode = nodeMinHeap.Dequeue();
            if(!result.ContainsKey(nextNode.node)){
                result[nextNode.node] = nextNode.path;
                int pathSoFar = nextNode.path;
                foreach((int node, int val) anotherNode in adjList[nextNode.node]){
                    nodeMinHeap.Enqueue((anotherNode.node, pathSoFar + anotherNode.val), pathSoFar + anotherNode.val);
                }
            }
        }

        for (int i = 0; i < n; i++) {
            if (!result.ContainsKey(i)) result[i] = -1;
        }

        return result;
    }  
}