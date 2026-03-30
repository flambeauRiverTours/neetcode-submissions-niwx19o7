public class Solution {

    private Dictionary<int, List<int>> prerequistesForACourse = new Dictionary<int, List<int>>();
    private List<int> coursesWithNoPreRequisities = new List<int>();
    private Dictionary<int, List<int>> coursePotentiallyEnabledByCourse = new Dictionary<int, List<int>>();
    private HashSet<int> takenCourses = new HashSet<int>();
    public int[] FindOrder(int numCourses, int[][] prerequisites) {
        BuildPreReqDict(numCourses, prerequisites);
        Queue<int> bfsQueue = new Queue<int>();
        foreach(int courseWithNoPrereqs in coursesWithNoPreRequisities){
            bfsQueue.Enqueue(courseWithNoPrereqs);
        }
        takenCourses = new HashSet<int>();
        List<int> result = new List<int>();
        while(bfsQueue.Count > 0){
            int timesToDequeue = bfsQueue.Count;
            while(timesToDequeue > 0){
                timesToDequeue--;
                int takenCourse = bfsQueue.Dequeue();
                if (takenCourses.Contains(takenCourse)) continue;
                takenCourses.Add(takenCourse);
                result.Add(takenCourse);
                foreach(int potentiallyEnabledCourse in coursePotentiallyEnabledByCourse[takenCourse]){
                    if(!takenCourses.Contains(potentiallyEnabledCourse)){
                        bool missingPrereq = false;
                        foreach(int coursePrereq in prerequistesForACourse[potentiallyEnabledCourse]){
                            if(!takenCourses.Contains(coursePrereq)){
                                missingPrereq = true;
                                break;
                            }
                        }
                        if(!missingPrereq){
                            bfsQueue.Enqueue(potentiallyEnabledCourse);
                        }
                    }
                }
            }
        }
        return takenCourses.Count == numCourses ? result.ToArray() : new int[0];
    }

    private void BuildPreReqDict(int numCourse, int[][] prerequisits){
        for(int i = 0; i < numCourse; i++){
            prerequistesForACourse.Add(i, new List<int>());
            coursePotentiallyEnabledByCourse.Add(i, new List<int>());
        }
        for(int i = 0; i < prerequisits.Length; i++){
            prerequistesForACourse[prerequisits[i][0]].Add(prerequisits[i][1]);
            coursePotentiallyEnabledByCourse[prerequisits[i][1]].Add(prerequisits[i][0]);
        }
        for(int i = 0; i < numCourse; i++){
            if(prerequistesForACourse[i].Count == 0){
                coursesWithNoPreRequisities.Add(i);
            }
        }
    }
}