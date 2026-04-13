public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        PriorityQueue<int, int> pq = new PriorityQueue<int, int>();
        foreach(int num in nums){
            if(pq.Remove(num, out int outNum, out int priority)){
                pq.Enqueue(num, priority - 1);
            }
            else{
                pq.Enqueue(num, -1);
            }
        }
        int[] result = new int[k];
        for(int i = 0; i < k; i++){
            result[i] = pq.Dequeue();
        }
        return result;
    }
}
