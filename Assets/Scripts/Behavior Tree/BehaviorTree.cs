using UnityEngine;

public class BehaviorTree {

    public Node root;
    GameObject entity;
    private Node _active;
    public Node Active {
        get { return _active; }
        set {
            _active = value;
        }  
     }

    public BehaviorTree(GameObject _entity) {
        root = new Node("Root", Enums.types.decorator);
        entity = _entity;
        Active = root;
    }
    
    public void Tick() {
        Active.Tick(this);
    }

    public void Interrupt() {
        root.Reset();
        Active = root;
    }

    public void AddNode(Node newNode) {
        newNode.Parent.Children.Add(newNode);
    }
}