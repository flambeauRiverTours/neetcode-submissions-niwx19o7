class Deque {


    DequeEl head = null;
    DequeEl tail = null;
    public Deque() {

    }

    public bool isEmpty() {
        return (head == null);
    }

    public void append(int value) {
        DequeEl newEl = new DequeEl(value, null, tail);
        if(tail == null){
            head = newEl;
            tail = newEl;
            return;
        }
        tail.next = newEl;
        tail = newEl;
    }

    public void appendleft(int value) {
        DequeEl newEl = new DequeEl(value, head, null);
        if(head == null){
            head = newEl;
            tail = newEl;
            return;
        }
        head.prev = newEl;
        head = newEl;
    }

    public int pop() {
        if(isEmpty()) {return -1;}
        int valToReturn = tail.val;
        tail = tail.prev;
        if(tail == null){
            head = null;
        }
        else{
            tail.next = null;
        }
        return valToReturn;
    }

    public int popleft() {
        if(isEmpty()) {return -1;}
        int valToReturn = head.val;
        head = head.next;
        if(head == null) //now we're empty
        {
            tail = null;
        }
        else{
            head.prev = null;
        }
        return valToReturn;
    }
}

public class DequeEl{
    public int val;
    public DequeEl next;
    public DequeEl prev;
    public DequeEl(int _val, DequeEl _next, DequeEl _prev){
        val = _val;
        prev = _prev;
        next = _next;
    }
}
