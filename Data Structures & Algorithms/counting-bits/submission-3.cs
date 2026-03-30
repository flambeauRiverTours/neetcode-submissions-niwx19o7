public class Solution {
    public int[] CountBits(int n) {
        int[] cache = new int[n + 1];
        cache[0] = 0;
        if(n > 0){
        cache[1] = 1;
        for(int i = 2; i <= n; i++){
            cache[i] = cache[i / 2] + (i % 2);
        }
        }
        return cache;
    }
}
