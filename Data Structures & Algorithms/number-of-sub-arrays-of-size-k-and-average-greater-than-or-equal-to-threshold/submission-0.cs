public class Solution {
    public int NumOfSubarrays(int[] arr, int k, int threshold) {
        int matchingSubarrays = 0;
        List<int> window = new List<int>();
        for(int i = 0; i < arr.Length; i++){
            window.Add(arr[i]);
            if(window.Count > k){
                window.RemoveAt(0);
            }
            if(window.Count == k && Check(window, threshold)) {
                matchingSubarrays++;
            }
        }

        return matchingSubarrays;
    }

    private bool Check(List<int> nums, int threshold){
        long sum = 0;
        foreach(int num in nums){
            sum += num;
        }
        return sum >= (long)threshold * nums.Count();
    }
}