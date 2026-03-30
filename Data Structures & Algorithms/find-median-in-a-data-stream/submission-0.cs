public class MedianFinder {
    private PriorityQueue<int, int> smallHeap;
    private PriorityQueue<int, int> bigHeap;
    public MedianFinder() {
        smallHeap = new PriorityQueue<int, int>();
        bigHeap = new PriorityQueue<int, int>();
    }
    
    public void AddNum(int num) {
        smallHeap.Enqueue(num, num * -1);
        if(((smallHeap.Count - bigHeap.Count) > 1) || ((bigHeap.Count > 0) && (bigHeap.Peek() < smallHeap.Peek()))){
            int numToSwap = smallHeap.Dequeue();
            bigHeap.Enqueue(numToSwap, numToSwap);
        }
        if (bigHeap.Count > smallHeap.Count) {
            int numToSwap = bigHeap.Dequeue();
            smallHeap.Enqueue(numToSwap, numToSwap * -1);
        }
    }
    
    public double FindMedian() {
        if(smallHeap.Count > bigHeap.Count){
            return smallHeap.Peek();
        }
        else if (bigHeap.Count > smallHeap.Count){
            return bigHeap.Peek();
        }
        return (bigHeap.Peek() + smallHeap.Peek()) / 2.0;
    }
}