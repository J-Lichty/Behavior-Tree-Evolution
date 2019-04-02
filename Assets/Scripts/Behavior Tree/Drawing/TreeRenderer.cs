using UnityEngine;

[ExecuteInEditMode]
public class TreeRenderer {

    BehaviorTree tree;
    GameObject treeDisplay;
    GameObject selected;
    GameObject pointer;
    int selector, sequence, action;
    
    public void InitTree() {
        Debug.Log("Tree initialized");
        tree = new BehaviorTree(null);
        selector = 0;
        sequence = 0;
        action = 0;
    }

    public void NewTree() {
        InitTree();
        Debug.Log("Tree Created");
        pointer = new GameObject("Pointer");
        pointer.AddComponent<Light>();
        pointer.transform.position = new Vector3(0, 0, -1);
        UpdateTree();
    }

    public void UpdateTree() {
        ClearTree();
        treeDisplay = DrawCube(null, tree.root, 0);
        DrawTree(treeDisplay, tree.root);
    }

    public void DrawTree(GameObject parent, Node node) {
        for (int i = 0; i < node.Children.Count; i++) { 
            DrawTree(parent, node.Children[i]);
            DrawCube(parent.transform, node.Children[i], i);
        }
    }

    private GameObject DrawCube(Transform parent, Node node, int i) {
        GameObject obj = (GameObject)Object.Instantiate(Resources.Load("node"));
        obj.name = node.name;
        obj.GetComponent<MyNode>().reference = node;
        if (parent != null) {
            obj.transform.parent = parent;
            obj.transform.position = new Vector3(i*2, -2, 0);
        } else {
            obj.transform.position = Vector3.zero;
        }
        obj.transform.GetChild(0).GetComponent<TextMesh>().text = node.name;
        obj.transform.GetChild(0).transform.localPosition = new Vector3(0.5f, 0.375f, -0.5f);
        obj.transform.GetChild(0).transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        return obj;
    }

    public void ClearTree() {
        Debug.Log("Tree cleared");
        Object.DestroyImmediate(treeDisplay);
    }

    public void DestroyTree() {
        ClearTree();
        Object.DestroyImmediate(pointer);
    }

    public void AddNode(Enums.types type, string name) {
        if (selected != null) {
            Node parent = selected.GetComponent<MyNode>().reference;
            tree.AddNode(new ActionNode(parent, "Selector" + selector++, new NodeAction()));
            Debug.Log("Selected Node: " + parent.name);
            UpdateTree();
        } else {
            Debug.LogError("No parent node selected");
        }
    }

    public void AddSelector() {
        tree.AddNode(new SelectorNode(tree.Active, "Selector" + selector++));
        Debug.Log("Selector Added");
        UpdateTree();
    }

    public void AddSequence() {
        tree.AddNode(new SequenceNode(tree.Active, "Sequence" + sequence++));
        Debug.Log("Sequence Added");
        UpdateTree();
    }

    public void AddAction() {
        tree.AddNode(new ActionNode(tree.Active, "Action" + action++, new NodeAction()));
        Debug.Log("Action Added");
        UpdateTree();
    }

    public void UpdateSelected(GameObject _selected) {
        selected = _selected;
        Debug.Log("Node selected");
        pointer.transform.position = _selected.transform.position + Vector3.back;
    }
}


/*
        var d1, d2, d3, d4, d5;
        d1 = this.addNode(this.root, "Selector", "Live");


        // Safe?
        d2 = this.addNode(d1, "Sequence", "Danger?");
            this.addNode(d2, "Action", "Low Health?", function() {entity.getHealth()});
            this.addNode(d2, "Action", "Threats?", function() {entity.getThreat()});
            // d3 = this.addNode(d2, "Selector", "F(l?)ight");
                d3 = this.addNode(d2, "Sequence", "Fight");
                    this.addNode(d3, "Action", "Threshold", function() {entity.getAggression()});
                    this.addNode(d3, "Action", "Get Location", function() {entity.getLocation("Attack")});
                    this.addNode(d3, "Action", "Find", function() {entity.moveToFind("Attack")});
                    this.addNode(d3, "Action", "Attack", function() {entity.attack()});
                // d4 = this.addNode(d3, "Sequence", "Flight");
                // this.addNode(d4, "Action", "Safe Location", function() {entity.getLocation("Safe")});
                // this.addNode(d4, "Action", "Run", function() {entity.moveTo()});

        // Hungry
        d2 = this.addNode(d1, "Sequence", "Hungry?");
            this.addNode(d2, "Action", "Threshold", function() {entity.getStamina()});
            d3 = this.addNode(d2, "Sequence", "Find Food");
                d4 = this.addNode(d3, "Selector", "Get location");
                    this.addNode(d4, "Action", "Known", function() {entity.getLocation("Food")});
                    this.addNode(d4, "Action", "Random", function() {entity.getLocation("Random")});
                this.addNode(d3, "Action", "Find", function() {entity.moveToFind("Food")});
                this.addNode(d3, "Action", "Eat", function() {entity.eat()});

        // Mate?
        d2 = this.addNode(d1, "Sequence", "Mate?");
            this.addNode(d2, "Action", "Threshold", function() {entity.getMatingTimer()});
            var d3 = this.addNode(d2, "Sequence", "Find Mate");
                d4 = this.addNode(d3, "Selector", "Get location");
                    this.addNode(d4, "Action", "Known", function() {entity.getLocation("Mate")});
                    this.addNode(d4, "Action", "Random", function() {entity.getLocation("Random")});
                this.addNode(d3, "Action", "Find", function() {entity.moveToFind("Mate")});
                this.addNode(d3, "Action", "Mate", function() {entity.mate()});

        // Idle
        d2 = this.addNode(d1, "Sequence", "Wander");
            this.addNode(d2, "Action", "Random", function() {entity.getLocation("Random")});
            this.addNode(d2, "Action", "MoveTo", function() {entity.moveTo()});

        // init
        this.setActive(this.root);
    }
    */