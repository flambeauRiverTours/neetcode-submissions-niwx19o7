public class Solution {
    public List<Pair> QuickSort(List<Pair> pairs) {
        QuickSortInternal(pairs, 0, pairs.Count - 1);
        return pairs;
    }

    private void QuickSortInternal(List<Pair> pairs, int left, int pivot){
        if(left >= pivot) {return;}
        int swapNode = left;
        for(int i = left; i < pivot; i++){
            if(pairs[i].Key < pairs[pivot].Key){
                Pair temp = pairs[i];
                pairs[i] = pairs[swapNode];
                pairs[swapNode] = temp;
                swapNode++;
            }
        }
        Pair pivotTemp = pairs[pivot];
        pairs[pivot] = pairs[swapNode];
        pairs[swapNode] = pivotTemp;

        QuickSortInternal(pairs, left, swapNode - 1);
        QuickSortInternal(pairs, swapNode + 1, pivot);
    }
}