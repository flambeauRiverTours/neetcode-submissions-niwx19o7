public class MinHeap {
    List<int> heapList = new List<int>();
    public MinHeap() {
        heapList.Add(-1);
    }

    public void Push(int val) {
        heapList.Add(val);
        int currentIndex = heapList.Count - 1;
        while(currentIndex > 1){
            int parentIndex = currentIndex / 2;
            if(heapList[currentIndex] < heapList[parentIndex]){
                SwapHeapValuesAtIndices(parentIndex, currentIndex);
                currentIndex = parentIndex;
            }
            else{
                break;
            }
        }
    }

    public int? Pop() {
        if(heapList.Count == 1) {return -1;}
        int result = heapList[1];
        heapList[1] = heapList[heapList.Count - 1];
        heapList.RemoveAt(heapList.Count - 1);
        PercolateUp(1);
        return result;
    }

    private void PercolateUp(int startIndex){
        int currentIndex = startIndex;
        while(currentIndex < heapList.Count){
            int leftChildIndex = 2 * currentIndex;
            int rightChildIndex = leftChildIndex + 1;
            if((rightChildIndex < heapList.Count) && 
                (heapList[rightChildIndex] < heapList[leftChildIndex]) &&
                (heapList[rightChildIndex] < heapList[currentIndex]))
            {
                SwapHeapValuesAtIndices(rightChildIndex, currentIndex);
                currentIndex = rightChildIndex;
            }
            else if((leftChildIndex < heapList.Count) &&
                (heapList[leftChildIndex] < heapList[currentIndex])){
                SwapHeapValuesAtIndices(leftChildIndex, currentIndex);
                currentIndex = leftChildIndex;
            }
            else{
                break;
            }
        }
    }

    private void SwapHeapValuesAtIndices(int indexA, int indexB){
        int temp = heapList[indexA];
        heapList[indexA] = heapList[indexB];
        heapList[indexB] = temp;
    }

    public int? Top() {
        if(heapList.Count == 1) {return -1;}
        return heapList[1];
    }

    public void Heapify(List<int> nums) {
        heapList.Clear();
        heapList.Add(-1);
        heapList.AddRange(nums);
        int halfwayPoint = heapList.Count / 2;
        for(int i = halfwayPoint; i >= 1; i--){
            PercolateUp(i);
        }
    }

}