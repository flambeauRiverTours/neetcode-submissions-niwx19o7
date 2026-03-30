public class Graph {

    public Graph() {
        edgeDict = new Dictionary<int, List<int>>();
    }
    Dictionary<int, List<int>> edgeDict;
    public void AddEdge(int src, int dst) {
        if(!edgeDict.ContainsKey(src)){
            edgeDict.Add(src, new List<int>() {dst});
        }
        else{
            if(!edgeDict[src].Contains(dst)){
                edgeDict[src].Add(dst);
            }
        }
        if(!edgeDict.ContainsKey(dst)){
            edgeDict.Add(dst, new List<int>());
        }
    }

    public bool RemoveEdge(int src, int dst) {
        if(!edgeDict.ContainsKey(src)){
            return false;
        }
        if(!edgeDict[src].Contains(dst)){
            return false;
        }
        edgeDict[src].Remove(dst);
        return true;
    }

    public bool HasPath(int src, int dst) {
        HashSet<int> visited = new HashSet<int>();
        Queue<int> queue = new Queue<int>();
        visited.Add(src);
        queue.Enqueue(src);
        while(queue.Count > 0){
            int dequeuesToPerform = queue.Count;
            for(int i = 0; i < dequeuesToPerform; i++){
                int currentNode = queue.Dequeue();
                if(currentNode == dst) { return true; }
                foreach(int neighbor in edgeDict[currentNode]){
                    if(!visited.Contains(neighbor)){
                        visited.Add(neighbor);
                        queue.Enqueue(neighbor);
                    }
                }
            }
        }
        return false;
    }

}
