public class MinStack {

    Stack<int> valueStack;
    Stack<int> minValueStack;
    public MinStack() {
        valueStack = new Stack<int>();
        minValueStack = new Stack<int>();
    }
    
    public void Push(int val) {
        valueStack.Push(val);
        if(minValueStack.Count == 0){
            minValueStack.Push(val);
        }
        else{
            if(val <  minValueStack.Peek()){
                minValueStack.Push(val);
            }
            else{
                minValueStack.Push(minValueStack.Peek());
            }
        }
    }
    
    public void Pop() {
        valueStack.Pop();
        minValueStack.Pop();
    }
    
    public int Top() {
        return valueStack.Peek();
    }
    
    public int GetMin() {
        return minValueStack.Peek();
    }
}
