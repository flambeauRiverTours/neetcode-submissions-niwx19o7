public class Solution {
    public int MaxTurbulenceSize(int[] arr) {
        return Math.Max(MaxTurbulenceSizeWithSign(arr, -1), MaxTurbulenceSizeWithSign(arr, 1));
    }
    private int MaxTurbulenceSizeWithSign(int[] arr, int initialComparisonSign) {
        int max = 0;
        int sum = 0;
        int comparisonSign = initialComparisonSign;
        for(int i = 0; i < arr.Length; i++){
            if(i == 0){
                sum = 1;
                max = 1;
            }
            else{
                if(ValuesDontWorkWithCompar(arr[i-1], arr[i], comparisonSign)){
                    sum = 1;
                    max = Math.Max(sum, max);
                    comparisonSign = initialComparisonSign;
                    if (!ValuesDontWorkWithCompar(arr[i-1], arr[i], comparisonSign)) {
                        sum = 2;
                        max = Math.Max(sum, max);
                        comparisonSign *= -1;
                    }
                }
                else{
                    sum++;
                    max = Math.Max(sum, max);
                    comparisonSign *= -1;
                }
            }
        }
        return max;
    }

    private bool ValuesDontWorkWithCompar(int val1, int val2, int comparisonSign){
        if(val1 == val2){
            return true;
        }
        else if(val1 < val2){
            return comparisonSign != 1;
        }
        else{
            return comparisonSign != -1;
        }
    }
}