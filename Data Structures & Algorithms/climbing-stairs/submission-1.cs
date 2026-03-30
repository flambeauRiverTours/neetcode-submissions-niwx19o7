public class Solution {
    Dictionary<int,int> solutionHashmap = new Dictionary<int,int>();
    public int ClimbStairs(int n) {     
        if(n <= 2){
            return n;
        }
        if(solutionHashmap.Keys.Contains(n)){ return solutionHashmap[n]; }
        int solution = ClimbStairs(n - 1) + ClimbStairs(n - 2);
        solutionHashmap.Add(n, solution);
        return solution;
    }
}
