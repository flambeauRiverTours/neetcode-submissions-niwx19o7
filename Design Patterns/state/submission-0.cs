public interface IState {
    void HandleRequest(Document doc);
}

public class Document {
    private IState state;
    private bool isApproved;

    public Document() {
        this.state = new Draft();
    }

    public IState GetState() {
        return this.state;
    }

    public void SetState(IState state) {
        this.state = state;
    }

    public void Publish() {
        this.state.HandleRequest(this);
    }

    public void SetApproval(bool isApproved) {
        this.isApproved = isApproved;
    }

    public bool IsApproved() {
        return this.isApproved;
    }
}

public class Draft : IState {
    public Draft() {}
    public void HandleRequest(Document doc) {
        // Write your code here
        doc.SetState(new Review());
    }
}

public class Review : IState {
    public Review() {}
    public void HandleRequest(Document doc) {
        // Write your code here
        if(doc.IsApproved()){
            doc.SetState(new Published());
        }
        else{
            doc.SetState(new Draft());
        }
    }
}

public class Published : IState {
    public Published() {}
    public void HandleRequest(Document doc) {
        // Write your code here

    }
}
