public class Solution {
    public int Search(int[] nums, int target) {
        return BinarySearch(nums, 0, nums.Length - 1, target);
    }

    public int BinarySearch(int[] nums, int left, int right, int target){
        if(left == right) {return nums[left] == target ? left : -1;}
        if((left < 0) || (right >= nums.Length)) { return -1;}
        if((right < 0) || (left >= nums.Length)) { return -1;}
        int mid = left + ((right - left) / 2);
        if(nums[mid] == target) {return mid;}
        if(target > nums[mid]){
            return BinarySearch(nums, mid + 1, right, target);
        }
        else{
            return BinarySearch(nums, left, mid - 1, target);
        }
    }
}
