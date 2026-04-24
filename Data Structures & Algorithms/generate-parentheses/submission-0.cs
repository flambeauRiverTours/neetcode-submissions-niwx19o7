public class Solution {  
    public List<string> GenerateParenthesis(int n) {
        return GenParen(2 * n, "", 0);
    }

    private List<string> GenParen(int n, string parens, int openParenCount){
        if (n == 0){
            return new List<string>() {parens};
        }
        if(parens.Length == 0){
            parens = "(";
            return GenParen(n - 1, parens, 1);
        }
        else{
            int totalLength = parens.Length + n;
            int closedParenCount = parens.Length - openParenCount;
            int diffOpenClosed = openParenCount - closedParenCount;
            
            bool canAddOpen = openParenCount < totalLength / 2;
            bool canAddClosed = diffOpenClosed > 0;

            List<string> result = new List<string>();
            if(canAddOpen && canAddClosed){
                result.AddRange(GenParen(n - 1, parens + "(", openParenCount + 1));
                result.AddRange(GenParen(n - 1, parens + ")", openParenCount));
            }
            else if(canAddOpen){
                result.AddRange(GenParen(n - 1, parens + "(", openParenCount + 1));
            }
            else if(canAddClosed){
                //can only add closed
                 result.AddRange(GenParen(n - 1, parens + ")", openParenCount));
            }
            return result;
        }
    }
}