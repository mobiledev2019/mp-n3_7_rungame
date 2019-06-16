using System;
using DG.DemiEditor;
using UnityEngine;
using UnityEditor;
using UnityEditor.UI;
using UnityEngine.Networking;


public class CreatMapEditor : EditorWindow {
    string myString = "Hello World";
    bool groupEnabled;
    bool myBool = true;
    float myFloat = 1.23f;
    public int[,] Map = new int[100, 7];
    private Vector2 scrollViewVector;
    private GUIStyle style;
    private static CreatMapEditor window;
    public Texture[,] tex = new Texture[100, 7];

    [MenuItem("ToolMap/My Window")]
    public static void ShowWindow() {
        window = (CreatMapEditor)EditorWindow.GetWindow(typeof(CreatMapEditor));
        window.Show();
    }

    private int row = 0;

    private string stringToEdit = "";

    void OnGUI() {
        GUI.changed = false;

        Rect rect1 = EditorGUILayout.BeginHorizontal();
         
        EditorGUI.LabelField(new Rect(0, 20, 50, 20), "Level : ");

        stringToEdit = EditorGUI.TextArea(new Rect(50, 20, 50, 20), stringToEdit);

        if (GUILayout.Button("Creat Row")) {
            row++;
            for (int i = 0; i < 7; i++)
            {
                Map[row, i] = 1;
            }
        }
        if (GUILayout.Button("Load Map"))
        {
            GetMap(int.Parse(stringToEdit));
        }
        if (GUILayout.Button("Save Map")) {
            UpdateMap(int.Parse(stringToEdit)); 
        }
        if (GUILayout.Button("Creat Map")) {
            CreatMap(int.Parse(stringToEdit));
        }
         
        EditorGUILayout.EndHorizontal();

        GUILayout.Space(40);
        GUILayout.BeginHorizontal();
        GUILayout.Space(30);
        GUILayout.EndHorizontal(); 

        
        Rect rect = EditorGUILayout.BeginHorizontal();
        scrollViewVector = GUILayout.BeginScrollView(scrollViewVector);
        GUILayout.Space(30);


        for (int i = 0; i < row; i++) {
            Rect rect2 = EditorGUILayout.BeginHorizontal();
            for (int j = 0; j < 7; j++) {
                if (Map[i, j] == 0) { 
                    tex[i, j] = (Texture)AssetDatabase.LoadAssetAtPath("Assets/Textures/Square.png", typeof(Texture)); 

                } else {
                    tex[i, j] = null;
                }

                if (GUILayout.Button(tex[i, j], GUILayout.Width(20), GUILayout.Height(20))) {

                    if (Map[i, j] > 0) {
                        Map[i, j] = 0;
                    } else {
                        Map[i, j] = 1;
                    }
                }
            }
             
            EditorGUILayout.EndHorizontal();

        }
        GUILayout.EndScrollView();
        EditorGUILayout.EndHorizontal();  
    }

    private void CreatMap(int level)
    {
        MapData m = new MapData();
        AssetDatabase.CreateAsset(m, "Assets/Resources/MapData/Map_" + level + ".asset");
    }

    private MapData GetMap(int level)
    {
        MapData m =(MapData) AssetDatabase.LoadAssetAtPath("Assets/Resources/MapData/Map_" + level + ".asset", typeof(MapData));
        row = m.lenghtMap;
        int[,] maptemp = m.GetMap();
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                Map[i, j] = maptemp[i, j];
            }
        }
//        Map = m.GetMap();
        if(m.GetMap() == null) Debug.Log("null");
   
        return m;
    }

    private void UpdateMap(int level)
    {
        MapData m = (MapData)AssetDatabase.LoadAssetAtPath("Assets/Resources/MapData/Map_" + level + ".asset", typeof(MapData));

        int[,] mapp = new int[row, 7];
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                mapp[i, j] = Map[i, j];
            }
        }

        m.UpdateMap(mapp, row, 7);
        EditorUtility.SetDirty(m);
    }
}
