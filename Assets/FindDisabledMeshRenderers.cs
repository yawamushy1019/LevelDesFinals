using UnityEditor;
using UnityEngine;

public class FindDisabledMeshRenderers : EditorWindow
{
    [MenuItem("Tools/Find Disabled Mesh Renderers")]
    public static void ShowWindow()
    {
        GetWindow<FindDisabledMeshRenderers>("Disabled Mesh Renderers");
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Find Disabled Mesh Renderers"))
        {
            FindAndSelectDisabledMeshRenderers();
        }
    }

    private void FindAndSelectDisabledMeshRenderers()
    {
        // Find all MeshRenderers in the scene
        MeshRenderer[] allMeshRenderers = FindObjectsOfType<MeshRenderer>(true); // 'true' includes inactive GameObjects

        // Clear previous selection
        Selection.objects = new Object[0];

        System.Collections.Generic.List<GameObject> disabledRenderers = new System.Collections.Generic.List<GameObject>();

        foreach (MeshRenderer renderer in allMeshRenderers)
        {
            // Check if the MeshRenderer component itself is disabled
            if (!renderer.enabled)
            {
                disabledRenderers.Add(renderer.gameObject);
            }
        }

        if (disabledRenderers.Count > 0)
        {
            Selection.objects = disabledRenderers.ToArray();
            Debug.Log($"Found {disabledRenderers.Count} GameObjects with disabled Mesh Renderers.");
        }
        else
        {
            Debug.Log("No GameObjects with disabled Mesh Renderers found.");
        }
    }
}