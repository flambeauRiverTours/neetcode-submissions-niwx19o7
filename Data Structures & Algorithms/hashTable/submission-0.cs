public class HashTable {
    KeyVal[] hashArray;
    int currentCapacity;
    int keyCount;
    public HashTable(int capacity) {
        hashArray = new KeyVal[capacity];
        currentCapacity = capacity;
        keyCount = 0;
    }

    private int GetIndexFromKey(int key){
        return key % currentCapacity;
    }
    public void Insert(int key, int value) {
        int index = GetIndexFromKey(key);
        if(hashArray[index] == null){
            hashArray[index] = new KeyVal(key, value);
            keyCount++;
        }
        else{
            if((hashArray[index] as KeyVal).key == key){
                (hashArray[index] as KeyVal).val = value;
            }
            else{
                Resize();
                Insert(key, value);
            }
        }
        if(((double)keyCount / (double)currentCapacity) >= 0.5){
            Resize();
        }
    }



    public int Get(int key) {
        int index = GetIndexFromKey(key);
        if(hashArray[index] == null){
            return -1;
        }
        return hashArray[index].val;
    }

    public bool Remove(int key) {
        int index = GetIndexFromKey(key);
        if(hashArray[index] == null){
            return false;
        }
        keyCount--;
        hashArray[index] = null;
        return true;
    }

    public int GetSize() {
        return keyCount;

    }

    public int GetCapacity() {
        return currentCapacity;
    }

    public void Resize() {
        KeyVal[] oldArray = hashArray;
        currentCapacity = currentCapacity * 2;
        hashArray = new KeyVal[currentCapacity];
        keyCount = 0;
        foreach(KeyVal pair in oldArray){
            if(pair != null){
                Insert((pair as KeyVal).key, (pair as KeyVal).val);
            }
        }
    }
}

public class KeyVal{
    public KeyVal(int inputKey, int inputVal){
        key = inputKey;
        val = inputVal;
    }
    public int key;
    public int val;
}
