public class Solution {
    public int MinEatingSpeed(int[] piles, int h) {
        int pilesMax = MaxPiles(piles);
        return MinEatingSpeed(piles, 1, pilesMax, h);
    }

    private int MaxPiles(int[] piles){
        int pilesMax = 1;
        for(int i = 0; i < piles.Length; i++){
            if(piles[i] > pilesMax){
                pilesMax = piles[i];
            }
        }
        return pilesMax;
    }

    private int MinEatingSpeed(int[] piles, int left, int right, int hours){
        if(left > right) {return left;}

        int mid = left + ((right - left) / 2);
        if(CanEatPilesInHoursGivenRate(piles, hours, mid)){
            return MinEatingSpeed(piles, left, mid - 1, hours);
        }
        else{
            return MinEatingSpeed(piles, mid + 1, right, hours);
        }
    }

    private bool CanEatPilesInHoursGivenRate(int[] piles, int hours, int rate){
        long totalHours = 0;
        foreach (int pile in piles) {
            totalHours += (pile + rate - 1) / (long)rate;
        }
        return totalHours <= hours;
    }
}
