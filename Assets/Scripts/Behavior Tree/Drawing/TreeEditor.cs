using UnityEngine;
using UnityEditor;

public class TreeEditor : EditorWindow {
    public TreeRenderer drawTree;

    [MenuItem("BehaviorTree/Editor")]
    public static void Init() {
        GetWindow<TreeEditor>("Behavior Tree Editor");
    }

    void OnGUI() {
        if (GUILayout.Button("New Tree")) {
            if (drawTree != null) drawTree.ClearTree();
            drawTree = new TreeRenderer();
            drawTree.NewTree();
        }

        if (GUILayout.Button("Destroy Tree")) {
            drawTree.DestroyTree();
        }

        GUILayout.Space(10f);

        if (GUILayout.Button("Add Selector")) {
            drawTree.AddSelector();
        }

        if (GUILayout.Button("Add Sequence")) {
            drawTree.AddSequence();
        }

        if (GUILayout.Button("Add Action")) {
            drawTree.AddAction();
        }
        
        if (GUILayout.Button("Add Node")) {
            drawTree.AddNode(Enums.types.selector, "New node");
        }
    }

    void OnSelectionChange() {
        Debug.Log("Selection changed");
        if (Selection.activeGameObject.GetComponent<MyNode>() != null) {
            drawTree.UpdateSelected(Selection.activeGameObject);
        }
    }
}