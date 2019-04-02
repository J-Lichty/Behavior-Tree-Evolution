using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TreeRenderer))]
public class TreeRendererEditor : Editor
{/*
    public override void OnInspectorGUI() {
        DrawDefaultInspector();

        TreeRenderer drawTree = (TreeRenderer)target;

        if (GUILayout.Button("New Tree")) {
            drawTree.NewTree();
        }

        if (GUILayout.Button("Update Tree")) {
            drawTree.UpdateTree();
        }

        if (GUILayout.Button("Clear Tree")) {
            drawTree.ClearTree();
        }

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
            Node selected = Selection.activeGameObject.GetComponent<MyNode>().reference;
            drawTree.AddNode(selected, selected.type, "New node");
        }
    }*/
}