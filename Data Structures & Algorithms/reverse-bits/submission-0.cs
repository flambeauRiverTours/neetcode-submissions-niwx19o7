public class Solution {
    public uint ReverseBits(uint n) {
        uint result = 0;

        for(int i  = 0; i < 32; i++) {
            result = result << 1;
            uint addl = n & 1;
            result += addl;
            n = n >> 1;
            
        }
        return result;
    }
}
