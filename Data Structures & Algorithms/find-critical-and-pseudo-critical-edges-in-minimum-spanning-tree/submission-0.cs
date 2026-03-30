public class Solution {
    public List<List<int>> FindCriticalAndPseudoCriticalEdges(int n, int[][] edges) {
        // Step 1: Get the actual MST weight
        int baseMstWeight = GetMSTWeight(n, edges, -1, -1);

        List<int> criticalEdges = new List<int>();
        List<int> pseudoCriticalEdges = new List<int>();

        for (int i = 0; i < edges.Length; i++) {
            // Step 2: Check if critical
            // An edge is critical if the MST weight increases (or graph becomes disconnected) when it's removed
            int weightWithout = GetMSTWeight(n, edges, i, -1);
            if (weightWithout > baseMstWeight) {
                criticalEdges.Add(i);
            } else {
                // Step 3: Check if pseudo-critical
                // An edge is pseudo-critical if it can be part of an MST (force include it and check weight)
                int weightWith = GetMSTWeight(n, edges, -1, i);
                if (weightWith == baseMstWeight) {
                    pseudoCriticalEdges.Add(i);
                }
            }
        }

        return new List<List<int>>() { criticalEdges, pseudoCriticalEdges };
    }

    public int GetMSTWeight(int n, int[][] edges, int skipEdge, int forceEdge) {
        UnionFind uf = new UnionFind(n);
        int weight = 0;
        int edgesCount = 0;

        if (forceEdge != -1) {
            uf.Union(edges[forceEdge][0], edges[forceEdge][1]);
            weight += edges[forceEdge][2];
            edgesCount++;
        }

        // Create list of edges with original indices for sorting
        var edgeList = new List<int[]>();
        for (int i = 0; i < edges.Length; i++) {
            if (i == skipEdge || i == forceEdge) continue;
            edgeList.Add(new int[] { edges[i][0], edges[i][1], edges[i][2], i });
        }
        edgeList.Sort((a, b) => a[2].CompareTo(b[2]));

        foreach (var edge in edgeList) {
            if (uf.Union(edge[0], edge[1])) {
                weight += edge[2];
                edgesCount++;
            }
        }

        return edgesCount == n - 1 ? weight : Int32.MaxValue;
    }
}

public class UnionFind {
    int[] parent;
    public UnionFind(int n) {
        parent = new int[n];
        for (int i = 0; i < n; i++) parent[i] = i;
    }
    public int Find(int i) {
        if (parent[i] == i) return i;
        return parent[i] = Find(parent[i]);
    }
    public bool Union(int i, int j) {
        int rootI = Find(i);
        int rootJ = Find(j);
        if (rootI != rootJ) {
            parent[rootI] = rootJ;
            return true;
        }
        return false;
    }
}

public class Node {
    public int node;
    public int weight;
    public int edgeNumber;
    public Node(int _node, int _weight, int _edgeNumber) {
        node = _node;
        weight = _weight;
        edgeNumber = _edgeNumber;
    }
}