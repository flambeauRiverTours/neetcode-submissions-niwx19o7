public class Solution {
    public int FindMin(int[] nums) {
        return FindMinTree(nums, 0, nums.Length - 1);
    }

    private int FindMinTree(int[] nums, int first, int last){
        if(first == last) {return nums[first];}
        int midpoint = ((last - first) / 2) + first;
        if(nums[first] > nums[midpoint]){
            return FindMinTree(nums, first + 1, midpoint);
        }
        else if(nums[midpoint] > nums[last]){
            return FindMinTree(nums, midpoint + 1, last);
        }
        else{
            return nums[first];
        }
    }
}
