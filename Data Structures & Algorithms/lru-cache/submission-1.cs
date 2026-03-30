public class LRUCache {
    Dictionary<int, int> keyValueDictionary; 
    PriorityQueue<int, int> lruQueue;
    int dictCapacity;
    int operationCount;
    public LRUCache(int capacity) {
        keyValueDictionary = new Dictionary<int, int>();
        lruQueue = new PriorityQueue<int, int>();
        dictCapacity = capacity;
        operationCount = 0;
    }
    
    public int Get(int key) {
        if(keyValueDictionary.ContainsKey(key)){
            operationCount++;
            UpdateLRUCacheForKey(key);
            return keyValueDictionary[key];
        }
        return -1;
    }

    private void UpdateLRUCacheForKey(int key){
        lruQueue.Remove(key, out int removedElement, out int priority);
        lruQueue.Enqueue(key, operationCount);
    }
    
    public void Put(int key, int value) {
        operationCount++;
        if(keyValueDictionary.ContainsKey(key)){
            UpdateLRUCacheForKey(key);
            keyValueDictionary[key] = value;
        }
        else{
            keyValueDictionary.Add(key, value);
            lruQueue.Enqueue(key, operationCount);
            if(keyValueDictionary.Keys.Count() > dictCapacity){
                int keyToRemove = lruQueue.Dequeue();
                keyValueDictionary.Remove(keyToRemove);
            }
        }
    }
}
