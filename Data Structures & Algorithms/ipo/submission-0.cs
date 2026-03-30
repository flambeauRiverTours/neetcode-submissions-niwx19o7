public class Solution {
    public int FindMaximizedCapital(int k, int w, int[] profits, int[] capital) {
        PriorityQueue<int,int> affordableProject = new PriorityQueue<int, int>();
        PriorityQueue<int,int> unaffordableProject = new PriorityQueue<int, int>();
        for(int i = 0; i < profits.Length; i++){
            if(capital[i] <= w){
                affordableProject.Enqueue(i, -1 * profits[i]);
            }
            else{
                unaffordableProject.Enqueue(i, capital[i]);
            }
        }
        
        while((k > 0) && (affordableProject.Count > 0)){
            int index = affordableProject.Dequeue();
            if(w >= capital[index]){
                w += profits[index];
                k--;
            }
            while((unaffordableProject.Count > 0) && (capital[unaffordableProject.Peek()] <= w)){
                int nowAffordableProject = unaffordableProject.Dequeue();
                affordableProject.Enqueue(nowAffordableProject, -1 * profits[nowAffordableProject]);
            }
            
        }
        return w;
    }
}