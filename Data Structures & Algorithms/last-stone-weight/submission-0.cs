public class Solution {
    PriorityQueue<int, int> pq = new PriorityQueue<int, int>();
    public int LastStoneWeight(int[] stones) {
        foreach(int stoneWeight in stones){
            AddStoneToPQ(stoneWeight);
        }
        while(pq.Count > 1){
            int heaviest = pq.Dequeue();
            int secondHeaviest = pq.Dequeue();
            int difference = heaviest - secondHeaviest;
            if(difference > 0){
                AddStoneToPQ(difference);
            }
        }
        return pq.Count == 1 ?  pq.Peek() : 0;
    }

    private void AddStoneToPQ(int stoneWeight){
        pq.Enqueue(stoneWeight, -1 * stoneWeight);
    }
}
