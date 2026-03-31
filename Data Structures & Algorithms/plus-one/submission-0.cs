public class Solution {
    public int[] PlusOne(int[] digits) {
        bool hasRemainder = true;
        for(int i = (digits.Length - 1); i >= 0; i--){
            if(hasRemainder){
                digits[i]++;
                if(digits[i] == 10){
                    digits[i] = 0;
                    hasRemainder = true;
                }
                else{
                    return digits;
                }
            }
        }
        if(hasRemainder){
            int[] newArr = new int[digits.Length + 1];
            newArr[0] = 1;
            for(int i = 0; i < digits.Length; i++){
                newArr[i+1] = digits[i];
            }
            return newArr;
        }
        else{
            return digits;
        }
    }
}
