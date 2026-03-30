public class Solution {
    public int CanCompleteCircuit(int[] gas, int[] cost) {
        int tank = 0;
        int startedIndex = -1;
        int totalGas = 0;
        int totalCost = 0;
        int timesThrough = 0;
        int currentIndex = 0;
        for(int i = 0; i < gas.Length; i++){
            totalGas += gas[i];
            totalCost += cost[i];
        }
        if(totalGas < totalCost) {return -1;}
        while(timesThrough < 2){
            if(startedIndex == currentIndex) {return startedIndex;}
            tank += gas[currentIndex];
            tank -= cost[currentIndex];
            if(tank < 0) {startedIndex = -1; tank = 0;}
            else if (startedIndex == -1){
                startedIndex = currentIndex;
            }
            currentIndex++;
            if(currentIndex == gas.Length){
                currentIndex = 0;
                timesThrough++;
            }
        }
        return -1;
    }
}
