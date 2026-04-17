public class Solution {

    private Dictionary<int, List<int>> adjList;
    public bool ValidTree(int n, int[][] edges) {
        if(edges.Length == 0) {return true;}
        adjList = new Dictionary<int, List<int>>();
        int countNodesUsed = 0;
        foreach(int[] edge in edges){
            if(!adjList.ContainsKey(edge[0])){
                adjList[edge[0]] = new List<int>();
                countNodesUsed++;
            }
            if(!adjList.ContainsKey(edge[1])){
                adjList[edge[1]] = new List<int>();
                countNodesUsed++;
            }
            adjList[edge[0]].Add(edge[1]);
            adjList[edge[1]].Add(edge[0]);
        }
        HashSet<int> visited = new HashSet<int>();
        if(!DFS(adjList,  adjList.Keys.First(), visited)) {return false;}
        return visited.Count == countNodesUsed;
    }

    private bool DFS(Dictionary<int, List<int>> adjList, int currentNode, HashSet<int> visited){
        visited.Add(currentNode);
        for(int neighborIndex = 0; neighborIndex < adjList[currentNode].Count; neighborIndex++){
            if(adjList[currentNode][neighborIndex] != -1){
                int neighbor = adjList[currentNode][neighborIndex];
                if(!visited.Contains(neighbor)){
                    adjList[neighbor].Remove(currentNode);
                    adjList[currentNode][neighborIndex] = -1;
                    if(!DFS(adjList, neighbor, visited)) {return false;}
                }
                else{
                    return false;
                }
            }
        }
        return true;
    }
}
