public class SequenceNode : ParentNode {

    public SequenceNode(Node _parent, string _name) : base(_parent, _name, Enums.types.sequence) {}

    public new void Tick(BehaviorTree tree) {
        if (index > 0 && Children[index - 1].state == Enums.states.failure) {
            state = Enums.states.failure;
            index = Children.Count + 1;
        }
        if (index <= Children.Count) {
            tree.Active = this.Children[index++];
        } else {
            if (Children[index - 1].state == Enums.states.success) {
                state = Enums.states.success;
            } else {
                state = Enums.states.failure;
            }
            tree.Active = Parent;
        }
    }
}