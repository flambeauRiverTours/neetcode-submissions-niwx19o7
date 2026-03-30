public class Solution {
    public void SortColors(int[] nums) {
        int[] counts = {0, 0, 0};
        for(int i = 0; i < nums.Length; i++){
            counts[nums[i]]++;
        }

        int numsIndex = 0;
        for (int countIndex = 0; countIndex < counts.Length; countIndex++){
            while(counts[countIndex] > 0){
                nums[numsIndex] = countIndex;
                counts[countIndex]--;
                numsIndex++;
            }
        }
    }
}