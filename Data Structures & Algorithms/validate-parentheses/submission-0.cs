public class Solution {

    public bool IsValid(string s) {
        Stack<char> stack = new Stack<char>();
        for(int i = 0; i < s.Length; i++)
        {
            if(ShouldPushValue(s[i])){
                stack.Push(s[i]);
            }
            else if (ShouldPopVal(s[i]))
            {
                if(!TryPop(s[i], stack)){
                    return false;
                }
            }

        }
        return stack.Count == 0;
    }

    private bool ShouldPushValue(char val){
        switch (val)
        {
            case '(':
                return true;
            case '{':
                return true;
            case '[':
                return true;
            default:
                return false; //char we should not push
        }
    }

    private bool ShouldPopVal(char val){
        switch (val)
        {
            case ')':
                return true;
            case '}':
                return true;
            case ']':
                return true;
            default:
                return false; //char we should not push
        }
    }

    private bool TryPop(char val, Stack<char> stack){
        if(stack.Count == 0) {return false;}
        char poppedChar = stack.Pop();
        switch (poppedChar)
        {
            case '(':
                if(val == ')') {return true;}
                break;
            case '{':
                if(val == '}') {return true;}
                break;
            case '[':
                if (val == ']') {return true;}
                break;
            default:
                return false; //unrecognized char
        }
        return false;
    }
}
