public class Solution {
    HashSet<int> visited;
    List<int> topSort;
    List<HashSet<int>> graphs;
    Dictionary<int, List<int>> adjList;
    bool[,] isPrereq;
    public List<bool> CheckIfPrerequisite(int numCourses, int[][] prerequisites, int[][] queries) {
        adjList = new Dictionary<int, List<int>>();
        isPrereq = new bool[numCourses, numCourses];
        for(int i = 0; i < numCourses; i++){
            adjList[i] = new List<int>();
        }
        for(int i = 0; i < prerequisites.Length; i++){
            int u = prerequisites[i][0];
            int v = prerequisites[i][1];
            adjList[u].Add(v);
            isPrereq[u, v] = true;
        }

        for (int k = 0; k < numCourses; k++) {
            for (int i = 0; i < numCourses; i++) {
                for (int j = 0; j < numCourses; j++) {
                    if (isPrereq[i, k] && isPrereq[k, j]) {
                        isPrereq[i, j] = true;
                    }
                }
            }
        }

        List<bool> result = new List<bool>();
        for(int i = 0; i < queries.Length; i++){
            result.Add(isPrereq[queries[i][0], queries[i][1]]);
        }
        return result;
    }
}