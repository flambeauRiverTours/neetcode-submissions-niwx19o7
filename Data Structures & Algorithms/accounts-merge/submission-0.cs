public class Solution {
    public List<List<string>> AccountsMerge(List<List<string>> accounts) {
        int n = accounts.Count;
        int[] parent = new int[n];
        for (int i = 0; i < n; i++) parent[i] = i;

        int Find(int i) {
            if (parent[i] == i) return i;
            return parent[i] = Find(parent[i]);
        }

        void Union(int i, int j) {
            int rootI = Find(i);
            int rootJ = Find(j);
            if (rootI != rootJ) parent[rootI] = rootJ;
        }

        Dictionary<string, int> emailToIndex = new Dictionary<string, int>();
        for (int i = 0; i < n; i++) {
            for (int j = 1; j < accounts[i].Count; j++) {
                string email = accounts[i][j];
                if (emailToIndex.ContainsKey(email)) {
                    Union(i, emailToIndex[email]);
                } else {
                    emailToIndex[email] = i;
                }
            }
        }

        Dictionary<int, List<string>> merged = new Dictionary<int, List<string>>();
        foreach (var entry in emailToIndex) {
            int root = Find(entry.Value);
            if (!merged.ContainsKey(root)) merged[root] = new List<string>();
            merged[root].Add(entry.Key);
        }

        List<List<string>> result = new List<List<string>>();
        foreach (var entry in merged) {
            entry.Value.Sort();
            List<string> row = new List<string> { accounts[entry.Key][0] };
            row.AddRange(entry.Value);
            result.Add(row);
        }
        return result;
    }
}