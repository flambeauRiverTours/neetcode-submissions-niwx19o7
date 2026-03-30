public class Solution {
    public bool MergeTriplets(int[][] triplets, int[] target) {
        int[] currentTriplet = new int[3];
        for(int i = 0; i < triplets.Length; i++){
            if(ShouldUpdateTriplet(triplets[i], target, currentTriplet)){
                UpdateTriplet(currentTriplet, triplets[i]);
                if(TripletComplete(currentTriplet, target)){
                    return true;
                }
            }
        }
        return false;
    }

    private void UpdateTriplet(int[] currentTriplet, int[] newTriplet){
        for(int i = 0; i < 3; i++){
            currentTriplet[i] = Math.Max(currentTriplet[i], newTriplet[i]);
        }
    }

    private bool TripletComplete(int[] currentTriplet, int[] targetTriplet){
        return (currentTriplet[0] == targetTriplet[0]) &&(currentTriplet[1] == targetTriplet[1]) && (currentTriplet[2] == targetTriplet[2]);
    }

    private bool ShouldUpdateTriplet(int[] newTriplet, int[] targetTriplet, int[] currentTriplet){
        bool shouldUpdate = false;
        
        for(int i = 0; i < 3; i++){
            if(newTriplet[i] > targetTriplet[i]) {return false;}
            if(newTriplet[i] == targetTriplet[i]){
                shouldUpdate = true;
            }
        }
        return shouldUpdate;
    }
}
