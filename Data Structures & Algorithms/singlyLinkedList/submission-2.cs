public class LinkedList {

    private LinkedListElement head = null;
    private LinkedListElement tail = null;
    public LinkedList() {

    }

    public int Get(int index) {
        LinkedListElement targetElement = head;
        while((index > 0) && (targetElement != null))
        {
            index--;
            targetElement = targetElement.nextElement;
        }
        if(targetElement == null) {return -1;}
        return targetElement.value;
    }

    public void InsertHead(int val) {
        LinkedListElement newHead = new LinkedListElement(val, head);
        head = newHead;
        if(tail == null){ //first element case
            tail = newHead;
        }
    }

    public void InsertTail(int val) {
        LinkedListElement newTail = new LinkedListElement(val, null);
        if(tail == null){
            tail = newTail;
            head = newTail;
            return;
        }
        tail.nextElement = newTail;
        tail = newTail;
    }

    public bool Remove(int index) {
        LinkedListElement targetElement = head;
        LinkedListElement lastElement = null;
        while((index > 0) && (targetElement != null))
        {
            index--;
            lastElement = targetElement;
            targetElement = targetElement.nextElement;
        }
        if(targetElement == null) {return false;}
        if(lastElement == null){
            //removing head
            head = targetElement.nextElement;
            if(head == null){
                tail = null;
            }
            return true;
        }
        lastElement.nextElement = targetElement.nextElement;
        if(lastElement.nextElement == null){
            tail = lastElement;
        }
        return true;
    }

    public List<int> GetValues() {
        List<int> vals = new List<int>();
        LinkedListElement currentElement = head;
        while(currentElement != null){
            vals.Add(currentElement.value);
            currentElement = currentElement.nextElement;
        }
        return vals;
    }
}

public class LinkedListElement{
    public LinkedListElement(int _val, LinkedListElement _next)
    {
        value = _val;
        nextElement = _next;
    }
    public int value;
    public LinkedListElement nextElement;
}