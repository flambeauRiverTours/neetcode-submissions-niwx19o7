public class Solution {
    public int Search(int[] nums, int target) {
        numsLength = nums.Length;
        if(nums[0] < nums[nums.Length - 1]){
            numTimesRotated = 0;
        }
        else{
            numTimesRotated = FindSmallestNum(nums, 0, nums.Length - 1);
        }
        return Search(nums, target, 0, nums.Length - 1, numTimesRotated);
    }
    private int FindSmallestNum(int[] nums, int startIndex, int endIndex){
        if(startIndex == endIndex) {return startIndex;}
        int midPoint = (((endIndex - startIndex) / 2) + startIndex);
        if (nums[midPoint] < nums[startIndex]){
            if(nums[midPoint-1] > nums[midPoint]) {return midPoint;}
            return FindSmallestNum(nums, startIndex, midPoint - 1);
        }
        else{
            if(nums[midPoint+1] < nums[midPoint]) {return midPoint + 1;}
            return FindSmallestNum(nums, midPoint + 1, endIndex);
        }
    }

    private int numTimesRotated;
    private int numsLength;
    private int Search(int[] nums, int target, int startIndex, int endIndex, int numTimesRotated){
        if(startIndex == endIndex){return nums[ConvertIndex(startIndex)] == target ? ConvertIndex(startIndex) : -1;}
        if(startIndex > endIndex) {return - 1;}
        int midPoint = (((endIndex - startIndex) / 2) + startIndex);
        if(target == nums[ConvertIndex(midPoint)]) {return ConvertIndex(midPoint);}
        if(target < nums[ConvertIndex(midPoint)]){
            endIndex = midPoint - 1;
        } 
        else{
            startIndex = midPoint + 1;
        } 
        return Search(nums, target, startIndex, endIndex, numTimesRotated);
    }

    private int ConvertIndex(int index){
        return (index + numTimesRotated) % numsLength;
    }
}
