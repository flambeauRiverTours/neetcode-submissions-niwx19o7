public class Solution {
    
    public int FindKthLargest(int[] nums, int k) {
        PriorityQueue<int, int> pq = new PriorityQueue<int, int>();
        foreach(int num in nums){
            if(pq.Count < k){
                pq.Enqueue(num, num);
            }
            else if(num > pq.Peek()){
                pq.Dequeue();
                pq.Enqueue(num, num);
            }

        }
        return pq.Peek();
    }
}
