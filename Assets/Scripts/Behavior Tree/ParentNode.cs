public class ParentNode : Node {

    protected int index = 0;

    public ParentNode(Node _parent, string _name, Enums.types _type) : base(_parent, _name, _type) {
    }

    public new void Tick(BehaviorTree tree) {
        if (index <= Children.Count) {
            tree.Active = Children[index++];
        } else {
            if (Children[index - 1].state == Enums.states.success) {
                state = Enums.states.success;
            } else {
                state = Enums.states.failure;
            }
            if (Parent != null) {
                tree.Active = Parent;
            } else {
                Reset();
            }
        }
    }

    private new void Reset() {
        state = null;
        foreach (Node n in Children) {
            n.Reset();

        }
    }
}
