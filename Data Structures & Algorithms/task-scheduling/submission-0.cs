public class Solution {

    public int LeastInterval(char[] tasks, int n) {
        Dictionary<char, int> charCounts = new Dictionary<char, int>();
        foreach(char task in tasks){
            if(!charCounts.ContainsKey(task)){
                charCounts[task] = 0;
            }
            charCounts[task]++;
        }
        int minCycles = 0;
        while(charCounts.Count > 0){
            minCycles += Cycle(charCounts, n + 1);
        }
        return minCycles;
    }

    private int Cycle(Dictionary<char, int> charCounts, int n){
        PriorityQueue<char, int> pq = new PriorityQueue<char, int>();
        foreach(char key in charCounts.Keys){
            pq.Enqueue(key, -1 * charCounts[key]);
        }
        int cyclesUsed = 0;
        while((cyclesUsed < n) && (pq.Count > 0)){
            char processed = pq.Dequeue();
            charCounts[processed]--;
            cyclesUsed++;
            if(charCounts[processed] == 0){
                charCounts.Remove(processed);
            }
        }
        return charCounts.Count > 0 ? n : cyclesUsed;
    }
}
