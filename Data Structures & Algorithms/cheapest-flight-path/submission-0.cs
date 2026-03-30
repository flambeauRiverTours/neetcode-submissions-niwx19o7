public class Solution {
    public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k) {
        Dictionary<int, List<(int dest, int cost)>> adjList = new Dictionary<int, List<(int dest, int cost)>>();
        for(int i = 0; i < n; i++){
            adjList[i] = new List<(int dest, int cost)>();
        }
        for(int i = 0; i < flights.Length; i++){
            adjList[flights[i][0]].Add((flights[i][1], flights[i][2]));
        }
        int numFlights = 0;
        Queue<(int nextAirport, int currentCost)> nextSetOfFlights = new Queue<(int nextAirport, int currentCost)>();
        HashSet<int> visited = new HashSet<int>();
        Dictionary<int, int> airportToItineraryCostMapping = new Dictionary<int, int>();
        nextSetOfFlights.Enqueue((src, 0));
        visited.Add(src);
        int potentialSolution = -1;
        while((nextSetOfFlights.Count > 0) && (numFlights <= k)){
            int count = nextSetOfFlights.Count;
            for(int i = 0; i < count; i++){
                (int sourceAirport, int currentCost) = nextSetOfFlights.Dequeue();
                foreach((int dest, int cost) in adjList[sourceAirport]){
                    if(!visited.Contains(dest)){
                        if(dest == dst){
                            int potentialCost = currentCost + cost;
                            if((potentialSolution == -1) || (potentialSolution > potentialCost)){
                                potentialSolution = potentialCost;
                            }
                        }
                        else{
                            nextSetOfFlights.Enqueue((dest, currentCost + cost));
                            visited.Add(dest);
                        }
                    }
                }
            }
            numFlights++;
        }
        return potentialSolution;
    }
}
