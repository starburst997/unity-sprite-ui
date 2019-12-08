using System.IO;
using UnityEditor;
using UnityEngine;
using SpriteUI;

[InitializeOnLoad]
public static class DrawHierarchyIcon
{
    private static readonly Texture2D Icon;

    static DrawHierarchyIcon()
    {
        Icon = AssetDatabase.LoadAssetAtPath("Packages/com.failsafegames.spriteui/Editor/Gizmos/SpriteUI/UI.png", typeof(Texture2D)) as Texture2D;
        if (Icon == null) return;

        EditorApplication.hierarchyWindowItemOnGUI += DrawIconOnWindowItem;
    }

    private static void DrawIconOnWindowItem(int instanceID, Rect rect)
    {
        if (Icon == null) return;

        GameObject gameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
        if (gameObject == null) return;

        UI ui = gameObject.GetComponent<UI>();
        if (ui == null) return;
        
        float iconWidth = 15;
        EditorGUIUtility.SetIconSize(new Vector2(iconWidth, iconWidth));
        
        Vector2 padding = new Vector2(5, 0);
        Rect iconDrawRect = new Rect(rect.xMax - (iconWidth + padding.x), rect.yMin, rect.width, rect.height);
        
        GUIContent iconGuiContent = new GUIContent(Icon);
        EditorGUI.LabelField(iconDrawRect, iconGuiContent);
        EditorGUIUtility.SetIconSize(Vector2.zero);
    }
}
