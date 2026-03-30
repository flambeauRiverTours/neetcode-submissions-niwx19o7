public class Solution {
    public int[] FindRedundantConnection(int[][] edges) {
        Dictionary<int, int> parentDict = new Dictionary<int, int>();
        Dictionary<int, int> rankDict = new Dictionary<int, int>();
        for(int i = 1; i <= edges.Length + 1; i++){
            parentDict[i] = i;
            rankDict[i] = 0;
        }

        for(int i = 0; i < edges.Length; i++){
            int ultParent1 = FindParent(edges[i][0], parentDict);
            int ultParent2 = FindParent(edges[i][1], parentDict);
            if(ultParent1 == ultParent2) {return edges[i];}
            if(ultParent1 == edges[i][0]){
                parentDict[ultParent1] = edges[i][1];
                rankDict[ultParent1]++;
            }
            else{
                parentDict[ultParent1] = ultParent2;
                rankDict[ultParent1]++;
            }
        }
        throw new Exception("parent not found");
    }


    private int FindParent(int i, Dictionary<int, int> parentDict){
        while(parentDict[i] != i){
            i = parentDict[i];
        }
        return i;
    }
}
