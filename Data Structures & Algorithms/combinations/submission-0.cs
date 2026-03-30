public class Solution {
    public List<List<int>> Combine(int n, int k) {
        List<List<int>> result = new List<List<int>>();
        Stack<int> set = new Stack<int>();
        BackTrack(1, n, k, set, result);
        return result;
    }

    public void BackTrack(int i, int n, int k, Stack<int> set, List<List<int>> result){
        if(set.Count == k){
            result.Add(set.ToList());
            return;
        }
        if(i > n){
            return;
        }
        set.Push(i);
        BackTrack(i+1, n, k, set, result);
        set.Pop();
        BackTrack(i+1, n, k, set, result);
    }
}