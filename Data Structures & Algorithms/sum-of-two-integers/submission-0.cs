public class Solution {
    public int GetSum(int a, int b) {
        if(b == 0) {return a;}
        int sumWithoutCarry = a ^ b;
        int carryOnly = (a & b) << 1;
        return GetSum(sumWithoutCarry,carryOnly);
    }
}
