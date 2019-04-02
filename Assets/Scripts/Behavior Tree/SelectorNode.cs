public class SelectorNode : ParentNode {

    public SelectorNode(Node _parent, string _name) : base(_parent, _name, Enums.types.selector) {}


    public new void Tick(BehaviorTree tree) {
        if (index > 0 && Children[index - 1].state == Enums.states.success) {
            state = Enums.states.success;
            index = Children.Count + 1;
        }
        if (index <= Children.Count) {
            tree.Active = Children[index++];
        } else {
            if (Children[index - 1].state == Enums.states.failure) {
                state = Enums.states.failure;
            } else {
                state = Enums.states.success;
            }
            tree.Active = Parent;
        }
    }

}