public class Solution {
    public int EvalRPN(string[] tokens) {
        Stack<int> stack = new Stack<int>();
        foreach (string token in tokens) {
            if (int.TryParse(token, out int val)) {
                stack.Push(val);
            } else {
                int b = stack.Pop();
                int a = stack.Pop();
                stack.Push(Operate(a, b, token));
            }
        }
        return stack.Pop();
    }

    private int Operate(int currentVal, int newVal, string operation){
        switch(operation){
            case "+":
                return currentVal + newVal;
            case "-":
                return currentVal - newVal;
            case "*":
                return currentVal * newVal;
            case "/":
                return currentVal / newVal;
            default:
                throw new Exception("Unhandled operator: " + operation);
        }
    }
}
