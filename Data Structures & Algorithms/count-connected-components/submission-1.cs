public class Solution {
    Dictionary<int, int> parents;
    Dictionary<int, int> ranks;
    public int CountComponents(int n, int[][] edges) {
        parents = new Dictionary<int, int>();
        ranks = new Dictionary<int, int>();
        for(int i = 0; i < n; i++){
            parents[i] = i;
            ranks[i] = 0;
        }
        for(int i = 0; i < edges.Length; i++){
            Union(edges[i][0], edges[i][1]);
        }
        HashSet<int> parentHashSet = new HashSet<int>();
        for(int i = 0; i < n; i++){
            int findRes = Find(i);
            if(!parentHashSet.Contains(findRes)){
                parentHashSet.Add(findRes);
            }
        }
        return parentHashSet.Count;
    }

    private int Find(int n){
        int p = parents[n]; 
        while(p != parents[p]){
            parents[p] = parents[parents[p]];
            p = parents[p];
        }
        return p;
    }

    private bool Union(int n1, int n2){
        int p1 = Find(n1);
        int p2 = Find(n2);
        if(p1 == p2) {return false;}
        if(ranks[p1] > ranks[p2]){
            parents[p2] = p1;
        }
        else if(ranks[p2] > ranks[p1]){
            parents[p1] = p2;
        }
        else{
            parents[p1] = p2;
            ranks[p2] += 1;
        }
        return true;
    }
}
