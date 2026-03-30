public class Solution {
    public List<List<int>> SubsetsWithDup(int[] nums) {
        List<int> numList = nums.ToList();
        numList.Sort();
        Stack<int> set = new Stack<int>();
        List<List<int>> result = new List<List<int>>();
        BackTrack(0, numList, set, result);
        return result;
    }

    private void BackTrack(int index, List<int> numList, Stack<int> set, List<List<int>> subsets){
        if(index >= numList.Count){
            subsets.Add(set.ToList());
            return;
        }
        set.Push(numList[index]);
        BackTrack(index + 1, numList, set, subsets);
        set.Pop();
        while((index < (numList.Count - 1)) && (numList[index] == numList[index+1])){
            index++;
        }
        BackTrack(index + 1, numList, set, subsets);
    }
}