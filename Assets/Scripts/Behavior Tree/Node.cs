using System.Collections.Generic;

public class Node {

    public Node Parent { get; }
    public string name;
    protected int level;
    private List<Node> _children;
    public Enums.states? state;
    public Enums.types type;

    public List<Node> Children {
        get { return _children; }
        set { _children = value; }
    }

    public Node(Node _parent, string _name, Enums.types _type) {
        Parent = _parent;
        name = _name;
        level = Parent.level + 1;
        Children = new List<Node>();
        state = null;
        type = _type;
    }

    public Node(string _name, Enums.types _type) {
        Parent = null;
        name = _name;
        level = 0;
        Children = new List<Node>();
        state = null;
        type = _type;
    }

    public void Tick(BehaviorTree tree) {
    }

    public void Reset() {
    }
}