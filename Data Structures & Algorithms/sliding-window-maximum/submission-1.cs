public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {
        List<int> result = new List<int>();
        PriorityQueue<int, int> queue = new PriorityQueue<int, int>();
        for(int i = 0; i < k; i++){
            queue.Enqueue(nums[i], -1 * nums[i]);
        }
        result.Add(queue.Peek());
        int firstElIndex = 0;
        for(int i = k; i < nums.Length; i++){
            queue.Remove(nums[firstElIndex], out int el, out int prio);
            firstElIndex++;
            queue.Enqueue(nums[i], -1 * nums[i]);
            result.Add(queue.Peek());
        }
        return result.ToArray();
    }
}
