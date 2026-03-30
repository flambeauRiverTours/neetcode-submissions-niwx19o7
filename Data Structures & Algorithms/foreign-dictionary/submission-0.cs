public class Solution {
    Dictionary<char, List<char>> adjList;
    HashSet<char> visited;
    List<char> topSort;
    public string foreignDictionary(string[] words) {
        adjList = new Dictionary<char, List<char>>();
        visited = new HashSet<char>();
        topSort = new List<char>();
        HashSet<char> allChars = new HashSet<char>();
        foreach(string word in words) {
            foreach(char c in word) allChars.Add(c);
        }
        for(int i = 0; i < words.Length - 1; i++){
            string word1 = words[i];
            string word2 = words[i+1];
            if (word1.Length > word2.Length && word1.StartsWith(word2)) return "";
            bool diffFound = false;
            for(int j = 0; j < Math.Min(word1.Length, word2.Length); j++){

                if(word1[j] != word2[j]){
                    if(!adjList.ContainsKey(word1[j])){
                        adjList[word1[j]] = new List<char>();
                    }
                    adjList[word1[j]].Add(word2[j]);
                    diffFound = true;
                    break;
                }

            }
        }
        int totalUniqueChars = allChars.Count;
        while(allChars.Count > 0){
            char currentChar = allChars.First();
            if(!visited.Contains(currentChar)) {
                if(!DFS(currentChar, new HashSet<char>())) {return "";}
            }
            allChars.Remove(currentChar);

        }
        string result = "";

        for(int i = topSort.Count - 1; i >= 0; i--){
            result += topSort[i];
        }
        return result;
    }

    private bool DFS(char startChar, HashSet<char> pathHashSet){
        if(pathHashSet.Contains(startChar)){return false;}
        if(visited.Contains(startChar)) {return true;}
        visited.Add(startChar);
        pathHashSet.Add(startChar);
        if(adjList.ContainsKey(startChar)){
            foreach(char adj in adjList[startChar]){
                bool result = DFS(adj, new HashSet<char>(pathHashSet));
                if(!result) {return false;}
            }
        }
        topSort.Add(startChar);
        return true;
    }
}
