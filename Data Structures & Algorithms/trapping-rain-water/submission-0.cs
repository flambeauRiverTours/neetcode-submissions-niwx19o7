public class Solution {
    public int Trap(int[] height) {
        int L = 0;
        int waterTrapped = 0;
        int[] leftMax = new int[height.Length];
        int[] rightMax = new int[height.Length];
        int currentLeftMax = height[0];
        for(int i = 0; i < height.Length; i++){
            if(height[i] > currentLeftMax){
                currentLeftMax = height[i];
            }
            leftMax[i] = currentLeftMax;
        }
        int currentRightMax = height[height.Length - 1];
        for(int i = height.Length - 1; i >= 0; i--){
            if(height[i] > currentRightMax){
                currentRightMax = height[i];
            }
            rightMax[i] = currentRightMax;
        }

        
        int waterHeld = 0;
        for(int i = 0; i < height.Length; i++){
            int possibleWaterHeld = Math.Min(leftMax[i], rightMax[i]) - height[i];
            if(possibleWaterHeld > 0){
                waterHeld += possibleWaterHeld;
            }
        }
        return waterHeld;
    }
}
