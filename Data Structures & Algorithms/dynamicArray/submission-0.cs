public class DynamicArray {
    
    private int[] baseArray;
    private int lastValuePointer = -1;
    public DynamicArray(int capacity) {
        baseArray = new int[capacity];
    }

    public int Get(int i) {
        return baseArray[i];
    }

    public void Set(int i, int n) {
        baseArray[i] = n;
    }

    public void PushBack(int n) {
        if((lastValuePointer + 1) == baseArray.Length){
            Resize();
        }
        lastValuePointer++;
        baseArray[lastValuePointer] = n;
    }

    public int PopBack() {
        int returnVal = baseArray[lastValuePointer];
        lastValuePointer--;
        return returnVal;
    }

    private void Resize() {
        int[] newArray = new int[baseArray.Length * 2];
        for(int i = 0; i <= lastValuePointer; i++){
            newArray[i] = baseArray[i];
        }
        baseArray = newArray;
    }

    public int GetSize() {
        return lastValuePointer + 1;
    }

    public int GetCapacity() {
        return baseArray.Length;
    }
}
