public class Solution {
    public int MaxArea(int[] heights) {
        int L = 0;
        int area = 0;
        int R = heights.Length - 1;
        while(R != L){
            area = Math.Max(area, Math.Min(heights[R], heights[L]) * (R - L));
            if(heights[R] > heights[L]){
                L++;
            }
            else{
                R--;
            }
        }
        return area;
    }
}
