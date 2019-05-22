using DG.DemiEditor;
using UnityEngine;
using UnityEditor; 


public class CreatMapEditor : EditorWindow {
    string myString = "Hello World";
    bool groupEnabled;
    bool myBool = true;
    float myFloat = 1.23f;
    public int[,] Map = new int[100,7];
    private Vector2 scrollViewVector;
    private GUIStyle style;
    private static CreatMapEditor window;

    [MenuItem("ToolMap/My Window")]
    public static void ShowWindow() {
        window = (CreatMapEditor)EditorWindow.GetWindow(typeof(CreatMapEditor)); 
        window.Show();
    }

    void OnGUI() {
        GUI.changed = false;

        GUILayout.Space(20);
        GUILayout.BeginHorizontal();
        GUILayout.Space(30);
//        int oldSelected = selectedTab;
//        selectedTab = GUILayout.Toolbar(selectedTab, toolbarStrings, new GUILayoutOption[] { GUILayout.Width(350) });
        GUILayout.EndHorizontal();

        //scrollViewVector = GUI.BeginScrollView(new Rect(25, 45, position.width - 30, position.height), scrollViewVector, new Rect(0, 0, 400, 4200));
        Rect rect = EditorGUILayout.BeginHorizontal();
        scrollViewVector = GUILayout.BeginScrollView(scrollViewVector);
        GUILayout.Space(-30);
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                Debug.Log("Button click...");

                GUILayout.Button("Test level", new GUILayoutOption[] {GUILayout.Width(150)});
//                if (GUI.Button(new Rect(new Vector2(j * 30 + 100, i * 30 + 100), Vector2.one * 30),
//                    Map[i, j].ToString()))
//                {
//                    Map[i, j]++;
//
//                }
            }
        }
        //
            //        if (selectedTab == 0) {
            //
            //
            //            //GUILayout.Space(10);
            //            DisplayMenu();
            //            DisplayLevelData();
            //            //GUILayout.Space(10);
            //            //GUILayout.Space(10);
            //            GUIStars();
            //            //GUILayout.Space(10);
            //
            //        } else if (selectedTab == 1) {
            //            //GUISettings();
            //            DisplayMenuBoss();
            //            DisplayDataBoss();
            //
            //        } else if (selectedTab == 2) {
            //
            //        } else if (selectedTab == 3) {
            //
            //        } else if (selectedTab == 4) {
            //
            //        }
            //
            //        if (GUI.changed) {
            //            if (!EditorApplication.isPlaying)
            //                EditorSceneManager.MarkAllScenesDirty();
            //            //			EditorUtility.SetDirty (ItemsEditor.Instance);
            //        }


            GUILayout.EndScrollView();
        EditorGUILayout.EndHorizontal();
    }


    //    void OnGUI() { 
    //
    //        GUILayout.Label("CreatMap", EditorStyles.boldLabel);
    //         
    //        
    ////        pos =  GUILayout.BeginScrollView(
    ////            pos, GUILayout.Width(100), GUILayout.Height(500));
    ////        
    //        style = new GUIStyle(GUI.skin.button);
    //        style.normal.textColor = Color.red; 
    //        style.active.textColor = Color.green;
    //
    //        scrollViewVector = GUILayout.BeginScrollView(scrollViewVector);
    //        style.normal.background = Texture2D.blackTexture;
    //
    //
    //        //        GUI.Button(new Rect(10, 10, 70, 30), "A button");
    ////        if (GUI.Button(new Rect(70, 10, 70, 30), "A button"))
    ////        { 
    ////            Debug.Log("Button click");
    //            for (int i = 0; i < 10; i++)
    //            {
    //                for (int j = 0; j < 7; j++)
    //                {
    //                    Debug.Log("Button click...");
    //                    if (GUI.Button(new Rect(new Vector2(j * 30 + 100, i * 30 + 100), Vector2.one * 30),Map[i, j].ToString()))
    //                    {
    //                        Map[i, j]++;
    //
    //                    }
    //                }
    //            }
    //        //        }
    //        GUILayout.EndScrollView(); 
    //    }
}
