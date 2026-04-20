public class Solution {
    public double MyPow(double x, int n) {
        if(n == 0) {return 1;}
        if(n < 0){
            return MyPow(x, n + 1) / x;
        }
        else{
            return MyPow(x, n - 1) * x;
        }
    }
}
