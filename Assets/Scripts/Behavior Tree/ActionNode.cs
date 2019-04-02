public class ActionNode : Node {

    NodeAction action;

    public ActionNode(Node _parent, string _name, NodeAction _action) : base(_parent, _name, Enums.types.action) {
        action = _action;
    }

    public new void Tick(BehaviorTree tree) {
        if (state != Enums.states.running) {
            state = Enums.states.running;
            action.Run();
        }
    }

    public void Finish(bool succeeded, BehaviorTree tree) {
        if (succeeded) {
            state = Enums.states.success;
        } else {
            state = Enums.states.failure;
        }
        tree.Active = Parent;
    }
}
