public class KthLargest {
    PriorityQueue<int, int> priorityQueue = new PriorityQueue<int, int>();
    int maxPQSize = -1;
    public KthLargest(int k, int[] nums) {
        foreach(int num in nums){
            priorityQueue.Enqueue(num, num);
        }
        while(priorityQueue.Count > k){
            priorityQueue.Dequeue();
        }
        maxPQSize = k;
    }
    
    public int Add(int val) {
        if(maxPQSize > priorityQueue.Count){
            priorityQueue.Enqueue(val, val);
        }
        else if(val > priorityQueue.Peek()) {
            priorityQueue.Dequeue();
            priorityQueue.Enqueue(val, val);
        }
        return priorityQueue.Peek();
    }
}
