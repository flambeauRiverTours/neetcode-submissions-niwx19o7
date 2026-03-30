public class Solution {
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        BuildAdjacencyList(numCourses, prerequisites);
        Queue<int> queue = new Queue<int>();
        HashSet<int> takenCourses = new HashSet<int>();
        foreach(int course in GetCoursesWithoutPrereqs(numCourses)){
            queue.Enqueue(course);
            takenCourses.Add(course);
        }
        while(queue.Count > 0){
            int dequeuesToDo = queue.Count;
            for(int i = 0; i < dequeuesToDo; i++){
                int courseNowTaken = queue.Dequeue();
                foreach(int enabledCourse in adjacencyList[courseNowTaken]){
                    if(!takenCourses.Contains(enabledCourse) && CanTakeCourse(enabledCourse, takenCourses)){
                        takenCourses.Add(enabledCourse);
                        queue.Enqueue(enabledCourse);
                    }
                }
            }
        }
        return takenCourses.Count == numCourses;
    }

    private bool CanTakeCourse(int targetCourse, HashSet<int> takenCourses){
        foreach(int prereq in prerequisiteList[targetCourse]){
            if(!takenCourses.Contains(prereq)){
                return false;
            }
        }
        return true;
    }

    Dictionary<int, List<int>> adjacencyList = new Dictionary<int, List<int>>();
    Dictionary<int, List<int>> prerequisiteList = new Dictionary<int, List<int>>();
    private void BuildAdjacencyList(int numCourse, int[][] prerequisites){
        for(int i = 0; i < numCourse; i++){
            adjacencyList.Add(i, new List<int>());
            prerequisiteList.Add(i, new List<int>());
        }

        for(int i = 0; i < prerequisites.Length; i++){
            adjacencyList[prerequisites[i][1]].Add(prerequisites[i][0]);
            prerequisiteList[prerequisites[i][0]].Add(prerequisites[i][1]);
        }
    }

    private List<int> GetCoursesWithoutPrereqs(int numCourse){
        List<int> coursesWithoutPrereqs = new List<int>();
        for(int i = 0; i < numCourse; i++){
            if(prerequisiteList[i].Count == 0){
                coursesWithoutPrereqs.Add(i);
            }

        }
        return coursesWithoutPrereqs;
    }
}
