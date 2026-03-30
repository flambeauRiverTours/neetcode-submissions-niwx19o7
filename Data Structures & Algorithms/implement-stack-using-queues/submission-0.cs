public class MyStack {

    Queue<int> values = new Queue<int>();
    public MyStack() {
        
    }
    
    public void Push(int x) {
        values.Enqueue(x);
    }
    
    public int Pop() {
        CycleQueueToTop();
        return values.Dequeue();
    }
    
    private void CycleQueueToTop(){
        int queueCyclesToRun = values.Count() - 1;
        for(int i = 0; i < queueCyclesToRun; i++){
            int tempVal = values.Dequeue();
            values.Enqueue(tempVal);
        }
    }

    public int Top() {
        CycleQueueToTop();
        int value = values.Dequeue();
        values.Enqueue(value);
        return value;
    }
    
    public bool Empty() {
        return values.Count == 0;
    }
}

/**
 * Your MyStack object will be instantiated and called as such:
 * MyStack obj = new MyStack();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Top();
 * bool param_4 = obj.Empty();
 */